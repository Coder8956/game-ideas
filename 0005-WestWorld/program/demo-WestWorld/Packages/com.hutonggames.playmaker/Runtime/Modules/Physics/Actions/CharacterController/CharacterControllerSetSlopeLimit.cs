
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CharacterController)]
	[ActionDescription("The character controllers slope limit in degrees.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CharacterController-slopeLimit.html")]
	public sealed class CharacterControllerSetSlopeLimit : BaseAction
	{
		
		[Tooltip("The CharacterController")]
		[SerializeField, OwnerDefaultValue]
		private CharacterControllerVar _characterController;
		
		[Tooltip("Set CharacterController Slope Limit")]
		[SerializeField]
		private FloatVar _setSlopeLimit;
		
		public override bool CanExecute()
		{
			return CheckParameters(_characterController, _setSlopeLimit);
		}
		
		public override void Execute()
		{
			_characterController.Value.slopeLimit = _setSlopeLimit.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_characterController} slope limit to {_setSlopeLimit}";
		}
	}
}
