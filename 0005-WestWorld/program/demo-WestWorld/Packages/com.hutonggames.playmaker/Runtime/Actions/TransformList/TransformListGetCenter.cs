using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    public enum Weighted
    {
        Equal,           // Every transform weight = 1
        TransformScale,  // Weight by |lossyScale.x * y * z|
        RendererBounds,  // Weight by renderer bounds volume (fallback to size^2 if flat)
        RendererAlpha    // Weight by visible alpha (SpriteRenderer.color.a or material color a)
    }

    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.GameplayTargetingTransformList)]
    [ActionDescription("Get the (optionally weighted) center position of a list of Transforms.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform-up.html")]
    public sealed class TransformListGetCenter : BaseAction
    {
        [Tooltip("The Transform List")]
        [SerializeField] private TransformListRef _transforms;

        [Tooltip("How to weight each transform when calculating the center.")]
        [SerializeField] private Weighted _weightMode = Weighted.Equal;

        [Tooltip("The axis to calculate the center on.")]
        [SerializeField] private MoveAxisVar _axis;

        [Tooltip("Store the calculated center in this Vector3 variable.")]
        [SerializeField, WriteOnly] private Vector3Ref _center;

        public override bool CanExecute() => CheckParameters(_transforms, _axis, _center);

        public override void Execute()
        {
            if (_transforms == null || _transforms.Value == null || _transforms.Value.Count == 0)
            {
                _center.Value = Vector3.zero;
                return;
            }

            var weightedSum = Vector3.zero;
            double weightSum = 0.0;

            // First pass for weighted center
            foreach (var t in _transforms.Value)
            {
                if (t == null) continue;

                var w = ComputeWeight(t, _weightMode);
                weightedSum += t.position * w;
                weightSum += w;
            }

            Vector3 centerPosition;

            if (weightSum > 0.0)
            {
                centerPosition = weightedSum / (float)weightSum;
            }
            else
            {
                // Fallback: unweighted average (Equal) so result is still useful
                var sumPosition = Vector3.zero;
                var count = 0;
                foreach (var t in _transforms.Value)
                {
                    if (t == null) continue;
                    sumPosition += t.position;
                    count++;
                }

                centerPosition = count > 0 ? sumPosition / Mathf.Max(1, count) : Vector3.zero;
            }

            // Apply axis constraints using MoveAxisHelper
            _center.Value = MoveAxisHelper.Apply(_axis.Value, _center.Value, centerPosition);
        }

        public override string GetSummary() =>
            "Get {_transforms}" +
            (_weightMode != Weighted.Equal ? $" weighted ({_weightMode}) " : "") +
            "center" +
            (_axis.IsNotDefault(MoveAxis.XYZ) ? " ({_axis})" : "") +
            " -> {_center}";

        // --------------------
        // Helpers
        // --------------------

        private static float ComputeWeight(Transform t, Weighted mode)
        {
            switch (mode)
            {
                case Weighted.Equal:
                    return 1f;

                case Weighted.TransformScale:
                {
                    // Use approximate world-space volume from lossyScale
                    var s = t.lossyScale;
                    var vol = Mathf.Abs(s.x * s.y * s.z);
                    // Guard against degenerate scales (e.g., 2D with z=0)
                    return vol > 0f ? vol : Mathf.Max(s.sqrMagnitude, 0f); // fallback to size^2 if flat
                }

                case Weighted.RendererBounds:
                {
                    var r = t.GetComponent<Renderer>();
                    if (r == null) return 0f;
                    var size = r.bounds.size; // world-space
                    var vol = Mathf.Abs(size.x * size.y * size.z);
                    // If object is effectively 2D/flat (vol ~ 0), use size^2 as a reasonable proxy
                    return vol > 0f ? vol : size.sqrMagnitude;
                }

                case Weighted.RendererAlpha:
                {
                    // Prefer SpriteRenderer alpha if present; otherwise try material color alpha
                    var sr = t.GetComponent<SpriteRenderer>();
                    if (sr != null) return Mathf.Clamp01(sr.color.a);

                    var r = t.GetComponent<Renderer>();
                    if (r == null) return 0f;

                    if (TryGetSharedColor(r, out var c)) return Mathf.Clamp01(c.a);

                    // If no obvious color property, assume fully opaque (common for meshes without a color property)
                    return 1f;
                }

                default:
                    return 1f;
            }
        }

        /// <summary>
        /// Tries to read an alpha-bearing color without instantiating materials.
        /// Checks common properties in order: _BaseColor (URP/HDRP), _Color (Built-in).
        /// </summary>
        private static bool TryGetSharedColor(Renderer renderer, out Color color)
        {
            color = Color.white;

            // Avoid material (which instantiates); prefer sharedMaterial when possible.
            var mat = renderer.sharedMaterial;
            if (mat == null) return false;

            // URP/HDRP commonly use _BaseColor
            if (mat.HasProperty("_BaseColor"))
            {
                color = mat.GetColor("_BaseColor");
                return true;
            }

            // Built-in pipeline commonly uses _Color
            if (mat.HasProperty("_Color"))
            {
                color = mat.GetColor("_Color");
                return true;
            }

            return false;
        }
    }
}
