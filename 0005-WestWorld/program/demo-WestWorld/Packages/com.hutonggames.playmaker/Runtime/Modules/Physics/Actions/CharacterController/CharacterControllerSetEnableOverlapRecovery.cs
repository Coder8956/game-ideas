
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
	public sealed class CharacterControllerSetEnableOverlapRecovery : BaseAction
	{
		
		[Tooltip("The CharacterController")]
		[SerializeField, OwnerDefaultValue]
		private CharacterControllerVar _characterController;
		
		[Tooltip("Set CharacterController Enable Overlap Recovery")]
		[SerializeField]
		private BoolVar _setEnableOverlapRecovery;
		
		public override bool CanExecute()
		{
			return CheckParameters(_characterController, _setEnableOverlapRecovery);
		}
		
		public override void Execute()
		{
			_characterController.Value.enableOverlapRecovery = _setEnableOverlapRecovery.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_characterController} enable overlap recovery to {_setEnableOverlapRecovery}";
		}
	}
}
