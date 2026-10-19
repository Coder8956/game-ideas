using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HutongGames.PlayMaker.Actions
{
    public enum RandomAxisValueMode
    {
        Disabled,   // No effect. Skip applying randomness.
        Uniform,    // Single FloatVar applied to X,Y,Z
        PerAxis,    // FloatVar for each axis
        [InspectorName("Vector3")] Vector3Var  // Single Vector3Var
    }

[Serializable]
    public struct RandomAxisValue
    {
        [SerializeField] private RandomAxisValueMode _mode;

        [Tooltip( "Uniform value for all axes." )]
        [SerializeField] private FloatVar _uniform;

        [SerializeField] private FloatVar _x;
        [SerializeField] private FloatVar _y;
        [SerializeField] private FloatVar _z;

        [SerializeField] private Vector3Var _vector;

        public RandomAxisValueMode Mode => _mode;

        /// <summary>
        /// Returns the configured (x,y,z) values for this axis set.
        /// Disabled => Vector3.zero.
        /// </summary>
        public Vector3 GetVector3()
        {
            switch (_mode)
            {
                case RandomAxisValueMode.Uniform:
                    return new Vector3(_uniform.Value, _uniform.Value, _uniform.Value);

                case RandomAxisValueMode.PerAxis:
                    return new Vector3(_x.Value, _y.Value, _z.Value);

                case RandomAxisValueMode.Vector3Var:
                    return _vector.Value;

                case RandomAxisValueMode.Disabled:
                default:
                    return Vector3.zero;
            }
        }

        public bool IsEnabled => _mode != RandomAxisValueMode.Disabled;

        /// <summary>
        /// Returns a random vector where each axis is in [-v, +v],
        /// using the configured values. Disabled => Vector3.zero.
        /// </summary>
        public Vector3 GetRandomSignedVector3()
        {
            if (!IsEnabled)
                return Vector3.zero;

            var v = GetVector3();
            if (v == Vector3.zero)
                return Vector3.zero;

            return new Vector3(
                Random.Range(-v.x, v.x),
                Random.Range(-v.y, v.y),
                Random.Range(-v.z, v.z)
            );
        }

        /// <summary>
        /// Applies a random ±offset to position using the configured values.
        /// Disabled => no change.
        /// </summary>
        public void ApplyOffset(ref Vector3 position)
        {
            if (!IsEnabled)
                return;

            var delta = GetRandomSignedVector3();
            if (delta == Vector3.zero)
                return;

            position += delta;
        }

        /// <summary>
        /// Applies a random rotation in degrees around each axis,
        /// where each axis is in [-v, +v] degrees.
        /// Disabled => no change.
        /// </summary>
        public void ApplyRotationDegrees(ref Quaternion rotation)
        {
            if (!IsEnabled)
                return;

            var v = GetVector3();
            if (v == Vector3.zero)
                return;

            var deltaEuler = new Vector3(
                Random.Range(-v.x, v.x),
                Random.Range(-v.y, v.y),
                Random.Range(-v.z, v.z)
            );

            rotation *= Quaternion.Euler(deltaEuler);
        }

        /// <summary>
        /// Applies a random scale delta relative to the current scale.
        /// Each axis uses a delta in [-v, +v] => multiplier (1 + delta).
        /// E.g., v = 0.2 => multiplier in [0.8, 1.2].
        /// Disabled => no change.
        /// </summary>
        public void ApplyScaleDelta(ref Vector3 scale)
        {
            if (!IsEnabled)
                return;

            var v = GetVector3();
            if (v == Vector3.zero)
                return;

            const float minScaleMultiplier = 0.01f;

            // For Uniform mode, generate single multiplier for all axes
            if (_mode == RandomAxisValueMode.Uniform)
            {
                var uniformMultiplier = GetRandomMultiplier(v.x);
                scale = new Vector3(
                    scale.x * uniformMultiplier,
                    scale.y * uniformMultiplier,
                    scale.z * uniformMultiplier
                );
                return;
            }

            // For other modes, apply per-axis multipliers
            scale = new Vector3(
                scale.x * GetRandomMultiplier(v.x),
                scale.y * GetRandomMultiplier(v.y),
                scale.z * GetRandomMultiplier(v.z)
            );
            return;

            float GetRandomMultiplier(float delta)
            {
                if (delta <= 0f)
                    return 1f;

                // Generate random multiplier in range [1-delta, 1+delta]
                // and ensure it doesn't go below minScaleMultiplier
                return Mathf.Max(minScaleMultiplier, 1f + Random.Range(-delta, delta));
            }
        }
    }
}