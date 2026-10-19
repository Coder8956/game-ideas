using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    public static class PhysicsColliderQueries
    {
        public static bool IsSupportedOverlapCollider(Collider collider)
        {
            return collider is BoxCollider or SphereCollider or CapsuleCollider;
        }

        public static bool TryOverlapCollider(Collider collider,
                                              int layerMask,
                                              QueryTriggerInteraction hitTriggers,
                                              out Collider[] overlaps)
        {
            switch (collider)
            {
                case BoxCollider boxCollider:
                    overlaps = FilterSelf(boxCollider, OverlapBox(boxCollider, layerMask, hitTriggers));
                    return true;

                case SphereCollider sphereCollider:
                    overlaps = FilterSelf(sphereCollider, OverlapSphere(sphereCollider, layerMask, hitTriggers));
                    return true;

                case CapsuleCollider capsuleCollider:
                    overlaps = FilterSelf(capsuleCollider, OverlapCapsule(capsuleCollider, layerMask, hitTriggers));
                    return true;

                default:
                    overlaps = Array.Empty<Collider>();
                    return false;
            }
        }

        public static bool TryContainsPoint(Collider collider, Vector3 point)
        {
            return collider switch
            {
                BoxCollider boxCollider => BoxContainsPoint(boxCollider, point),
                SphereCollider sphereCollider => SphereContainsPoint(sphereCollider, point),
                CapsuleCollider capsuleCollider => CapsuleContainsPoint(capsuleCollider, point),
                _ => false
            };
        }

        public static bool TryGetClosestSurfacePoint(Collider collider, Vector3 point, out Vector3 surfacePoint)
        {
            switch (collider)
            {
                case BoxCollider boxCollider:
                    surfacePoint = GetClosestPointOnBoxSurface(boxCollider, point);
                    return true;

                case SphereCollider sphereCollider:
                    surfacePoint = GetClosestPointOnSphereSurface(sphereCollider, point);
                    return true;

                case CapsuleCollider capsuleCollider:
                    surfacePoint = GetClosestPointOnCapsuleSurface(capsuleCollider, point);
                    return true;

                default:
                    surfacePoint = default;
                    return false;
            }
        }

        private static Collider[] OverlapBox(BoxCollider boxCollider,
                                             int layerMask,
                                             QueryTriggerInteraction hitTriggers)
        {
            var transform = boxCollider.transform;
            var center = transform.TransformPoint(boxCollider.center);
            var halfExtents = Vector3.Scale(boxCollider.size * 0.5f, Abs(transform.lossyScale));

            // ReSharper disable once Unity.PreferNonAllocApi
            return Physics.OverlapBox(center, halfExtents, transform.rotation, layerMask, hitTriggers);
        }

        private static Collider[] OverlapSphere(SphereCollider sphereCollider,
                                                int layerMask,
                                                QueryTriggerInteraction hitTriggers)
        {
            var transform = sphereCollider.transform;
            var center = transform.TransformPoint(sphereCollider.center);
            var radius = sphereCollider.radius * MaxComponent(Abs(transform.lossyScale));

            // ReSharper disable once Unity.PreferNonAllocApi
            return Physics.OverlapSphere(center, radius, layerMask, hitTriggers);
        }

        private static Collider[] OverlapCapsule(CapsuleCollider capsuleCollider,
                                                 int layerMask,
                                                 QueryTriggerInteraction hitTriggers)
        {
            GetCapsuleWorldPoints(capsuleCollider, out var point0, out var point1, out var radius);

            // ReSharper disable once Unity.PreferNonAllocApi
            return Physics.OverlapCapsule(point0, point1, radius, layerMask, hitTriggers);
        }

        private static bool BoxContainsPoint(BoxCollider boxCollider, Vector3 point)
        {
            var localPoint = boxCollider.transform.InverseTransformPoint(point) - boxCollider.center;
            var halfExtents = boxCollider.size * 0.5f;

            return Mathf.Abs(localPoint.x) <= halfExtents.x + Mathf.Epsilon &&
                   Mathf.Abs(localPoint.y) <= halfExtents.y + Mathf.Epsilon &&
                   Mathf.Abs(localPoint.z) <= halfExtents.z + Mathf.Epsilon;
        }

        private static bool SphereContainsPoint(SphereCollider sphereCollider, Vector3 point)
        {
            var transform = sphereCollider.transform;
            var center = transform.TransformPoint(sphereCollider.center);
            var radius = sphereCollider.radius * MaxComponent(Abs(transform.lossyScale));

            return Vector3.SqrMagnitude(point - center) <= radius * radius + Mathf.Epsilon;
        }

        private static bool CapsuleContainsPoint(CapsuleCollider capsuleCollider, Vector3 point)
        {
            GetCapsuleWorldPoints(capsuleCollider, out var point0, out var point1, out var radius);
            var closestPoint = ClosestPointOnSegment(point0, point1, point);
            return Vector3.SqrMagnitude(point - closestPoint) <= radius * radius + Mathf.Epsilon;
        }

        private static Vector3 GetClosestPointOnBoxSurface(BoxCollider boxCollider, Vector3 point)
        {
            var transform = boxCollider.transform;
            var localPoint = transform.InverseTransformPoint(point) - boxCollider.center;
            var halfExtents = boxCollider.size * 0.5f;

            var clamped = new Vector3(
                Mathf.Clamp(localPoint.x, -halfExtents.x, halfExtents.x),
                Mathf.Clamp(localPoint.y, -halfExtents.y, halfExtents.y),
                Mathf.Clamp(localPoint.z, -halfExtents.z, halfExtents.z));

            var distanceToPositiveX = halfExtents.x - clamped.x;
            var distanceToNegativeX = clamped.x + halfExtents.x;
            var distanceToPositiveY = halfExtents.y - clamped.y;
            var distanceToNegativeY = clamped.y + halfExtents.y;
            var distanceToPositiveZ = halfExtents.z - clamped.z;
            var distanceToNegativeZ = clamped.z + halfExtents.z;

            var minDistance = distanceToPositiveX;
            var face = 0;

            if (distanceToNegativeX < minDistance)
            {
                minDistance = distanceToNegativeX;
                face = 1;
            }

            if (distanceToPositiveY < minDistance)
            {
                minDistance = distanceToPositiveY;
                face = 2;
            }

            if (distanceToNegativeY < minDistance)
            {
                minDistance = distanceToNegativeY;
                face = 3;
            }

            if (distanceToPositiveZ < minDistance)
            {
                minDistance = distanceToPositiveZ;
                face = 4;
            }

            if (distanceToNegativeZ < minDistance)
            {
                face = 5;
            }

            switch (face)
            {
                case 0:
                    clamped.x = halfExtents.x;
                    break;
                case 1:
                    clamped.x = -halfExtents.x;
                    break;
                case 2:
                    clamped.y = halfExtents.y;
                    break;
                case 3:
                    clamped.y = -halfExtents.y;
                    break;
                case 4:
                    clamped.z = halfExtents.z;
                    break;
                default:
                    clamped.z = -halfExtents.z;
                    break;
            }

            return transform.TransformPoint(clamped + boxCollider.center);
        }

        private static Vector3 GetClosestPointOnSphereSurface(SphereCollider sphereCollider, Vector3 point)
        {
            var transform = sphereCollider.transform;
            var center = transform.TransformPoint(sphereCollider.center);
            var radius = sphereCollider.radius * MaxComponent(Abs(transform.lossyScale));
            var direction = point - center;
            if (direction.sqrMagnitude <= Mathf.Epsilon)
            {
                direction = transform.forward.sqrMagnitude > Mathf.Epsilon ? transform.forward : Vector3.forward;
            }

            return center + direction.normalized * radius;
        }

        private static Vector3 GetClosestPointOnCapsuleSurface(CapsuleCollider capsuleCollider, Vector3 point)
        {
            GetCapsuleWorldPoints(capsuleCollider, out var point0, out var point1, out var radius);
            var segmentPoint = ClosestPointOnSegment(point0, point1, point);
            var direction = point - segmentPoint;
            if (direction.sqrMagnitude <= Mathf.Epsilon)
            {
                direction = capsuleCollider.direction switch
                {
                    0 => capsuleCollider.transform.up,
                    2 => capsuleCollider.transform.up,
                    _ => capsuleCollider.transform.right
                };
            }

            return segmentPoint + direction.normalized * radius;
        }

        private static void GetCapsuleWorldPoints(CapsuleCollider capsuleCollider,
                                                  out Vector3 point0,
                                                  out Vector3 point1,
                                                  out float radius)
        {
            var transform = capsuleCollider.transform;
            var center = transform.TransformPoint(capsuleCollider.center);
            var absScale = Abs(transform.lossyScale);

            Vector3 axis;
            float heightScale;
            float radiusScale;
            switch (capsuleCollider.direction)
            {
                case 0:
                    axis = transform.right;
                    heightScale = absScale.x;
                    radiusScale = Mathf.Max(absScale.y, absScale.z);
                    break;

                case 2:
                    axis = transform.forward;
                    heightScale = absScale.z;
                    radiusScale = Mathf.Max(absScale.x, absScale.y);
                    break;

                default:
                    axis = transform.up;
                    heightScale = absScale.y;
                    radiusScale = Mathf.Max(absScale.x, absScale.z);
                    break;
            }

            radius = capsuleCollider.radius * radiusScale;
            var height = Mathf.Max(capsuleCollider.height * heightScale, radius * 2f);
            var pointOffset = Mathf.Max(0f, height * 0.5f - radius);
            point0 = center + axis * pointOffset;
            point1 = center - axis * pointOffset;
        }

        private static Vector3 ClosestPointOnSegment(Vector3 segmentStart, Vector3 segmentEnd, Vector3 point)
        {
            var segment = segmentEnd - segmentStart;
            var lengthSquared = segment.sqrMagnitude;
            if (lengthSquared <= Mathf.Epsilon)
            {
                return segmentStart;
            }

            var t = Mathf.Clamp01(Vector3.Dot(point - segmentStart, segment) / lengthSquared);
            return segmentStart + segment * t;
        }

        private static Collider[] FilterSelf(Collider collider, Collider[] hits)
        {
            var count = 0;
            foreach (var hit in hits)
            {
                if (hit != null && hit != collider)
                {
                    count++;
                }
            }

            if (count == 0)
            {
                return Array.Empty<Collider>();
            }

            var overlaps = new Collider[count];
            var index = 0;
            foreach (var hit in hits)
            {
                if (hit == null || hit == collider) continue;
                overlaps[index++] = hit;
            }

            return overlaps;
        }

        private static Vector3 Abs(Vector3 value)
        {
            return new Vector3(Mathf.Abs(value.x), Mathf.Abs(value.y), Mathf.Abs(value.z));
        }

        private static float MaxComponent(Vector3 value)
        {
            return Mathf.Max(value.x, Mathf.Max(value.y, value.z));
        }
    }
}
