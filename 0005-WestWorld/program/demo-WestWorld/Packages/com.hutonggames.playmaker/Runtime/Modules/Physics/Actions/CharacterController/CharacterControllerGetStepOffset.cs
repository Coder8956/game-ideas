
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
	public sealed class CharacterControllerGetStepOffset : BaseAction
	{
		
		[Tooltip("The CharacterController")]
		[SerializeField, OwnerDefaultValue]
		private CharacterControllerVar _characterController;
		
		[Tooltip("Get CharacterController Step Offset")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getStepOffset;
		
		public override bool CanExecute()
		{
			return CheckParameters(_characterController, _getStepOffset);
		}
		
		public override void Execute()
		{
			_getStepOffset.Value = _characterController.Value.stepOffset;
		}
		
		public override string GetSummary()
		{
			return "Get {_characterController} step offset -> {_getStepOffset}";
		}
	}
}
