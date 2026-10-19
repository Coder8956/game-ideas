
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
	public sealed class CharacterControllerGetSlopeLimit : BaseAction
	{
		
		[Tooltip("The CharacterController")]
		[SerializeField, OwnerDefaultValue]
		private CharacterControllerVar _characterController;
		
		[Tooltip("Get CharacterController Slope Limit")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getSlopeLimit;
		
		public override bool CanExecute()
		{
			return CheckParameters(_characterController, _getSlopeLimit);
		}
		
		public override void Execute()
		{
			_getSlopeLimit.Value = _characterController.Value.slopeLimit;
		}
		
		public override string GetSummary()
		{
			return "Get {_characterController} slope limit -> {_getSlopeLimit}";
		}
	}
}
