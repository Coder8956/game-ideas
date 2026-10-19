
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Physics2DQueries)]
	[ActionDescription("Cast a 3D ray against the Colliders in the Scene returning the first Collider along the ray.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics2D.GetRayIntersection.html")]
	public sealed class Physics2DGetRayIntersection : BaseAction
	{
		[Tooltip("The 3D ray defining origin and direction to test.")]
		[SerializeField]
		private RayRef _ray;

		[Tooltip("The maximum distance the ray should check for collisions.")]
		[DefaultValue("~MathfInfinity")]
		[SerializeField]
		private FloatVar _distance;
		
		[Tooltip("Filter to detect Colliders only on certain layers.")]
		[DefaultValue("Physics.DefaultRaycastLayers")]
		[SerializeField]
		private LayerMaskVar _layerMask;
		
		[WriteOnly]
		[Tooltip("The GameObject hit by the raycast.")]
		[SerializeField, OptionalField]
		private GameObjectRef _gameObjectHit;
		
		[WriteOnly]
		[Tooltip("The result of the raycast.")]
		[SerializeField, OptionalField]
		private RaycastHit2DRef _hitInfo;
		
		public override bool CanExecute()
		{
			return CheckParameters(_ray, _distance, _layerMask);
		}
		
		public override void Execute()
		{
			_hitInfo.Value = Physics2D.GetRayIntersection(_ray.Value, _distance.Value, _layerMask.Value);
			_gameObjectHit.Value = _hitInfo.Value.collider ? _hitInfo.Value.collider.gameObject : null;
		}
		
		public override string GetSummary()
		{
			return "Physics2D Get Ray Cast Intersection: {_ray} {_distance} {_hitInfo:output} {_gameObjectHit:output} " +
			       (_layerMask.Value != Physics.DefaultRaycastLayers ? "Mask {LayerMask} " : "");
		}
	}
}
