using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Transform)]
    [ActionDescription("Snap a Transform position to a pixel grid based on pixels per unit. By default, this is done in LateUpdate.")]
    public sealed class TransformSnapToPixelGrid : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.LateUpdate | UpdateMode.EveryFrame;

        [OwnerDefaultValue]
        [Tooltip("The Transform to snap.")]
        [SerializeField]
        private TransformVar _transform;

        [Tooltip("World or local space.")]
        [SerializeField]
        private SpaceVar _inSpace;

        [Tooltip("Pixels per unit used to calculate the snap size. For example, 16 pixels per unit snaps in steps of 1/16.")]
        [SerializeField, DefaultValue(16f)]
        private FloatVar _pixelsPerUnit;

        [Tooltip("Snap the X position.")]
        [SerializeField, DefaultValue(true)]
        private BoolVar _snapX;

        [Tooltip("Snap the Y position.")]
        [SerializeField, DefaultValue(true)]
        private BoolVar _snapY;

        [Tooltip("Snap the Z position.")]
        [SerializeField]
        private BoolVar _snapZ;

        public override bool CanExecute() => CheckParameters(_transform, _inSpace, _pixelsPerUnit, _snapX, _snapY, _snapZ);

        public override void Execute()
        {
            var transform = _transform.Value;
            if (transform == null) return;

            var pixelsPerUnit = _pixelsPerUnit.Value;
            if (pixelsPerUnit <= 0f) return;

            var unitsPerPixel = 1f / pixelsPerUnit;
            var position = _inSpace.Value == Space.World ? transform.position : transform.localPosition;

            if (_snapX.Value)
            {
                position.x = Snap.ToGrid(position.x, unitsPerPixel);
            }

            if (_snapY.Value)
            {
                position.y = Snap.ToGrid(position.y, unitsPerPixel);
            }

            if (_snapZ.Value)
            {
                position.z = Snap.ToGrid(position.z, unitsPerPixel);
            }

            if (_inSpace.Value == Space.World)
            {
                transform.position = position;
            }
            else
            {
                transform.localPosition = position;
            }
        }

        public override string GetSummary() =>
            "Snap {_transform} to pixel grid PPU: {_pixelsPerUnit} X: {_snapX} Y: {_snapY} Z: {_snapZ} ({_inSpace})";
    }
}
