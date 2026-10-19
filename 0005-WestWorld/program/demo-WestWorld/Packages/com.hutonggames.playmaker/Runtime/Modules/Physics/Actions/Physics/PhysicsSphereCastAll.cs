
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PhysicsQueries)]
	[ActionDescription("Like Physics.SphereCast, but this function will return all hits the sphere sweep " +
		"intersects.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics.SphereCastAll.html")]
	public sealed class PhysicsSphereCastAll : BaseAction
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
		
		[Tooltip("Store the result in RaycastHit List variable.")]
		[SerializeField]
		[WriteOnly]
		private RaycastHitListRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_origin, _radius, _direction, _maxDistance, _layerMask, _result);
		}
		
		public override void Execute()
		{
			_result.Values = Physics.SphereCastAll(_origin.Value, _radius.Value, _direction.Value, _maxDistance.Value, _layerMask.Value, _hitTriggers);
		}
		
		public override string GetSummary()
		{
			return "Sphere Cast All from {_origin} in {_direction} using {_radius} {_maxDistance} {_layerMask} {_result:output}";
		}
	}
}
