
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CharacterController)]
	[ActionDescription("What part of the capsule collided with the environment during the last CharacterC" +
		"ontroller.Move call.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CharacterController-collisionFlags.html")]
	public sealed class CharacterControllerGetCollisionFlags : BaseAction
	{
		
		[Tooltip("The CharacterController")]
		[SerializeField, OwnerDefaultValue]
		private CharacterControllerVar _characterController;
		
		[Tooltip("Get CharacterController Collision Flags")]
		[SerializeField]
		[WriteOnly]
		private CollisionFlagsRef _getCollisionFlags;
		
		public override bool CanExecute()
		{
			return CheckParameters(_characterController, _getCollisionFlags);
		}
		
		public override void Execute()
		{
			_getCollisionFlags.Value = _characterController.Value.collisionFlags;
		}
		
		public override string GetSummary()
		{
			return "Get {_characterController} collision flags -> {_getCollisionFlags}";
		}
	}
}
