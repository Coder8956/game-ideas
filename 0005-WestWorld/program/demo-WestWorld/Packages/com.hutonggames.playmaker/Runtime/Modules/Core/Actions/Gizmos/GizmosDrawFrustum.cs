
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Gizmos)]
	[ActionDescription("Draw a camera frustum using the currently set Gizmos. matrix for its location and rotation.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Gizmos.DrawFrustum.html")]
	public sealed class GizmosDrawFrustum : BaseAction
	{
		
		[Tooltip("The apex of the truncated pyramid.")]
		[SerializeField]
		private Vector3Var _center;
		
		[Tooltip("Vertical field of view (ie, the angle at the apex in degrees).")]
		[SerializeField]
		private FloatVar _fov;
		
		[Tooltip("Distance of the frustum's far plane.")]
		[SerializeField]
		private FloatVar _maxRange;
		
		[Tooltip("Distance of the frustum's near plane.")]
		[SerializeField]
		private FloatVar _minRange;
		
		[Tooltip("Width/height ratio.")]
		[SerializeField]
		private FloatVar _aspect;
		
		public override bool CanExecute() => CheckParameters(_center, _fov, _maxRange, _minRange, _aspect);

#if UNITY_EDITOR	

		public override bool HasGizmos => true;
		
		public override void OnDrawGizmosSelected()
		{
			Gizmos.DrawFrustum(_center.Value, _fov.Value, _maxRange.Value, _minRange.Value, _aspect.Value);
		}
#endif
		
		public override string GetSummary()
		{
			return "Draw Frustum: Center: {_center} Fov: {_fov} Far: {_maxRange} Near: {_minRange} Aspect: {_aspect} ";
		}
	}
}
