
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animator)]
	[ConvertibleGroup("AnimatorParameter")]
	[ActionDescription("Returns the value of the given boolean parameter.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animator.GetBool.html")]
	public sealed class AnimatorGetBool : BaseAnimatorParameterAction
	{
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute() => base.CanExecute() && CheckParameters(_result);

		public override void Execute()
		{
			base.Execute();
			_result.Value = _animator.Value.GetBool(ParameterID);
		}
		
		public override string GetSummary() => "Get {_animator} bool {_name} -> {_result}";
	}
}
