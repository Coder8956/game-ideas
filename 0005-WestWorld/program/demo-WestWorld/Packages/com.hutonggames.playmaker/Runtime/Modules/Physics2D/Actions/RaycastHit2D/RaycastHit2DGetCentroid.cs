
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RaycastHit2D)]
	[ActionDescription("The centroid of the primitive used to perform the cast.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RaycastHit2D-centroid.html")]
	public sealed class RaycastHit2DGetCentroid : BaseAction
	{
		
		[Tooltip("The RaycastHit2D")]
		[SerializeField]
		private RaycastHit2DRef _raycastHit2D;
		
		[Tooltip("Get RaycastHit2D Centroid")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getCentroid;
		
		public override bool CanExecute()
		{
			return CheckParameters(_raycastHit2D, _getCentroid);
		}
		
		public override void Execute()
		{
			_getCentroid.Value = _raycastHit2D.Value.centroid;
		}
		
		public override string GetSummary()
		{
			return "Get {_raycastHit2D} centroid -> {_getCentroid}";
		}
	}
}
