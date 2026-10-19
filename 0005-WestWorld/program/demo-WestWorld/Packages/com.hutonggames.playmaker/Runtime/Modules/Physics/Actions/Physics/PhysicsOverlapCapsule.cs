
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PhysicsQueries)]
	[ConvertibleGroup("PhysicsOverlap")]
	[ActionDescription("Check the given capsule against the physics world and return all overlapping colliders.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics.OverlapCapsule.html")]
	public sealed class PhysicsOverlapCapsule : BaseAction
	{
		
		[Tooltip("The center of the sphere at the start of the capsule.")]
		[SerializeField]
		private Vector3Var _point0;
		
		[Tooltip("The center of the sphere at the end of the capsule.")]
		[SerializeField]
		private Vector3Var _point1;
		
		[Tooltip("The radius of the capsule.")]
		[SerializeField]
		private FloatVar _radius;
		
		[Tooltip("A Layer mask defines which layers of colliders to include in the query.")]
		[SerializeField, DefaultValue("Physics.AllLayers")]
		private LayerMaskVar _layerMask;
		
		[Tooltip("Store the result in Collider List variable.")]
		[SerializeField]
		[WriteOnly]
		private ColliderListRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_point0, _point1, _radius, _layerMask, _result);
		}
		
		public override void Execute()
		{
			// ReSharper disable once Unity.PreferNonAllocApi
			_result.Values = Physics.OverlapCapsule(_point0.Value, _point1.Value, _radius.Value, _layerMask.Value);
		}
		
		public override string GetSummary()
		{
			return "Overlap capsule {_point0} {_point1} {_radius} {_layerMask} -> {_result}";
		}
	}
}
