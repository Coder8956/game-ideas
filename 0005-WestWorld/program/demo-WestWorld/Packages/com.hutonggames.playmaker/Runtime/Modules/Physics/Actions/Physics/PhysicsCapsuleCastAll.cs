using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PhysicsQueries)]
	[ActionDescription("Like Physics.CapsuleCast, but returns all hits.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics.CapsuleCastAll.html")]
	public sealed class PhysicsCapsuleCastAll : BaseAction
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
		
		[Tooltip("Store the result in RaycastHit List variable.")]
		[SerializeField]
		[WriteOnly]
		private RaycastHitListRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_start, _end, _radius, _direction, _maxDistance, _layerMask, _result);
		}
		
		public override void Execute()
		{
			_result.Values = Physics.CapsuleCastAll(_start.Value, _end.Value, _radius.Value, _direction.Value, _maxDistance.Value, _layerMask.Value, _hitTriggers);
		}
		
		public override string GetSummary()
		{
			return "Capsule Cast All from {_start} to {_end} in {_direction} using {_radius} {_maxDistance} {_layerMask} {_result:output}";
		}
	}
}
