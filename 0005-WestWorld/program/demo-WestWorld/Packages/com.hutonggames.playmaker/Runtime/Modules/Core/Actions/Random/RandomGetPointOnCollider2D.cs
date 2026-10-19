
using System;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Random)]
    [ConvertibleGroup(ConvertibleGroup.RandomVector2)]
    [ActionDescription("Get a random point on the perimeter of a Collider2D. Supports BoxCollider2D, CircleCollider2D, and CapsuleCollider2D.")]
    public class RandomGetPointOnCollider2D : BaseAction
    {
        [Tooltip("A Collider2D component.")]
        [SerializeField]
        private Collider2DVar Collider;

        [DefaultName("RandomPoint")]
        [Tooltip("Store the random point on the perimeter in a Vector2 variable.")]
        [SerializeField, WriteOnly]
        public Vector2Ref StoreResult;

        private Collider2D _collider;
        
        public override bool CanExecute() => CheckParameters(Collider, StoreResult);
        
        public override void Execute()
        {
            _collider = Collider.Value;
            if (_collider == null) return;

            var randomPoint = GetRandomPointOnCollider();
            StoreResult.Value = randomPoint;
        }

        private Vector2 GetRandomPointOnCollider() =>
            _collider switch
            {
                BoxCollider2D boxCollider => GetRandomPointOnBox(boxCollider),
                CircleCollider2D circleCollider => GetRandomPointOnCircle(circleCollider),
                CapsuleCollider2D capsuleCollider => GetRandomPointOnCapsule(capsuleCollider),
                EdgeCollider2D edgeCollider => GetRandomPointOnEdge(edgeCollider),
                _ => GetRandomPointOnBounds(_collider.bounds)
            };

        private Vector2 GetRandomPointOnBox(BoxCollider2D boxCollider)
        {
            var transform = boxCollider.transform;
            var center = (Vector2)transform.TransformPoint(boxCollider.offset);
            var size = Vector2.Scale(boxCollider.size, transform.lossyScale);

            var halfWidth = size.x * 0.5f;
            var halfHeight = size.y * 0.5f;

            // Calculate perimeter segments
            var topLength = size.x;
            var rightLength = size.y;
            var bottomLength = size.x;
            var leftLength = size.y;
            var totalPerimeter = topLength + rightLength + bottomLength + leftLength;

            var randomValue = Random.Range(0f, totalPerimeter);
            Vector2 localPoint;

            if (randomValue < topLength)
            {
                // Top edge
                var t = randomValue / topLength;
                localPoint = new Vector2(Mathf.Lerp(-halfWidth, halfWidth, t), halfHeight);
            }
            else if (randomValue < topLength + rightLength)
            {
                // Right edge
                var t = (randomValue - topLength) / rightLength;
                localPoint = new Vector2(halfWidth, Mathf.Lerp(halfHeight, -halfHeight, t));
            }
            else if (randomValue < topLength + rightLength + bottomLength)
            {
                // Bottom edge
                var t = (randomValue - topLength - rightLength) / bottomLength;
                localPoint = new Vector2(Mathf.Lerp(halfWidth, -halfWidth, t), -halfHeight);
            }
            else
            {
                // Left edge
                var t = (randomValue - topLength - rightLength - bottomLength) / leftLength;
                localPoint = new Vector2(-halfWidth, Mathf.Lerp(-halfHeight, halfHeight, t));
            }

            var worldPoint = center + (Vector2)(transform.rotation * localPoint);
            return worldPoint;
        }

        private Vector2 GetRandomPointOnCircle(CircleCollider2D circleCollider)
        {
            var transform = circleCollider.transform;
            var center = (Vector2)transform.TransformPoint(circleCollider.offset);
            var radius = circleCollider.radius * Mathf.Max(transform.lossyScale.x, transform.lossyScale.y);

            var angle = Random.Range(0f, 2f * Mathf.PI);
            var pointOnCircle = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;

            return center + (Vector2)(transform.rotation * pointOnCircle);
        }

        private Vector2 GetRandomPointOnCapsule(CapsuleCollider2D capsuleCollider)
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
                // Calculate perimeter segments
                var semicircle1 = Mathf.PI * capsuleRadius;
                var semicircle2 = Mathf.PI * capsuleRadius;
                var totalPerimeter = capsuleLength + capsuleLength + semicircle1 + semicircle2;

                var randomValue = Random.Range(0f, totalPerimeter);

                if (randomValue < capsuleLength)
                {
                    // First straight side
                    var t = randomValue / capsuleLength;
                    var sideY = Mathf.Lerp(-capsuleLength * 0.5f, capsuleLength * 0.5f, t);
                    localPoint = isVertical 
                        ? new Vector2(capsuleRadius, sideY)
                        : new Vector2(sideY, capsuleRadius);
                }
                else if (randomValue < capsuleLength + semicircle1)
                {
                    // First semicircle
                    var t = (randomValue - capsuleLength) / semicircle1;
                    var angle = Mathf.Lerp(0f, Mathf.PI, t);
                    var circlePoint = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * capsuleRadius;
                    var endOffset = capsuleLength * 0.5f;

                    localPoint = isVertical
                        ? new Vector2(circlePoint.x, endOffset + circlePoint.y)
                        : new Vector2(endOffset + circlePoint.x, circlePoint.y);
                }
                else if (randomValue < capsuleLength + semicircle1 + capsuleLength)
                {
                    // Second straight side
                    var t = (randomValue - capsuleLength - semicircle1) / capsuleLength;
                    var sideY = Mathf.Lerp(capsuleLength * 0.5f, -capsuleLength * 0.5f, t);
                    localPoint = isVertical 
                        ? new Vector2(-capsuleRadius, sideY)
                        : new Vector2(sideY, -capsuleRadius);
                }
                else
                {
                    // Second semicircle
                    var t = (randomValue - capsuleLength - semicircle1 - capsuleLength) / semicircle2;
                    var angle = Mathf.Lerp(Mathf.PI, 2f * Mathf.PI, t);
                    var circlePoint = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * capsuleRadius;
                    var endOffset = -capsuleLength * 0.5f;

                    localPoint = isVertical
                        ? new Vector2(circlePoint.x, endOffset + circlePoint.y)
                        : new Vector2(endOffset + circlePoint.x, circlePoint.y);
                }
            }
            else
            {
                // Capsule is essentially a circle
                var angle = Random.Range(0f, 2f * Mathf.PI);
                localPoint = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * capsuleRadius;
            }

            return center + (Vector2)(transform.rotation * localPoint);
        }
        
                private Vector2 GetRandomPointOnEdge(EdgeCollider2D edgeCollider)
        {
            var transform = edgeCollider.transform;
            var points = edgeCollider.points;

            if (points == null || points.Length < 2)
            {
                LogWarning("EdgeCollider2D has insufficient points. Using bounds center.");
                return transform.TransformPoint(edgeCollider.offset);
            }

            // Calculate cumulative lengths of all edge segments
            var segmentLengths = new float[points.Length - 1];
            var totalLength = 0f;

            for (var i = 0; i < points.Length - 1; i++)
            {
                var localStart = points[i] + edgeCollider.offset;
                var localEnd = points[i + 1] + edgeCollider.offset;
                
                // Transform to world space to account for scaling
                var worldStart = transform.TransformPoint(localStart);
                var worldEnd = transform.TransformPoint(localEnd);
                
                var segmentLength = Vector2.Distance(worldStart, worldEnd);
                segmentLengths[i] = segmentLength;
                totalLength += segmentLength;
            }

            if (totalLength <= 0f)
            {
                LogWarning("EdgeCollider2D has zero total length. Using first point.");
                return transform.TransformPoint(points[0] + edgeCollider.offset);
            }

            // Select random position along total length
            var randomDistance = Random.Range(0f, totalLength);
            var accumulatedLength = 0f;

            // Find which segment contains the random point
            for (var i = 0; i < segmentLengths.Length; i++)
            {
                if (randomDistance <= accumulatedLength + segmentLengths[i])
                {
                    // Interpolate along this segment
                    var segmentProgress = (randomDistance - accumulatedLength) / segmentLengths[i];
                    var localStart = points[i] + edgeCollider.offset;
                    var localEnd = points[i + 1] + edgeCollider.offset;
                    
                    var localPoint = Vector2.Lerp(localStart, localEnd, segmentProgress);
                    return transform.TransformPoint(localPoint);
                }
                
                accumulatedLength += segmentLengths[i];
            }

            // Fallback (should not reach here, but safety)
            var lastPoint = points[^1] + edgeCollider.offset;
            return transform.TransformPoint(lastPoint);
        }


        private Vector2 GetRandomPointOnBounds(Bounds bounds)
        {
            // Fallback for unsupported collider types - use bounds perimeter
            var width = bounds.size.x;
            var height = bounds.size.y;
            var perimeter = 2f * (width + height);
            var randomValue = Random.Range(0f, perimeter);

            Vector2 point;

            if (randomValue < width)
            {
                // Top edge
                var t = randomValue / width;
                point = new Vector2(Mathf.Lerp(bounds.min.x, bounds.max.x, t), bounds.max.y);
            }
            else if (randomValue < width + height)
            {
                // Right edge
                var t = (randomValue - width) / height;
                point = new Vector2(bounds.max.x, Mathf.Lerp(bounds.max.y, bounds.min.y, t));
            }
            else if (randomValue < 2f * width + height)
            {
                // Bottom edge
                var t = (randomValue - width - height) / width;
                point = new Vector2(Mathf.Lerp(bounds.max.x, bounds.min.x, t), bounds.min.y);
            }
            else
            {
                // Left edge
                var t = (randomValue - 2f * width - height) / height;
                point = new Vector2(bounds.min.x, Mathf.Lerp(bounds.min.y, bounds.max.y, t));
            }

            //LogWarning($"Unsupported collider type. Using bounds perimeter for {_collider.GetType().Name}.");
            return point;
        }

        public override string GetSummary() => "Get random point on {Collider} -> {StoreResult}";
    }
}
