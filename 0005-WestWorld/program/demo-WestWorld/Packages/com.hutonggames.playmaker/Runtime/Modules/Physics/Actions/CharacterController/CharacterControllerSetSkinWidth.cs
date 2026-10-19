
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
	public sealed class CharacterControllerSetSkinWidth : BaseAction
	{
		
		[Tooltip("The CharacterController")]
		[SerializeField, OwnerDefaultValue]
		private CharacterControllerVar _characterController;
		
		[Tooltip("Set CharacterController Skin Width")]
		[SerializeField]
		private FloatVar _setSkinWidth;
		
		public override bool CanExecute()
		{
			return CheckParameters(_characterController, _setSkinWidth);
		}
		
		public override void Execute()
		{
			_characterController.Value.skinWidth = _setSkinWidth.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_characterController} skin width to {_setSkinWidth}";
		}
	}
}
