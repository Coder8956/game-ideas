/*
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.RaycastHit)]
	[ActionDescription("The barycentric coordinate of the triangle we hit.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RaycastHit-barycentricCoordinate.html")]
	public sealed class RaycastHitSetBarycentricCoordinate : BaseAction
	{
		
		[Tooltip("The RaycastHit")]
		[SerializeField]
		private RaycastHitRef _raycastHit;
		
		[Tooltip("Set RaycastHit Barycentric Coordinate")]
		[SerializeField]
		private Vector3Var _setBarycentricCoordinate;
		
		public override bool CanExecute()
		{
			return CheckParameters(_raycastHit, _setBarycentricCoordinate);
		}
		
		public override void Execute()
		{
			var value = _raycastHit.Value;
			value.barycentricCoordinate = _setBarycentricCoordinate.Value;
			_raycastHit.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_raycastHit} Barycentric Coordinate to {_setBarycentricCoordinate}";
		}
	}
}
*/