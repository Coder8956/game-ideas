
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RaycastHit)]
	[ActionDescription("The Rigidbody of the collider that was hit. If the collider is not attached to a " +
		"rigidbody then it is null.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RaycastHit-rigidbody.html")]
	public sealed class RaycastHitGetRigidbody : BaseAction
	{
		
		[Tooltip("The RaycastHit")]
		[SerializeField]
		private RaycastHitRef _raycastHit;
		
		[Tooltip("Get RaycastHit Rigidbody")]
		[SerializeField]
		[WriteOnly]
		private RigidbodyRef _getRigidbody;
		
		public override bool CanExecute()
		{
			return CheckParameters(_raycastHit, _getRigidbody);
		}
		
		public override void Execute()
		{
			_getRigidbody.Value = _raycastHit.Value.rigidbody;
		}
		
		public override string GetSummary()
		{
			return "Get {_raycastHit} Rigidbody -> {_getRigidbody}";
		}
	}
}
