
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animator)]
	[ConvertibleGroup("AnimatorParameter")]
	[ActionDescription("Get the value of the given float parameter.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animator.GetFloat.html")]
	public sealed class AnimatorGetFloat : BaseAnimatorParameterAction
	{
		[Tooltip("Store the result in Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute() => base.CanExecute() && CheckParameters(_result);

		public override void Execute()
		{
			base.Execute();
			_result.Value = _animator.Value.GetFloat(ParameterID);
		}

		public override string GetSummary() => "Get {_animator} float {_name} -> {_result}";
	}
}
