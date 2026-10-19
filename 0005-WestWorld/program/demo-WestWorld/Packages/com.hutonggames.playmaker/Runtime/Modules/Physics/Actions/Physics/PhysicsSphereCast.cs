using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PhysicsQueries)]
	[ActionDescription("Performs a sphere cast from the origin in the given direction. Optionally stores whether anything was hit and information about the hit.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics.SphereCast.html")]
	public sealed class PhysicsSphereCast : BaseAction
	{
		
		[Tooltip("The center of the sphere at the start of the sweep.")]
		[SerializeField]
		private Vector3Var _origin;
		
		[Tooltip("The radius of the sphere.")]
		[SerializeField]
		private FloatVar _radius;
		
		[Tooltip("The direction in which to sweep the sphere.")]
		[SerializeField]
		private Vector3Var _direction;
		
		[Tooltip("The maximum distance the sphere should check for collisions. Set to -1 for infinity.")]
		[SerializeField]
		[DefaultValue("~MathfInfinity")]
		private FloatVar _maxDistance;
		
		[Tooltip("A Layer mask that is used to selectively ignore colliders when casting.")]
		[SerializeField]
		[DefaultValue("Physics.DefaultRaycastLayers")]
		private LayerMaskVar _layerMask;

		[Tooltip("Specifies whether this query should hit Triggers.")]
		[DefaultValue(QueryTriggerInteraction.UseGlobal)]
		[SerializeField]
		private QueryTriggerInteraction _hitTriggers;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[OptionalField]
		[WriteOnly]
		private BoolRef _result;
		
		[Tooltip("Store hit information from the sphere cast.")]
		[SerializeField]
		[OptionalField]
		[WriteOnly]
		private RaycastHitRef _hitInfo;
		
		public override bool CanExecute()
		{
			return CheckParameters(_origin, _radius, _direction, _maxDistance, _layerMask) &&
			       (_result.HasValue() || _hitInfo.HasValue());
		}
		
		public override void Execute()
		{
			var didHit = Physics.SphereCast(_origin.Value, _radius.Value, _direction.Value, out var hitInfo, _maxDistance.Value, _layerMask.Value, _hitTriggers);
			
			if (_result.HasValue())
			{
				_result.Value = didHit;
			}
			
			if (_hitInfo.HasValue())
			{
				_hitInfo.Value = hitInfo;
			}
		}
		
		public override string GetSummary()
		{
			return "Sphere Cast from {_origin} in {_direction} using {_radius} {_maxDistance} {_layerMask} {_result:output} {_hitInfo:output}";
		}
	}
}
