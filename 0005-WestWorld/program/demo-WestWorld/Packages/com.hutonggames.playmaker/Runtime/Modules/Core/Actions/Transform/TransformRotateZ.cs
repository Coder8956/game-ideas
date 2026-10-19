using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ConvertibleGroup("Rotate")]
    [ActionDescription("Rotate a transform around the z axis.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform.Rotate.html")]
    public class TransformRotateZ : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Transform to rotate.")]
        public TransformVar Transform;
        
        [Tooltip("Rotate the Transform by this amount around z." + Strings.PerSecondNote)]
        public FloatVar RotateZ;

        [Tooltip("<b>Self</b>: the movement is applied relative to the transform's local axes." +
                 "<br/><b>World</b>: the movement is applied relative to the world coordinate system.")]
        public SpaceVar RelativeTo;
        
        public override bool CanUsePerSecond => true;
        
        public override bool CanExecute() => CheckParameters(RotateZ, Transform);
        
        public override void Execute()
        {
            var transform = Transform.Value;
            if (transform == null) return;
            transform.Rotate(0,0,RotateZ.Value * PerSecond, RelativeTo.Value);
        }
        
        public override string GetSummary() => "Rotate {Transform} {RotateZ} degrees around Z {PerSecond}";
    }
}