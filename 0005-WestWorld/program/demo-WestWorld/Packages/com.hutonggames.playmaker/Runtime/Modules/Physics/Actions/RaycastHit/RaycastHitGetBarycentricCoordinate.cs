
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RaycastHit)]
	[ActionDescription("The barycentric coordinate of the triangle we hit.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RaycastHit-barycentricCoordinate.html")]
	public sealed class RaycastHitGetBarycentricCoordinate : BaseAction
	{
		
		[Tooltip("The RaycastHit")]
		[SerializeField]
		private RaycastHitRef _raycastHit;
		
		[Tooltip("Get RaycastHit Barycentric Coordinate")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getBarycentricCoordinate;
		
		public override bool CanExecute()
		{
			return CheckParameters(_raycastHit, _getBarycentricCoordinate);
		}
		
		public override void Execute()
		{
			_getBarycentricCoordinate.Value = _raycastHit.Value.barycentricCoordinate;
		}
		
		public override string GetSummary()
		{
			return "Get {_raycastHit} Barycentric Coordinate -> {_getBarycentricCoordinate}";
		}
	}
}
