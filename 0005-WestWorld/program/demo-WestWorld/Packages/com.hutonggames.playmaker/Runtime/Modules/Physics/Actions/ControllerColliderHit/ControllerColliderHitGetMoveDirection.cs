
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ControllerColliderHit)]
	[ActionDescription("The direction the CharacterController was moving in when the collision occured.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ControllerColliderHit-moveDirection.html" +
		"")]
	public sealed class ControllerColliderHitGetMoveDirection : BaseAction
	{
		
		[Tooltip("The ControllerColliderHit")]
		[SerializeField]
		private ControllerColliderHitRef _controllerColliderHit;
		
		[Tooltip("Get ControllerColliderHit Move Direction")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getMoveDirection;
		
		public override bool CanExecute()
		{
			return CheckParameters(_controllerColliderHit, _getMoveDirection);
		}
		
		public override void Execute()
		{
			_getMoveDirection.Value = _controllerColliderHit.Value.moveDirection;
		}
		
		public override string GetSummary()
		{
			return "Get {_controllerColliderHit} moveDirection -> {_getMoveDirection}";
		}
	}
}
