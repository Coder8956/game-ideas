
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CharacterController)]
	[ActionDescription("The character\'s collision skin width.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CharacterController-skinWidth.html")]
	public sealed class CharacterControllerGetSkinWidth : BaseAction
	{
		
		[Tooltip("The CharacterController")]
		[SerializeField, OwnerDefaultValue]
		private CharacterControllerVar _characterController;
		
		[Tooltip("Get CharacterController Skin Width")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getSkinWidth;
		
		public override bool CanExecute()
		{
			return CheckParameters(_characterController, _getSkinWidth);
		}
		
		public override void Execute()
		{
			_getSkinWidth.Value = _characterController.Value.skinWidth;
		}
		
		public override string GetSummary()
		{
			return "Get {_characterController} skin width -> {_getSkinWidth}";
		}
	}
}
