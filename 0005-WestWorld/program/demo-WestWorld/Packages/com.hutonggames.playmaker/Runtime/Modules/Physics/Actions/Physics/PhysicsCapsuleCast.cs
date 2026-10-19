using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PhysicsQueries)]
	[ActionDescription("Performs a capsule cast between the start and end points in the given direction. Optionally stores whether anything was hit and information about the hit.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics.CapsuleCast.html")]
	public sealed class PhysicsCapsuleCast : BaseAction
	{
		
		[Tooltip("The center of the sphere at the start of the capsule.")]
		[SerializeField]
		private Vector3Var _start;
		
		[Tooltip("The center of the sphere at the end of the capsule.")]
		[SerializeField]
		private Vector3Var _end;
		
		[Tooltip("The radius of the capsule.")]
		[SerializeField]
		private FloatVar _radius;
		
		[Tooltip("The direction in which to cast the capsule.")]
		[SerializeField]
		private Vector3Var _direction;
		
		[Tooltip("The maximum distance the capsule should check for collisions. Set to -1 for infinity.")]
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
		
		[Tooltip("Store hit information from the capsule cast.")]
		[SerializeField]
		[OptionalField]
		[WriteOnly]
		private RaycastHitRef _hitInfo;
		
		public override bool CanExecute()
		{
			return CheckParameters(_start, _end, _radius, _direction, _maxDistance, _layerMask) &&
			       (_result.HasValue() || _hitInfo.HasValue());
		}
		
		public override void Execute()
		{
			var didHit = Physics.CapsuleCast(_start.Value, _end.Value, _radius.Value, _direction.Value, out var hitInfo, _maxDistance.Value, _layerMask.Value, _hitTriggers);
			
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
			return "Capsule Cast from {_start} to {_end} in {_direction} using {_radius} {_maxDistance} {_layerMask} {_result:output} {_hitInfo:output}";
		}
	}
}
