
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CharacterController)]
	[ActionDescription("The radius of the character\'s capsule.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CharacterController-radius.html")]
	public sealed class CharacterControllerSetRadius : BaseAction
	{
		
		[Tooltip("The CharacterController")]
		[SerializeField, OwnerDefaultValue]
		private CharacterControllerVar _characterController;
		
		[Tooltip("Set CharacterController Radius")]
		[SerializeField]
		private FloatVar _setRadius;
		
		public override bool CanExecute()
		{
			return CheckParameters(_characterController, _setRadius);
		}
		
		public override void Execute()
		{
			_characterController.Value.radius = _setRadius.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_characterController} radius to {_setRadius}";
		}
	}
}
