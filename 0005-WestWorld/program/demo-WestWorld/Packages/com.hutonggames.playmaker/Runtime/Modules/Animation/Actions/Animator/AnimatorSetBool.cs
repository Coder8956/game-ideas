
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animator)]
	[ConvertibleGroup("AnimatorParameter")]
	[ActionDescription("Sets the value of the given boolean parameter.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animator.SetBool.html")]
	public sealed class AnimatorSetBool : BaseAnimatorParameterAction
	{
		[Tooltip("The new parameter value.")]
		[SerializeField]
		private BoolVar _value;

		[HideIf("IsConstant")]
		[Tooltip("If true, set the parameter to the opposite value.")]
		[SerializeField]
		private BoolVar _invert;
		
		private bool IsConstant => _value.IsConstantValue;
		
		public override bool CanExecute() => base.CanExecute() && CheckParameters(_value, _invert);

		public override void Execute()
		{
			base.Execute();
			_animator.Value.SetBool(ParameterID, _invert.Value ? !_value.Value : _value.Value);
		}
		
		public override string GetSummary() =>
			"Set {_animator} bool {_name} to {_value} "
			+ (_invert.Value ? " (Inverted)" : "");
	}
}
