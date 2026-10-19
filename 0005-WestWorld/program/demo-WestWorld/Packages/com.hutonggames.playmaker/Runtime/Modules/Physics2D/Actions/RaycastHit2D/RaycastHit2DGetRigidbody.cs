
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RaycastHit2D)]
	[ActionDescription("The Rigidbody2D attached to the object that was hit.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RaycastHit2D-rigidbody.html")]
	public sealed class RaycastHit2DGetRigidbody : BaseAction
	{
		
		[Tooltip("The RaycastHit2D")]
		[SerializeField]
		private RaycastHit2DRef _raycastHit2D;
		
		[Tooltip("Get RaycastHit2D Rigidbody")]
		[SerializeField]
		[WriteOnly]
		private Rigidbody2DRef _getRigidbody;
		
		public override bool CanExecute()
		{
			return CheckParameters(_raycastHit2D, _getRigidbody);
		}
		
		public override void Execute()
		{
			_getRigidbody.Value = _raycastHit2D.Value.rigidbody;
		}
		
		public override string GetSummary()
		{
			return "Get {_raycastHit2D} rigidbody -> {_getRigidbody}";
		}
	}
}
