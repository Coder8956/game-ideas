
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
	public sealed class AnimatorSetFloatWithDamping : BaseAnimatorParameterAction
	{
		
		[Tooltip("The new parameter value.")]
		[SerializeField]
		private FloatVar _value;
		
		[Tooltip("The damper total time.")]
		[SerializeField]
		private FloatVar _dampTime;
		
		public override bool CanExecute() => base.CanExecute() && CheckParameters(_value, _dampTime);

		public override void Execute()
		{
			base.Execute();
			_animator.Value.SetFloat(ParameterID, _value.Value, _dampTime.Value, Time.deltaTime);
		}
		
		public override string GetSummary()
		{
			return "Set {_animator} float {_name} to {_value} with damp time {_dampTime}";
		}
	}
}
