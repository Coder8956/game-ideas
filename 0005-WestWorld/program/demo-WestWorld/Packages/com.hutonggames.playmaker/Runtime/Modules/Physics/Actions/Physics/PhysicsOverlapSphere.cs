
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PhysicsQueries)]
	[ConvertibleGroup("PhysicsOverlap")]
	[ActionDescription("Computes and stores colliders touching or inside the sphere.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics.OverlapSphere.html")]
	public sealed class PhysicsOverlapSphere : BaseAction
	{
		
		[Tooltip("Center of the sphere.")]
		[SerializeField]
		private Vector3Var _position;
		
		[Tooltip("Radius of the sphere.")]
		[SerializeField]
		private FloatVar _radius;
		
		[Tooltip("A Layer mask defines which layers of colliders to include in the query.")]
		[SerializeField, DefaultValue("Physics.AllLayers")]
		private LayerMaskVar _layerMask;
		
		[Tooltip("Specifies whether this query should hit Triggers.")]
		[DefaultValue(QueryTriggerInteraction.UseGlobal)]
		[SerializeField]
		private QueryTriggerInteraction _hitTriggers;
		
		[Tooltip("Store the result in Collider List variable.")]
		[SerializeField]
		[WriteOnly]
		private ColliderListRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_position, _radius, _layerMask, _result);
		}
		
		public override void Execute()
		{
			// ReSharper disable once Unity.PreferNonAllocApi
			_result.Values = Physics.OverlapSphere(_position.Value, _radius.Value, _layerMask.Value, _hitTriggers);
		}
		
		public override string GetSummary()
		{
			return "Overlap sphere {_position} {_radius} {_layerMask} -> {_result}";
		}
	}
}
