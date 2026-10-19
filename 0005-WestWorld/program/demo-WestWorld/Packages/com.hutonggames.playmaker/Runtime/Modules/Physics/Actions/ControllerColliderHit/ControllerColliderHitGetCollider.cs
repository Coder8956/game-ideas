
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ControllerColliderHit)]
	[ActionDescription("The collider that was hit by the controller.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ControllerColliderHit-collider.html")]
	public sealed class ControllerColliderHitGetCollider : BaseAction
	{
		
		[Tooltip("The ControllerColliderHit")]
		[SerializeField]
		private ControllerColliderHitRef _controllerColliderHit;
		
		[Tooltip("Get ControllerColliderHit Collider")]
		[SerializeField]
		[WriteOnly]
		private ColliderVar _getCollider;
		
		public override bool CanExecute()
		{
			return CheckParameters(_controllerColliderHit, _getCollider);
		}
		
		public override void Execute()
		{
			_getCollider.Value = _controllerColliderHit.Value.collider;
		}
		
		public override string GetSummary()
		{
			return "Get {_controllerColliderHit} collider -> {_getCollider}";
		}
	}
}
