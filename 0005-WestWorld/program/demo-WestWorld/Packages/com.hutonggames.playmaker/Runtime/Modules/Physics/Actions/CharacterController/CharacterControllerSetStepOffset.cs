
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CharacterController)]
	[ActionDescription("The character controllers step offset in meters.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CharacterController-stepOffset.html")]
	public sealed class CharacterControllerSetStepOffset : BaseAction
	{
		
		[Tooltip("The CharacterController")]
		[SerializeField, OwnerDefaultValue]
		private CharacterControllerVar _characterController;
		
		[Tooltip("Set CharacterController Step Offset")]
		[SerializeField]
		private FloatVar _setStepOffset;
		
		public override bool CanExecute()
		{
			return CheckParameters(_characterController, _setStepOffset);
		}
		
		public override void Execute()
		{
			_characterController.Value.stepOffset = _setStepOffset.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_characterController} step offset to {_setStepOffset}";
		}
	}
}
