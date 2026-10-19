using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    /// <summary>
    /// Computes a target rotation that makes a chosen local axis of a Transform face a world-space direction.
    /// Supports RotationConstraint (All/X/Y/Z) and AxisDirection (Right/Up/Forward/Left/Down/Back).
    ///
    /// This replaces older IgnoreY/IgnoreZ options — those behaviors are now implied by RotationConstraint:
    /// - All: Free 3D rotation
    /// - Y: Rotate only around world Y (flat horizontal turn)
    /// - Z: Rotate only around world Z (2D rotation)
    /// - X: Rotate only around world X (pitch-only)
    /// </summary>
    internal static class LookAtCompute
    {
        /// <param name="t">Transform to rotate.</param>
        /// <param name="dirWorld">World-space direction to face (need not be normalized).</param>
        /// <param name="constraint">Rotation constraint: All, X, Y, or Z.</param>
        /// <param name="facingAxis">Which local axis of the transform should face the target (AxisDirection).</param>
        /// <param name="worldUp">World up vector (used only when constraint == All). Defaults to Vector3.up if zero.</param>
        /// <returns>Computed target rotation.</returns>
        public static Quaternion ComputeTargetRotation(
            Transform t,
            Vector3 dirWorld,
            RotationConstraint constraint,
            AxisDirection facingAxis,
            Vector3 worldUp)
        {
            if (t == null) return Quaternion.identity;

            // ---- 0) Early exit for invalid direction ----
            if (dirWorld.sqrMagnitude < 1e-8f)
                return t.rotation;

            var dir = dirWorld.normalized;

            // ---- 1) Full 3D look (RotationConstraint.All) ----
            if (constraint == RotationConstraint.None)
            {
                if (worldUp.sqrMagnitude < 1e-8f)
                    worldUp = Vector3.up;

                // LookRotation aligns +Z to dir using given up
                var baseLook = Quaternion.LookRotation(dir, worldUp);

                // Adjust so the chosen local axis (e.g., Right/Up/Forward) becomes the "look" axis
                var localAxis = facingAxis.GetDirection();
                var offset = Quaternion.FromToRotation(localAxis, Vector3.forward);

                return baseLook * offset;
            }

            // ---- 2) Axis-locked rotation (X, Y, Z) ----
            var normal = ConstraintAxisVector(constraint);

            // Project both desired and current facing vectors into the rotation plane
            var desiredInPlane = Vector3.ProjectOnPlane(dir, normal).normalized;
            if (desiredInPlane.sqrMagnitude < 1e-8f)
                return t.rotation; // target direction nearly parallel to the lock axis

            var currentFacingWorld = facingAxis.GetDirection(t);
            var currentInPlane = Vector3.ProjectOnPlane(currentFacingWorld, normal).normalized;
            if (currentInPlane.sqrMagnitude < 1e-8f)
                return t.rotation;

            // Signed angle in the plane, around the locked axis
            var angle = Mathf.Atan2(
                Vector3.Dot(Vector3.Cross(currentInPlane, desiredInPlane), normal),
                Vector3.Dot(currentInPlane, desiredInPlane)
            ) * Mathf.Rad2Deg;

            return Quaternion.AngleAxis(angle, normal) * t.rotation;
        }

        /// <summary>
        /// Convenience overload: look at a world-space point (dir = point - transform.position).
        /// </summary>
        public static Quaternion ComputeTargetRotationToPoint(
            Transform t,
            Vector3 worldPoint,
            RotationConstraint constraint,
            AxisDirection facingAxis,
            Vector3 worldUp)
        {
            if (t == null) return Quaternion.identity;
            var dir = worldPoint - t.position;
            return ComputeTargetRotation(t, dir, constraint, facingAxis, worldUp);
        }

        /// <summary>
        /// Converts a RotationConstraint to its corresponding world axis vector.
        /// </summary>
        private static Vector3 ConstraintAxisVector(RotationConstraint c) => c switch
        {
            RotationConstraint.X => Vector3.right,
            RotationConstraint.Y => Vector3.up,
            RotationConstraint.Z => Vector3.forward,
            _                     => Vector3.zero // All
        };
    }
}
