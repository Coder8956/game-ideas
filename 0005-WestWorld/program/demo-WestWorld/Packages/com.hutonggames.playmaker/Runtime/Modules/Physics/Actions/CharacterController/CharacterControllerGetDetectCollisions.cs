
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
	public sealed class CharacterControllerGetDetectCollisions : BaseAction
	{
		
		[Tooltip("The CharacterController")]
		[SerializeField, OwnerDefaultValue]
		private CharacterControllerVar _characterController;
		
		[Tooltip("Get CharacterController Detect Collisions")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getDetectCollisions;
		
		public override bool CanExecute()
		{
			return CheckParameters(_characterController, _getDetectCollisions);
		}
		
		public override void Execute()
		{
			_getDetectCollisions.Value = _characterController.Value.detectCollisions;
		}
		
		public override string GetSummary()
		{
			return "Get {_characterController} detect collisions -> {_getDetectCollisions}";
		}
	}
}
