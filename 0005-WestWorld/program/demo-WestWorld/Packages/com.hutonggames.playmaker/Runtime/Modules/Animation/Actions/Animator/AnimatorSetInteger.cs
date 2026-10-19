
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animator)]
	[ConvertibleGroup("AnimatorParameter")]
	[ActionDescription("Sets the value of the given integer parameter.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animator.SetInteger.html")]
	public sealed class AnimatorSetInteger : BaseAnimatorParameterAction
	{
		[Tooltip("The new parameter value.")]
		[SerializeField]
		private IntegerVar _value;
		
		public override bool CanExecute() => base.CanExecute() && CheckParameters(_value);
		
		public override void Execute()
		{
			base.Execute();
			_animator.Value.SetInteger(ParameterID, _value.Value);
		}
		
		public override string GetSummary() => "Set {_animator} integer {_name} to {_value} ";
	}
}
