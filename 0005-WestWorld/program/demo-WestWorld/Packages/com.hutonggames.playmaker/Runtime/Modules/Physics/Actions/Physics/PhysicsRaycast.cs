/* DEPRECATED
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.PhysicsQueries)]
	[ActionDescription("Casts a ray, from point origin, in direction direction, of length maxDistance, ag" +
		"ainst all colliders in the Scene.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics.Raycast.html")]
	public sealed class PhysicsRaycast : BaseAction
	{
		
		[Tooltip("The starting point of the ray in world coordinates.")]
		[SerializeField]
		private Vector3Var _origin;
		
		[Tooltip("The direction of the ray.")]
		[SerializeField]
		private Vector3Var _direction;
		
		[Tooltip("The max distance the ray should check for collisions.")]
		[SerializeField]
		private FloatVar _maxDistance;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_origin, _direction, _maxDistance, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Physics.Raycast(UnityEngine.Vector3, UnityEngine.Vector3, System.Single);
			_result.Value = Physics.Raycast(_origin.Value, _direction.Value, _maxDistance.Value);
		}
		
		public override string GetSummary()
		{
			return "Physics Raycast: {_origin} {_direction} {_maxDistance} -> {_result}";
		}
	}
}
*/