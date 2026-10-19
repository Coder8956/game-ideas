
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RaycastHit2D)]
	[ActionDescription("The Transform of the object that was hit.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RaycastHit2D-transform.html")]
	public sealed class RaycastHit2DGetTransform : BaseAction
	{
		
		[Tooltip("The RaycastHit2D")]
		[SerializeField]
		private RaycastHit2DRef _raycastHit2D;
		
		[Tooltip("Get RaycastHit2D Transform")]
		[SerializeField]
		[WriteOnly]
		private TransformRef _getTransform;
		
		public override bool CanExecute()
		{
			return CheckParameters(_raycastHit2D, _getTransform);
		}
		
		public override void Execute()
		{
			_getTransform.Value = _raycastHit2D.Value.transform;
		}
		
		public override string GetSummary()
		{
			return "Get {_raycastHit2D} transform -> {_getTransform}";
		}
	}
}
