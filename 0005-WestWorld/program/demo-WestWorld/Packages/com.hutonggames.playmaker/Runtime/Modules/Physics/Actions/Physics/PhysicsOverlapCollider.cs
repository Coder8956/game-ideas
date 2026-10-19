using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PhysicsQueries)]
	[ConvertibleGroup("PhysicsOverlap")]
	[ActionDescription("Gets all colliders overlapping the given BoxCollider, SphereCollider, or CapsuleCollider.")]
	public sealed class PhysicsOverlapCollider : BaseAction
	{
		
		[Tooltip("Collider whose shape will be used for the overlap query. Supports BoxCollider, SphereCollider, and CapsuleCollider.")]
		[SerializeField]
		private ColliderVar _collider;
		
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
		
		[OptionalField]
		[Tooltip("Store the number of results in Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _resultCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider, _layerMask, _result);
		}
		
		public override void Execute()
		{
			var collider = _collider.Value;
			if (collider == null)
			{
				_result.Values = Array.Empty<Collider>();
				SetResultCount(0);
				return;
			}
			
			Collider[] hits;
			switch (collider)
			{
				case BoxCollider boxCollider:
					hits = OverlapBox(boxCollider);
					break;
				
				case SphereCollider sphereCollider:
					hits = OverlapSphere(sphereCollider);
					break;
				
				case CapsuleCollider capsuleCollider:
					hits = OverlapCapsule(capsuleCollider);
					break;
				
				default:
					LogError($"PhysicsOverlapCollider does not support collider type {collider.GetType().Name}.");
					_result.Values = Array.Empty<Collider>();
					SetResultCount(0);
					return;
			}
			
			var filteredHits = FilterSelf(collider, hits);
			_result.Values = filteredHits;
			SetResultCount(filteredHits.Length);
		}
		
		public override string GetSummary()
		{
			return "Overlap collider {_collider} {_layerMask} -> {_result}";
		}
		
		private Collider[] OverlapBox(BoxCollider boxCollider)
		{
			var transform = boxCollider.transform;
			var center = transform.TransformPoint(boxCollider.center);
			var halfExtents = Vector3.Scale(boxCollider.size * 0.5f, Abs(transform.lossyScale));
			
			// ReSharper disable once Unity.PreferNonAllocApi
			return Physics.OverlapBox(center, halfExtents, transform.rotation, _layerMask.Value, _hitTriggers);
		}
		
		private Collider[] OverlapSphere(SphereCollider sphereCollider)
		{
			var transform = sphereCollider.transform;
			var center = transform.TransformPoint(sphereCollider.center);
			var radius = sphereCollider.radius * MaxComponent(Abs(transform.lossyScale));
			
			// ReSharper disable once Unity.PreferNonAllocApi
			return Physics.OverlapSphere(center, radius, _layerMask.Value, _hitTriggers);
		}
		
		private Collider[] OverlapCapsule(CapsuleCollider capsuleCollider)
		{
			var transform = capsuleCollider.transform;
			var center = transform.TransformPoint(capsuleCollider.center);
			var absScale = Abs(transform.lossyScale);
			
			Vector3 axis;
			float heightScale;
			float radiusScale;
			switch (capsuleCollider.direction)
			{
				case 0:
					axis = transform.right;
					heightScale = absScale.x;
					radiusScale = Mathf.Max(absScale.y, absScale.z);
					break;
				
				case 2:
					axis = transform.forward;
					heightScale = absScale.z;
					radiusScale = Mathf.Max(absScale.x, absScale.y);
					break;
				
				default:
					axis = transform.up;
					heightScale = absScale.y;
					radiusScale = Mathf.Max(absScale.x, absScale.z);
					break;
			}
			
			var radius = capsuleCollider.radius * radiusScale;
			var height = Mathf.Max(capsuleCollider.height * heightScale, radius * 2f);
			var pointOffset = Mathf.Max(0f, height * 0.5f - radius);
			var point0 = center + axis * pointOffset;
			var point1 = center - axis * pointOffset;
			
			// ReSharper disable once Unity.PreferNonAllocApi
			return Physics.OverlapCapsule(point0, point1, radius, _layerMask.Value, _hitTriggers);
		}
		
		private static Collider[] FilterSelf(Collider collider, IEnumerable<Collider> hits)
		{
			var filteredHits = new List<Collider>();
			foreach (var hit in hits)
			{
				if (hit == null || hit == collider) continue;
				filteredHits.Add(hit);
			}
			
			return filteredHits.ToArray();
		}
		
		private void SetResultCount(int count)
		{
			if (_resultCount.IsAssigned)
			{
				_resultCount.Value = count;
			}
		}
		
		private static Vector3 Abs(Vector3 value)
		{
			return new Vector3(Mathf.Abs(value.x), Mathf.Abs(value.y), Mathf.Abs(value.z));
		}
		
		private static float MaxComponent(Vector3 value)
		{
			return Mathf.Max(value.x, Mathf.Max(value.y, value.z));
		}
	}
}
