using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    public enum GridFitType { FixedSpacing, FitLength, RelativeSpacing }

    public enum GridAnchor
    {
        TopLeft, TopCenter, TopRight,
        MiddleLeft, Center, MiddleRight,
        BottomLeft, BottomCenter, BottomRight
    }

    public enum GridPlane { XY, XZ, YZ }

    [Serializable, PublicAPI]
    [ActionCategory(Category.Loop)]
    [ActionDescription("Loop in a 2D grid space.")]
    public class LoopGrid2D : BaseForEachAction
    {
        // ------------ Counts ------------
        [DefaultValue(3)]
        [Tooltip("Count in X (columns). Total cells = XCount * YCount.")]
        public IntegerVar XCount;

        [DefaultValue(3)]
        [Tooltip("Count in Y (rows). Total cells = XCount * YCount.")]
        public IntegerVar YCount;

        // ------------ Placement in 3D ------------
        [Tooltip("Grid origin point in 3D.")]
        public Vector3Var Origin;

        [Tooltip("Plane on which to project the grid (XY, XZ, or YZ).")]
        public GridPlane Plane = GridPlane.XZ;

        [Tooltip("Align the grid around the Origin (e.g., Center, TopLeft, BottomCenter).")]
        public GridAnchor Anchor = GridAnchor.Center;

        [ActionHeader("Padding")]
        [DefaultValue(0)]
        [Tooltip("Extra width added across the X span, distributed by Anchor.")]
        public FloatVar PaddingX;

        [DefaultValue(0)]
        [Tooltip("Extra height added across the Y span, distributed by Anchor.")]
        public FloatVar PaddingY;

        // ------------ Grid Fit (single mode for both axes) ------------
        [ActionHeader("Grid Fit")]
        [Tooltip("How to calculate spacing." +
                 "\nFixedSpacing: direct per-axis spacing." +
                 "\nFitLength: spacing derived from total length." +
                 "\nRelativeSpacing: spacing = Factor × CellSize.")]
        public GridFitType Fit = GridFitType.FixedSpacing;

        // ---- FixedSpacing (per-axis) ----
        [HideIf(nameof(HideSpacing))]
        [DefaultValue(1)]
        [Tooltip("Spacing between columns (X axis).")]
        public FloatVar XSpacing;

        [HideIf(nameof(HideSpacing))]
        [DefaultValue(1)]
        [Tooltip("Spacing between rows (Y axis).")]
        public FloatVar YSpacing;

        // ---- FitLength (per-axis) ----
        [HideIf(nameof(HideTotalLength))]
        [Tooltip("Total end-to-end X span (includes PaddingX).")]
        public FloatVar XTotalLength;

        [HideIf(nameof(HideTotalLength))]
        [Tooltip("Total end-to-end Y span (includes PaddingY).")]
        public FloatVar YTotalLength;

        // ---- RelativeSpacing (per-axis) ----
        [HideIf(nameof(HideFactor))]
        [DefaultValue(1)]
        [Tooltip("X spacing factor (spacing = XFactor × CellSizeX).")]
        public FloatVar XFactor;

        [HideIf(nameof(HideFactor))]
        [DefaultValue(1)]
        [Tooltip("Y spacing factor (spacing = YFactor × CellSizeY).")]
        public FloatVar YFactor;

        [HideIf(nameof(HideFactor))]
        [Tooltip("Optional known cell width.")]
        public FloatVar CellSizeX;

        [HideIf(nameof(HideFactor))]
        [Tooltip("Optional known cell height.")]
        public FloatVar CellSizeY;

        // ------------ Output ------------
        [ActionHeader("Output")]
        [Tooltip("Store the computed 3D position for the current cell.")]
        [OptionalField, WriteOnly]
        public Vector3Ref StorePosition;

        [Tooltip("Store current integer indices if needed.")]
        [OptionalField, WriteOnly]
        public IntegerRef StoreXIndex, StoreYIndex;

        // ------------ HideIf predicates (TRUE => hide) ------------
        public bool HideSpacing     => Fit != GridFitType.FixedSpacing;
        public bool HideTotalLength => Fit != GridFitType.FitLength;
        public bool HideFactor      => Fit != GridFitType.RelativeSpacing;

        // ------------ Internal cache ------------
        protected override int ItemCount => Mathf.Max(0, XCount.Value) * Mathf.Max(0, YCount.Value);

        [NonSerialized] private float _sx, _sy;          // resolved spacing X/Y (grid axes)
        [NonSerialized] private Vector2 _anchorOffset2D; // anchor offset in grid space (x,y)

        public override void OnStart()
        {
            CacheGridParameters();   // compute once before first EachAction
            base.OnStart();          // starts loop and calls EachAction(…)
        }

        private void CacheGridParameters()
        {
            var cols = Mathf.Max(1, XCount.Value);
            var rows = Mathf.Max(1, YCount.Value);

            _sx = ComputeAxisSpacing(Fit, XSpacing.Value, XTotalLength.Value, XFactor.Value, CellSizeX.Value, cols, PaddingX.Value);
            _sy = ComputeAxisSpacing(Fit, YSpacing.Value, YTotalLength.Value, YFactor.Value, CellSizeY.Value, rows, PaddingY.Value);

            // End-to-end extents for indices [0..count-1]; padding is added to the span.
            var width  = (cols > 1 ? _sx * (cols - 1) : 0f) + PaddingX.Value;
            var height = (rows > 1 ? _sy * (rows - 1) : 0f) + PaddingY.Value;

            _anchorOffset2D = ComputeAnchorOffset2D(Anchor, width, height);
        }

        public override void EachAction(int index)
        {
            if (ItemCount == 0) return;

            var cols = Mathf.Max(1, XCount.Value);
            var xIdx = index % cols;
            var yIdx = index / cols;

            // Position in 2D grid space (X-right, Y-up in grid space)
            var gx = xIdx * _sx;
            var gy = yIdx * _sy;
            var p2 = new Vector2(gx, gy) - _anchorOffset2D;

            // Project onto the chosen plane
            var pos3 = Vector3.zero;
            var o = Origin.Value;
            pos3 = Plane switch
            {
                GridPlane.XY => new Vector3(o.x + p2.x, o.y + p2.y, o.z),
                GridPlane.XZ => new Vector3(o.x + p2.x, o.y, o.z + p2.y),
                GridPlane.YZ => new Vector3(o.x, o.y + p2.x, o.z + p2.y),
                _ => pos3
            };

            StorePosition.Value = pos3;

            if (StoreXIndex.IsAssigned) StoreXIndex.Value = xIdx;
            if (StoreYIndex.IsAssigned) StoreYIndex.Value = yIdx;
        }

        public override string GetSummary()
        {
            return "Grid {XCount} × {YCount} on {Plane} @ {Anchor} ({Fit})";
        }

        // ------------ Helpers ------------
        private static float ComputeAxisSpacing(
            GridFitType fit,
            float fixedSpacing,
            float totalLength,
            float factor,
            float cellSize,
            int count,
            float padding // per-axis
        )
        {
            switch (fit)
            {
                case GridFitType.FixedSpacing:
                    return Mathf.Max(0f, fixedSpacing);

                case GridFitType.FitLength:
                {
                    if (count <= 1) return 0f; // single cell has no gaps
                    var usable = Mathf.Max(0f, totalLength - padding);
                    return usable / (count - 1); // even gaps including both ends
                }

                case GridFitType.RelativeSpacing:
                    return Mathf.Max(0f, factor * cellSize);

                default:
                    return fixedSpacing;
            }
        }

        private static Vector2 ComputeAnchorOffset2D(GridAnchor anchor, float width, float height)
        {
            float ox = 0f, oy = 0f;

            switch (anchor)
            {
                case GridAnchor.TopLeft:        ox = 0f;          oy = 0f;          break;
                case GridAnchor.TopCenter:      ox = 0.5f * width;oy = 0f;          break;
                case GridAnchor.TopRight:       ox = width;       oy = 0f;          break;
                case GridAnchor.MiddleLeft:     ox = 0f;          oy = 0.5f * height;break;
                case GridAnchor.Center:         ox = 0.5f * width;oy = 0.5f * height;break;
                case GridAnchor.MiddleRight:    ox = width;       oy = 0.5f * height;break;
                case GridAnchor.BottomLeft:     ox = 0f;          oy = height;      break;
                case GridAnchor.BottomCenter:   ox = 0.5f * width;oy = height;      break;
                case GridAnchor.BottomRight:    ox = width;       oy = height;      break;
            }

            return new Vector2(ox, oy);
        }
    }
}
