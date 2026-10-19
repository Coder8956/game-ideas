
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ControllerColliderHit)]
	[ActionDescription("The rigidbody that was hit by the controller.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ControllerColliderHit-rigidbody.html")]
	public sealed class ControllerColliderHitGetRigidbody : BaseAction
	{
		
		[Tooltip("The ControllerColliderHit")]
		[SerializeField]
		private ControllerColliderHitRef _controllerColliderHit;
		
		[Tooltip("Get ControllerColliderHit Rigidbody")]
		[SerializeField]
		[WriteOnly]
		private RigidbodyRef _getRigidbody;
		
		public override bool CanExecute()
		{
			return CheckParameters(_controllerColliderHit, _getRigidbody);
		}
		
		public override void Execute()
		{
			_getRigidbody.Value = _controllerColliderHit.Value.rigidbody;
		}
		
		public override string GetSummary()
		{
			return "Get {_controllerColliderHit} rigidbody -> {_getRigidbody}";
		}
	}
}
