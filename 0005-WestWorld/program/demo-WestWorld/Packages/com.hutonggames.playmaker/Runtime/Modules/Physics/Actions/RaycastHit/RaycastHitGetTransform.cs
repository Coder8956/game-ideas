
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RaycastHit)]
	[ActionDescription("The Transform of the rigidbody or collider that was hit.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RaycastHit-transform.html")]
	public sealed class RaycastHitGetTransform : BaseAction
	{
		
		[Tooltip("The RaycastHit")]
		[SerializeField]
		private RaycastHitRef _raycastHit;
		
		[Tooltip("Get RaycastHit Transform")]
		[SerializeField]
		[WriteOnly]
		private TransformRef _getTransform;
		
		public override bool CanExecute()
		{
			return CheckParameters(_raycastHit, _getTransform);
		}
		
		public override void Execute()
		{
			_getTransform.Value = _raycastHit.Value.transform;
		}
		
		public override string GetSummary()
		{
			return "Get {_raycastHit} Transform -> {_getTransform}";
		}
	}
}
