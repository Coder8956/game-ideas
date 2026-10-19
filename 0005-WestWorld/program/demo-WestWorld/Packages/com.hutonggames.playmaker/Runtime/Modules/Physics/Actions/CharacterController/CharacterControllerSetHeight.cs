
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
	public sealed class CharacterControllerSetHeight : BaseAction
	{
		
		[Tooltip("The CharacterController")]
		[SerializeField, OwnerDefaultValue]
		private CharacterControllerVar _characterController;
		
		[Tooltip("Set CharacterController Height")]
		[SerializeField]
		private FloatVar _setHeight;
		
		public override bool CanExecute()
		{
			return CheckParameters(_characterController, _setHeight);
		}
		
		public override void Execute()
		{
			_characterController.Value.height = _setHeight.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_characterController} height to {_setHeight}";
		}
	}
}
