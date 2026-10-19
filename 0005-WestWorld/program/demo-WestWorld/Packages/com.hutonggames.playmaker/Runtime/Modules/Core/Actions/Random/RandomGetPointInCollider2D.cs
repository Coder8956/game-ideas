using System;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Random)]
    [ConvertibleGroup(ConvertibleGroup.RandomVector2)]
    [ActionDescription("Get a random point inside a Collider2D. Supports BoxCollider2D, CircleCollider2D, and CapsuleCollider2D.")]
    public class RandomGetPointInCollider2D : BaseAction
    {
        [Tooltip("A Collider2D component.")]
        [SerializeField]
        private Collider2DVar Collider;

        [DefaultName("RandomPoint")]
        [Tooltip("Store the random point in a Vector2 variable.")]
        [SerializeField, WriteOnly]
        public Vector2Ref StoreResult;

        private Collider2D _collider;
        
        public override bool CanExecute() => CheckParameters(Collider, StoreResult);
        
        public override void Execute()
        {
            _collider = Collider.Value;
            if (_collider == null) return;

            var randomPoint = GetRandomPointInCollider();
            StoreResult.Value = randomPoint;
        }

        private Vector2 GetRandomPointInCollider() =>
            _collider switch
            {
                BoxCollider2D boxCollider => GetRandomPointInBox(boxCollider),
                CircleCollider2D circleCollider => GetRandomPointInCircle(circleCollider),
                CapsuleCollider2D capsuleCollider => GetRandomPointInCapsule(capsuleCollider),
                _ => GetRandomPointInBoundsWithCollisionTest(_collider.bounds)
            };

        private Vector2 GetRandomPointInBox(BoxCollider2D boxCollider)
        {
            var transform = boxCollider.transform;
            var center = (Vector2)transform.TransformPoint(boxCollider.offset);
            var size = Vector2.Scale(boxCollider.size, transform.lossyScale);

            var randomX = Random.Range(-size.x * 0.5f, size.x * 0.5f);
            var randomY = Random.Range(-size.y * 0.5f, size.y * 0.5f);

            var localPoint = new Vector2(randomX, randomY);
            var worldPoint = center + (Vector2)(transform.rotation * localPoint);

            return worldPoint;
        }

        private Vector2 GetRandomPointInCircle(CircleCollider2D circleCollider)
        {
            var transform = circleCollider.transform;
            var center = (Vector2)transform.TransformPoint(circleCollider.offset);
            var radius = circleCollider.radius * Mathf.Max(transform.lossyScale.x, transform.lossyScale.y);

            return center + Random.insideUnitCircle * radius;
        }

        private Vector2 GetRandomPointInCapsule(CapsuleCollider2D capsuleCollider)
        {
            var transform = capsuleCollider.transform;
            var center = (Vector2)transform.TransformPoint(capsuleCollider.offset);
            var size = Vector2.Scale(capsuleCollider.size, transform.lossyScale);

            var isVertical = capsuleCollider.direction == CapsuleDirection2D.Vertical;
            var width = isVertical ? size.x : size.y;
            var height = isVertical ? size.y : size.x;

            var capsuleRadius = width * 0.5f;
            var capsuleLength = Mathf.Max(0, height - width);

            Vector2 localPoint;

            if (capsuleLength > 0)
            {
                // Choose between circular ends and rectangular middle
                var totalArea = Mathf.PI * capsuleRadius * capsuleRadius + capsuleLength * width;
                var circleArea = Mathf.PI * capsuleRadius * capsuleRadius;

                if (Random.value < circleArea / totalArea)
                {
                    // Point in circular ends
                    var endOffset = Random.value < 0.5f ? -capsuleLength * 0.5f : capsuleLength * 0.5f;
                    var circlePoint = Random.insideUnitCircle * capsuleRadius;

                    localPoint = isVertical
                        ? new Vector2(circlePoint.x, endOffset + circlePoint.y)
                        : new Vector2(endOffset + circlePoint.x, circlePoint.y);
                }
                else
                {
                    // Point in rectangular middle
                    var rectX = Random.Range(-capsuleRadius, capsuleRadius);
                    var rectY = Random.Range(-capsuleLength * 0.5f, capsuleLength * 0.5f);

                    localPoint = isVertical
                        ? new Vector2(rectX, rectY)
                        : new Vector2(rectY, rectX);
                }
            }
            else
            {
                // Capsule is essentially a circle
                localPoint = Random.insideUnitCircle * capsuleRadius;
            }

            return center + (Vector2)(transform.rotation * localPoint);
        }

        private Vector2 GetRandomPointInBoundsWithCollisionTest(Bounds bounds)
        {
            const int maxAttempts = 10;

            for (var i = 0; i < maxAttempts; i++)
            {
                var randomX = Random.Range(bounds.min.x, bounds.max.x);
                var randomY = Random.Range(bounds.min.y, bounds.max.y);
                var point = new Vector2(randomX, randomY);

                // Test if the point is inside the collider
                if (_collider.OverlapPoint(point))
                {
                    return point;
                }
            }

            // Fallback to bounds center if no valid point found
            LogWarning(
                $"Could not find a valid point inside collider after {maxAttempts} attempts. Using bounds center.");
            return bounds.center;
        }

        public override string GetSummary() => "Get random point in {Collider} -> {StoreResult}";
    }
}