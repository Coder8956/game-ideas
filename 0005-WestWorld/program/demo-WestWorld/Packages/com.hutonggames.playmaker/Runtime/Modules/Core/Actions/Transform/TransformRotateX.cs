using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ConvertibleGroup("Rotate")]
    [ActionDescription("Rotate a transform around the x axis.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform.Rotate.html")]
    public class TransformRotateX : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Transform to rotate.")]
        public TransformVar Transform;
        
        [Tooltip("Rotate the Transform by this amount around x." + Strings.PerSecondNote)]
        public FloatVar RotateX;

        [Tooltip("<b>Self</b>: the movement is applied relative to the transform's local axes." +
                 "<br/><b>World</b>: the movement is applied relative to the world coordinate system.")]
        public SpaceVar RelativeTo;
        
        public override bool CanUsePerSecond => true;
        
        public override bool CanExecute() => CheckParameters(RotateX, Transform);

        public override void Execute()
        {
            var transform = Transform.Value;
            if (transform == null) return;
            transform.Rotate(RotateX.Value * PerSecond, 0,0, RelativeTo.Value);
        }
        
        public override string GetSummary() => "Rotate {Transform} {RotateX} degrees around X {PerSecond}";
    }
}