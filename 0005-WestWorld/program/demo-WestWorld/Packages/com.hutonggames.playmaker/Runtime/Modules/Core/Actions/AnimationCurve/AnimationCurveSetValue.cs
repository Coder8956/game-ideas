using System;
using UnityEngine;
using UnityEngine.Serialization;


namespace HutongGames.PlayMaker.Actions
{
	
	
    [Serializable]
    [ActionCategory(Category.AnimationCurve)]
    [ActionDescription("Sets the value of an AnimationCurve variable.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/AnimationCurve.html")]
    public sealed class AnimationCurveSetValue : BaseAction
    {
		
        [FormerlySerializedAs("_animationCurve")]
        [DefaultName("AnimationCurve")]
        [Tooltip("The AnimationCurve.")]
        [SerializeField, WriteOnly]
        private AnimationCurveRef _variable;
		
        [Tooltip("The value to set.")]
        [SerializeField]
        private AnimationCurveVar _value;
		
        public override bool CanExecute() => CheckParameters(_variable, _value);

        public override void Execute() => _variable.Value = _value.Value;

        public override string GetSummary()
        {
            return "Set {_variable} to {_value}";
        }
    }
}
