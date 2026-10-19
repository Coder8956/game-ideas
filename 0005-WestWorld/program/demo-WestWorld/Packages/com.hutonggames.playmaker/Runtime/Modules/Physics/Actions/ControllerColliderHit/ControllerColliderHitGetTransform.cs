
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ControllerColliderHit)]
	[ActionDescription("The transform that was hit by the controller.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ControllerColliderHit-transform.html")]
	public sealed class ControllerColliderHitGetTransform : BaseAction
	{
		
		[Tooltip("The ControllerColliderHit")]
		[SerializeField]
		private ControllerColliderHitRef _controllerColliderHit;
		
		[Tooltip("Get ControllerColliderHit Transform")]
		[SerializeField]
		[WriteOnly]
		private TransformRef _getTransform;
		
		public override bool CanExecute()
		{
			return CheckParameters(_controllerColliderHit, _getTransform);
		}
		
		public override void Execute()
		{
			_getTransform.Value = _controllerColliderHit.Value.transform;
		}
		
		public override string GetSummary()
		{
			return "Get {_controllerColliderHit} transform -> {_getTransform}";
		}
	}
}
