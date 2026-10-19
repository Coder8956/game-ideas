
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CharacterController)]
	[ActionDescription("The height of the character\'s capsule.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CharacterController-height.html")]
	public sealed class CharacterControllerGetHeight : BaseAction
	{
		
		[Tooltip("The CharacterController")]
		[SerializeField, OwnerDefaultValue]
		private CharacterControllerVar _characterController;
		
		[Tooltip("Get CharacterController Height")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getHeight;
		
		public override bool CanExecute()
		{
			return CheckParameters(_characterController, _getHeight);
		}
		
		public override void Execute()
		{
			_getHeight.Value = _characterController.Value.height;
		}
		
		public override string GetSummary()
		{
			return "Get {_characterController} height -> {_getHeight}";
		}
	}
}
