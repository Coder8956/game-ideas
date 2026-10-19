
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CharacterController)]
	[ActionDescription("The current relative velocity of the Character (see notes).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CharacterController-velocity.html")]
	public sealed class CharacterControllerGetVelocity : BaseAction
	{
		
		[Tooltip("The CharacterController")]
		[SerializeField, OwnerDefaultValue]
		private CharacterControllerVar _characterController;
		
		[Tooltip("Get CharacterController Velocity")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getVelocity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_characterController, _getVelocity);
		}
		
		public override void Execute()
		{
			_getVelocity.Value = _characterController.Value.velocity;
		}
		
		public override string GetSummary()
		{
			return "Get {_characterController} velocity -> {_getVelocity}";
		}
	}
}
