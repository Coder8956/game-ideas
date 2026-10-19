using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    public static class SmoothLookAtHelper
    {
        /// <summary>
        /// Frame-independent smoothing from `from` to `to`.
        /// Call every frame; pass last frame's result as `from`.
        /// </summary>
        /// <param name="from">Rotation at the start of this frame (previous result).</param>
        /// <param name="to">Desired target rotation.</param>
        /// <param name="smoothTime">Seconds to halve the error (smaller = snappier).</param>
        /// <param name="maxSpeedDegPerSec">Optional cap in deg/s (0 = uncapped).</param>
        public static Quaternion Update(Quaternion from, Quaternion to, float smoothTime, float maxSpeedDegPerSec = 0f)
        {
            // Instant rotation when both smoothing and speed are disabled
            if (smoothTime <= 0f && maxSpeedDegPerSec <= 0f)
                return to;
            
            var dt = Time.deltaTime;
            const float ln2 = 0.69314718056f;

            // Exponential smoothing amount (frame-rate independent)
            var alpha = 1f - Mathf.Exp(-ln2 * dt / Mathf.Max(1e-4f, smoothTime));
            
            if (float.IsNaN(alpha) || float.IsInfinity(alpha))
                return to;

            // First, ease toward target on the sphere
            var eased = Quaternion.Slerp(from, to, alpha);

            // Then, optionally cap the per-frame angular step
            if (maxSpeedDegPerSec > 0f)
                eased = Quaternion.RotateTowards(from, eased, maxSpeedDegPerSec * dt);

            return eased;
        }
    }
}