
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CharacterController)]
	[ActionDescription("Determines whether other rigidbodies or character controllers collide with this c" +
		"haracter controller (by default this is always enabled).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CharacterController-detectCollisions.html")]
	public sealed class CharacterControllerSetDetectCollisions : BaseAction
	{
		
		[Tooltip("The CharacterController")]
		[SerializeField, OwnerDefaultValue]
		private CharacterControllerVar _characterController;
		
		[Tooltip("Set CharacterController Detect Collisions")]
		[SerializeField]
		private BoolVar _setDetectCollisions;
		
		public override bool CanExecute()
		{
			return CheckParameters(_characterController, _setDetectCollisions);
		}
		
		public override void Execute()
		{
			_characterController.Value.detectCollisions = _setDetectCollisions.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_characterController} detect collisions to {_setDetectCollisions}";
		}
	}
}
