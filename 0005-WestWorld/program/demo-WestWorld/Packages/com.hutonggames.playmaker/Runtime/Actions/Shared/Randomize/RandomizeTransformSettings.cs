using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    public struct RandomizeTransformSettings
    {
        [Header("Position Offset (± units)")]
        [Tooltip("Maximum offset per axis. Interpreted as ± value.")]
        [SerializeField]
        private RandomAxisValue _offset;

        [Header("Rotation Offset (± degrees)")]
        [Tooltip("Maximum rotation per axis in degrees. Interpreted as ± value.")]
        [SerializeField]
        private RandomAxisValue _rotation;

        [Header("Scale Delta Around 1")]
        [Tooltip("Maximum scale delta per axis. 0.2 => scale in [0.8, 1.2].")]
        [SerializeField]
        private RandomAxisValue _scaleDelta;

        [Header("Flip Probability (0–1)")]
        [Tooltip("Probability of flipping each axis. 0 = never, 1 = always.")]
        [SerializeField]
        private RandomAxisValue _flipChance;

        public void Apply(ref Vector3 position, ref Quaternion rotation, ref Vector3 scale)
        {
            // Offset (±)
            var offsetMax = _offset.GetVector3();
            position += new Vector3(
                Random.Range(-offsetMax.x, offsetMax.x),
                Random.Range(-offsetMax.y, offsetMax.y),
                Random.Range(-offsetMax.z, offsetMax.z)
            );

            // Rotation (± degrees)
            var rotMax = _rotation.GetVector3();
            var deltaEuler = new Vector3(
                Random.Range(-rotMax.x, rotMax.x),
                Random.Range(-rotMax.y, rotMax.y),
                Random.Range(-rotMax.z, rotMax.z)
            );
            rotation = rotation * Quaternion.Euler(deltaEuler);

            // Scale (delta around current scale)
            var scaleDelta = _scaleDelta.GetVector3();   // e.g. 0.2 => ±20%
            var sDelta = new Vector3(
                1f + Random.Range(-scaleDelta.x, scaleDelta.x),
                1f + Random.Range(-scaleDelta.y, scaleDelta.y),
                1f + Random.Range(-scaleDelta.z, scaleDelta.z)
            );

            // FINAL fixed behavior: multiply the *current* scale
            scale = new Vector3(
                scale.x * sDelta.x,
                scale.y * sDelta.y,
                scale.z * sDelta.z
            );

            // Flip (probability 0–1)
            var flip = _flipChance.GetVector3();

            if (flip.x > 0f && Random.value < flip.x) scale.x *= -1f;
            if (flip.y > 0f && Random.value < flip.y) scale.y *= -1f;
            if (flip.z > 0f && Random.value < flip.z) scale.z *= -1f;
        }
    }
}
