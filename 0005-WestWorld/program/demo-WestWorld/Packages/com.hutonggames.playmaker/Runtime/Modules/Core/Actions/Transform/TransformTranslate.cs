using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ConvertibleGroup("Translate")]
    [ActionDescription("Moves the transform in the direction and distance of translation.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform.Translate.html")]
    public class TransformTranslate : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Transform to translate.")]
        public TransformVar Transform;
        
        [Tooltip("Move the Transform by this amount in x, y, and z." + Strings.PerSecondNote)]
        public Vector3Var Translation;

        [Tooltip("<b>Self</b>: the movement is applied relative to the transform's local axes." +
                 "<br/><b>World</b>: the movement is applied relative to the world coordinate system.")]
        public SpaceVar RelativeTo;

        public override bool CanUsePerSecond => true;
        
        public override bool CanExecute() => CheckParameters(Translation, Transform);

        public override void Execute()
        {
            var transform = Transform.Value;
            if (transform == null) return;
            
            transform.Translate(Translation.Value * PerSecond, RelativeTo.Value);
        }
        
        public override string GetSummary() => "Translate {Transform} by {Translation} in {RelativeTo} space {PerSecond}";
    }
}
