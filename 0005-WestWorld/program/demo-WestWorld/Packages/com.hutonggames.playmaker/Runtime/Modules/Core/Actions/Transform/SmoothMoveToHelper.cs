using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    /// <summary>
    /// Frame-independent smoothing toward a target position with optional speed cap.
    /// Applies MoveAxis constraints consistently.
    /// </summary>
    public class SmoothMoveToHelper
    {
        private Vector3 _velocity;

        /// <summary>
        /// Update the position from -> to using SmoothTime and optional MaxSpeed.
        /// - SmoothTime == 0 && MaxSpeed == 0 : snap to target
        /// - SmoothTime == 0 && MaxSpeed  > 0 : MoveTowards at capped units/sec
        /// - SmoothTime  > 0                 : SmoothDamp (optionally capped)
        /// Axis constraints are applied to the target each frame.
        /// </summary>
        public Vector3 Update(MoveAxis axis, Vector3 from, Vector3 to, float smoothTime, float maxSpeed)
        {
            // Constrain target along the chosen axis (keep the other components from 'from')
            to = MoveAxisHelper.Apply(axis, from, to);

            // Instant / Speed-limited without smoothing
            if (smoothTime <= 0f)
            {
                if (maxSpeed <= 0f) return to; // snap
                return Vector3.MoveTowards(from, to, Mathf.Max(0f, maxSpeed) * Time.deltaTime);
            }

            // SmoothDamp with optional maxSpeed cap
            return Vector3.SmoothDamp(
                from,
                to,
                ref _velocity,
                Mathf.Max(0.0001f, smoothTime),     // avoid 0 which would clamp internally anyway
                Mathf.Max(0f, maxSpeed),                      // 0 means uncapped
                Time.deltaTime
            );
        }

        /// <summary> Reset the internal velocity (e.g., when (re)starting a move). </summary>
        public void Reset() => _velocity = Vector3.zero;
    }
}