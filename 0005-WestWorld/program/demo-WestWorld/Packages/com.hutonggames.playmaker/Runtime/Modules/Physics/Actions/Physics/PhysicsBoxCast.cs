
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PhysicsQueries)]
	[ActionDescription("Performs a box cast from the box center in the given direction. Optionally stores whether anything was hit and information about the hit.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics.BoxCast.html")]
	public sealed class PhysicsBoxCast : BaseAction
	{
		
		[Tooltip("Center of the box.")]
		[SerializeField]
		private Vector3Var _center;
		
		[Tooltip("Half the size of the box in each dimension.")]
		[SerializeField]
		private Vector3Var _halfExtents;
		
		[Tooltip("The direction in which to cast the box.")]
		[SerializeField]
		private Vector3Var _direction;
		
		[Tooltip("Rotation of the box.")]
		[SerializeField]
		[DefaultValue("Quaternion.identity")]
		private QuaternionVar _orientation;
		
		[Tooltip("The maximum distance the box should check for collisions. Set to -1 for infinity.")]
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

		[Tooltip("Store hit information from the box cast.")]
		[SerializeField]
		[OptionalField]
		[WriteOnly]
		private RaycastHitRef _hitInfo;
		
		public override bool CanExecute()
		{
			return CheckParameters(_center, _halfExtents, _direction, _orientation, _maxDistance, _layerMask) &&
			       (_result.HasValue() || _hitInfo.HasValue());
		}
		
		public override void Execute()
		{
			var maxDistance = _maxDistance.Value;
			var didHit = Physics.BoxCast(_center.Value, _halfExtents.Value, _direction.Value, out var hitInfo, _orientation.Value, maxDistance, _layerMask.Value, _hitTriggers);
			
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
			return "Box Cast from {_center} in {_direction} using {_halfExtents} {_orientation} {_maxDistance} {_layerMask} {_result:output} {_hitInfo:output}";
		}
	}
}
