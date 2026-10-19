
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animator)]
	[ConvertibleGroup("AnimatorParameter")]
	[ActionDescription("Get the value of the given integer parameter.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animator.GetInteger.html")]
	public sealed class AnimatorGetInteger : BaseAnimatorParameterAction
	{
		
		[Tooltip("Store the result in Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _result;
		
		public override bool CanExecute() => base.CanExecute() && CheckParameters(_result);
		
		public override void Execute()
		{
			base.Execute();
			_result.Value = _animator.Value.GetInteger(ParameterID);
		}
		
		public override string GetSummary() => "Get {_animator} integer {_name} -> {_result}";
	}
}
