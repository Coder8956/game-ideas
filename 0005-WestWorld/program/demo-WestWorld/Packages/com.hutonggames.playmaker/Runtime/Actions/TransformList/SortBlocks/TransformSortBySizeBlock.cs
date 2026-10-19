using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayName("Size")]
    public sealed class TransformSortBySizeBlock : TransformSortBlock
    {
        public enum SizeMetric
        {
            Auto,
            RendererBoundsMagnitude,
            RendererBoundsVolume,
            LossyScaleMagnitude,
            LossyScaleVolume
        }

        [Tooltip("How size is measured for each Transform.")]
        public SizeMetric Metric = SizeMetric.Auto;

        public override bool TryGetSortValue(Transform transform, out object value)
        {
            value = null;
            if (transform == null)
                return false;

            value = GetSize(transform, Metric);
            return true;
        }

        public override string GetSummary() =>
            Metric == SizeMetric.Auto
                ? "Size"
                : $"Size ({Metric})";

        private static float GetSize(Transform transform, SizeMetric metric)
        {
            switch (metric)
            {
                case SizeMetric.RendererBoundsMagnitude:
                    return GetRendererBoundsMagnitude(transform);

                case SizeMetric.RendererBoundsVolume:
                    return GetRendererBoundsVolume(transform);

                case SizeMetric.LossyScaleMagnitude:
                    return transform.lossyScale.magnitude;

                case SizeMetric.LossyScaleVolume:
                    return GetVolume(transform.lossyScale);

                case SizeMetric.Auto:
                default:
                {
                    var renderer = transform.GetComponent<Renderer>();
                    return renderer != null
                        ? renderer.bounds.size.magnitude
                        : transform.lossyScale.magnitude;
                }
            }
        }

        private static float GetRendererBoundsMagnitude(Transform transform)
        {
            var renderer = transform.GetComponent<Renderer>();
            return renderer != null
                ? renderer.bounds.size.magnitude
                : 0f;
        }

        private static float GetRendererBoundsVolume(Transform transform)
        {
            var renderer = transform.GetComponent<Renderer>();
            return renderer != null
                ? GetVolume(renderer.bounds.size)
                : 0f;
        }

        private static float GetVolume(Vector3 vector) =>
            Mathf.Abs(vector.x * vector.y * vector.z);
    }
}