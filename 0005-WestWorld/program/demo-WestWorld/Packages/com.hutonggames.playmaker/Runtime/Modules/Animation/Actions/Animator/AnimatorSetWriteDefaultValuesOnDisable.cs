
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animator)]
	[ActionDescription("Specifies whether playable graph values are reset or preserved when the Animator " +
		"is disabled.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animator-writeDefaultValuesOnDisable.html")]
	public sealed class AnimatorSetWriteDefaultValuesOnDisable : BaseAction
	{
		
		[Tooltip("The Animator")]
		[SerializeField]
		private AnimatorVar _animator;
		
		[Tooltip("Set Animator Write Default Values On Disable")]
		[SerializeField]
		private BoolVar _setWriteDefaultValuesOnDisable;
		
		public override bool CanExecute()
		{
			return CheckParameters(_animator, _setWriteDefaultValuesOnDisable);
		}
		
		public override void Execute()
		{
			_animator.Value.writeDefaultValuesOnDisable = _setWriteDefaultValuesOnDisable.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_animator} write default values on disable to {_setWriteDefaultValuesOnDisable}";
		}
	}
}
