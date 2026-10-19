
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CharacterController)]
	[ActionDescription("Was the CharacterController touching the ground during the last move?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CharacterController-isGrounded.html")]
	public sealed class CharacterControllerGetIsGrounded : BaseAction
	{
		
		[Tooltip("The CharacterController")]
		[SerializeField, OwnerDefaultValue]
		private CharacterControllerVar _characterController;
		
		[Tooltip("Get CharacterController Is Grounded")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getIsGrounded;
		
		public override bool CanExecute()
		{
			return CheckParameters(_characterController, _getIsGrounded);
		}
		
		public override void Execute()
		{
			_getIsGrounded.Value = _characterController.Value.isGrounded;
		}
		
		public override string GetSummary()
		{
			return "Get {_characterController} is grounded -> {_getIsGrounded}";
		}
	}
}
