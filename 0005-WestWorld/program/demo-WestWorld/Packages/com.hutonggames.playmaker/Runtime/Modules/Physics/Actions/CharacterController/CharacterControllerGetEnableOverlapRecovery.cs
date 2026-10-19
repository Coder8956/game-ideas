
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CharacterController)]
	[ActionDescription("Enables or disables overlap recovery. Enables or disables overlap recovery. Used " +
		"to depenetrate character controllers from static objects when an overlap is detected.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CharacterController-enableOverlapRecovery.html")]
	public sealed class CharacterControllerGetEnableOverlapRecovery : BaseAction
	{
		
		[Tooltip("The CharacterController")]
		[SerializeField, OwnerDefaultValue]
		private CharacterControllerVar _characterController;
		
		[Tooltip("Get CharacterController Enable Overlap Recovery")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getEnableOverlapRecovery;
		
		public override bool CanExecute()
		{
			return CheckParameters(_characterController, _getEnableOverlapRecovery);
		}
		
		public override void Execute()
		{
			_getEnableOverlapRecovery.Value = _characterController.Value.enableOverlapRecovery;
		}
		
		public override string GetSummary()
		{
			return "Get {_characterController} enable overlap recovery -> {_getEnableOverlapRecovery}";
		}
	}
}
