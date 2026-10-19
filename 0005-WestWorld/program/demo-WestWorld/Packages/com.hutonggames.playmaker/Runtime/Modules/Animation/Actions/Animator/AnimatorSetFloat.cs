
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animator)]
	[ConvertibleGroup("AnimatorParameter")]
	[ActionDescription("Send float values to the Animator to affect transitions.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animator.SetFloat.html")]
	public sealed class AnimatorSetFloat : BaseAnimatorParameterAction
	{
		[Tooltip("The new parameter value.")]
		[SerializeField]
		private FloatVar _value;
		
		public override bool CanExecute() => base.CanExecute() && CheckParameters(_value);

		public override void Execute()
		{
			base.Execute();
			_animator.Value.SetFloat(ParameterID, _value.Value);
		}
		
		public override string GetSummary() => "Set {_animator} float {_name} to {_value} ";
	}
}
