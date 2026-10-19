
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
	public sealed class CharacterControllerGetRadius : BaseAction
	{
		
		[Tooltip("The CharacterController")]
		[SerializeField, OwnerDefaultValue]
		private CharacterControllerVar _characterController;
		
		[Tooltip("Get CharacterController Radius")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getRadius;
		
		public override bool CanExecute()
		{
			return CheckParameters(_characterController, _getRadius);
		}
		
		public override void Execute()
		{
			_getRadius.Value = _characterController.Value.radius;
		}
		
		public override string GetSummary()
		{
			return "Get {_characterController} radius -> {_getRadius}";
		}
	}
}
