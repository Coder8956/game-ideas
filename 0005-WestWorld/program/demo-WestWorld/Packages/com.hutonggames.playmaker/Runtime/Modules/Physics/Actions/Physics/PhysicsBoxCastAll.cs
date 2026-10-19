
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PhysicsQueries)]
	[ActionDescription("Like Physics.BoxCast, but returns all hits.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics.BoxCastAll.html")]
	public sealed class PhysicsBoxCastAll : BaseAction
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
		
		[Tooltip("Store the result in RaycastHit List variable.")]
		[SerializeField]
		[WriteOnly]
		private RaycastHitListRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_center, _halfExtents, _direction, _orientation, _maxDistance, _layerMask, _result);
		}
		
		public override void Execute()
		{
			_result.Values = Physics.BoxCastAll(_center.Value, _halfExtents.Value, _direction.Value, _orientation.Value, _maxDistance.Value, _layerMask.Value, _hitTriggers);
		}
		
		public override string GetSummary()
		{
			return "Box Cast All from {_center} in {_direction} using {_halfExtents} {_orientation} {_maxDistance} {_layerMask} {_result:output}";
		}
	}
}
