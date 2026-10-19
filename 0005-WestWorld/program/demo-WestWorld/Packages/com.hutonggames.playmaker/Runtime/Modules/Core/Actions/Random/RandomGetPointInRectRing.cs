using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace HutongGames.PlayMaker.Actions
{
    [HasSceneGUI]
    [Serializable, PublicAPI]
    [ActionCategory(Category.Random)]
    [ConvertibleGroup(ConvertibleGroup.RandomVector2)]
    [ActionDescription("Get a random point in a rectangular ring (between inner and outer rectangles).")]
    public class RandomGetPointInRectRing : BaseAction
    {
        [Tooltip("The local-space inner rectangle, relative to Offset.")]
        public RectVar InnerRect;

        [Tooltip("The local-space outer rectangle, relative to Offset.")]
        public RectVar OuterRect;

        [FormerlySerializedAs("Center")]
        [Tooltip("World-space offset applied to the sampled point. The inner and outer rects are evaluated in local space, then shifted by this Offset value.")]
        public Vector2Var Offset;

        [WriteOnly, DefaultName("RandomPoint")]
        [Tooltip("Store the random value in a Vector2 variable.")]
        public Vector2Ref StoreResult;

        public override void Reset()
        {
            OuterRect.Value = new Rect(-1, -1, 2, 2);
            InnerRect.Value = new Rect(-0.5f, -0.5f, 1, 1);
        }

        public override bool CanExecute() => CheckParameters(Offset, OuterRect, InnerRect, StoreResult);

        public override void Execute()
        {
            var outer = OuterRect.Value;
            var inner = InnerRect.Value;

            // Ensure inner is clamped inside outer (defensive)
            if (inner.xMin < outer.xMin) inner.xMin = outer.xMin;
            if (inner.xMax > outer.xMax) inner.xMax = outer.xMax;
            if (inner.yMin < outer.yMin) inner.yMin = outer.yMin;
            if (inner.yMax > outer.yMax) inner.yMax = outer.yMax;

            // Strip thicknesses
            var topH    = Mathf.Max(0f, outer.yMax - inner.yMax);
            var bottomH = Mathf.Max(0f, inner.yMin - outer.yMin);
            var leftW   = Mathf.Max(0f, inner.xMin - outer.xMin);
            var rightW  = Mathf.Max(0f, outer.xMax - inner.xMax);

            var outerW  = Mathf.Max(0f, outer.width);
            var innerH  = Mathf.Max(0f, inner.height);

            // Correct areas
            var topArea    = outerW * topH;       // full width × top thickness
            var bottomArea = outerW * bottomH;    // full width × bottom thickness
            var leftArea   = leftW  * innerH;     // left thickness × inner height
            var rightArea  = rightW * innerH;     // right thickness × inner height

            var total = topArea + bottomArea + leftArea + rightArea;

            // Degenerate: no ring area → pick a point on inner boundary (or just inner center)
            if (total <= Mathf.Epsilon)
            {
                StoreResult.Value = Offset.Value + new Vector2(inner.center.x, inner.center.y);
                return;
            }

            var pick = Random.Range(0f, total);
            Vector2 p;

            if (pick < topArea && topArea > 0f)
            {
                // Top strip: x in [outer.xMin, outer.xMax], y in [inner.yMax, outer.yMax]
                p = new Vector2(Random.Range(outer.xMin, outer.xMax), Random.Range(inner.yMax, outer.yMax));
            }
            else if (pick < topArea + bottomArea && bottomArea > 0f)
            {
                // Bottom strip: x in [outer.xMin, outer.xMax], y in [outer.yMin, inner.yMin]
                p = new Vector2(Random.Range(outer.xMin, outer.xMax), Random.Range(outer.yMin, inner.yMin));
            }
            else if (pick < topArea + bottomArea + leftArea && leftArea > 0f)
            {
                // Left strip: x in [outer.xMin, inner.xMin], y in [inner.yMin, inner.yMax]
                p = new Vector2(Random.Range(outer.xMin, inner.xMin), Random.Range(inner.yMin, inner.yMax));
            }
            else
            {
                // Right strip: x in [inner.xMax, outer.xMax], y in [inner.yMin, inner.yMax]
                // (We fall back here even if rightArea==0; in that case, other branches would have caught)
                p = new Vector2(Random.Range(inner.xMax, outer.xMax), Random.Range(inner.yMin, inner.yMax));
            }

            StoreResult.Value = Offset.Value + p;
        }

        public override string GetSummary() =>
            "Get random point in rect ring {InnerRect} {OuterRect} -> {StoreResult}";
    }
}
