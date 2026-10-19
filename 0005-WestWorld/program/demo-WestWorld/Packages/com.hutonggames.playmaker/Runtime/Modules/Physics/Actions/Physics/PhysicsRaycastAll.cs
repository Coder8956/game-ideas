
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PhysicsQueries)]
	[ActionDescription("Casts a ray through the Scene and returns all hits. Note that order of the results " +
		"is undefined.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics.RaycastAll.html")]
	public sealed class PhysicsRaycastAll : BaseAction
	{
		
		[Tooltip("The starting point of the ray in world coordinates.")]
		[SerializeField]
		private Vector3Var _origin;
		
		[Tooltip("The direction of the ray.")]
		[SerializeField]
		private Vector3Var _direction;
		
		[Tooltip("The max distance the rayhit is allowed to be from the start of the ray.")]
		[SerializeField]
		[DefaultValue("~MathfInfinity")]
		private FloatVar _maxDistance;
		
		[Tooltip("A Layer mask that is used to selectively ignore colliders when casting a ray.")]
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
			return CheckParameters(_origin, _direction, _maxDistance, _layerMask, _result);
		}
		
		public override void Execute()
		{
			_result.Values = Physics.RaycastAll(_origin.Value, _direction.Value, _maxDistance.Value, _layerMask.Value, _hitTriggers);
		}
		
		public override string GetSummary()
		{
			return "Raycast All from {_origin} in {_direction} using {_maxDistance} {_layerMask} {_result:output}";
		}
	}
}
