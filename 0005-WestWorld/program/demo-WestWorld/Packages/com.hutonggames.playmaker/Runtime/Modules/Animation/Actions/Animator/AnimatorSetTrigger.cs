using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.Animator)]
	[ConvertibleGroup("AnimatorParameter")]
	[ActionDescription("Sets the the given trigger parameter.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animator.SetTrigger.html")]
	public sealed class AnimatorSetTrigger : BaseAnimatorParameterAction
	{
		
		public override void Execute()
		{
			base.Execute();
			_animator.Value.SetTrigger(ParameterID);
		}
		
		public override string GetSummary() => "Set {_animator} trigger {_name} ";
	}
}
