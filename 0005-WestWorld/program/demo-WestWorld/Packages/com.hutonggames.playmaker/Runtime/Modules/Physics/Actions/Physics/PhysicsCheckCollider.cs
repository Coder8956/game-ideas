using JetBrains.Annotations;
using System;
using System.Text;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PhysicsQueries)]
	[ConvertibleGroup("PhysicsOverlap")]
	[ActionDescription("Checks whether the given BoxCollider, SphereCollider, or CapsuleCollider overlaps any other colliders.")]
	public sealed class PhysicsCheckCollider : BaseAction
	{
		private Collider[] _debugOverlaps = Array.Empty<Collider>();
		
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
		
		[OptionalField]
		[Tooltip("Event to send if overlaps are found.")]
		[SerializeField]
		private EventRef _hasOverlaps;
		
		[OptionalField]
		[Tooltip("Event to send if no overlaps are found.")]
		[SerializeField]
		private EventRef _noOverlaps;
		
		[OptionalField]
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider, _layerMask);
		}

#if UNITY_EDITOR
		public override bool HasDebugInfo => true;
#endif
		
		public override void Execute()
		{
			var collider = _collider.Value;
			if (collider == null)
			{
				_debugOverlaps = Array.Empty<Collider>();
				SetOutputs(false);
				return;
			}
			
			if (!TryCheckCollider(collider, out var overlaps))
			{
				_debugOverlaps = Array.Empty<Collider>();
				LogError($"PhysicsCheckCollider does not support collider type {collider.GetType().Name}.");
				return;
			}
			
			_debugOverlaps = overlaps;
			SetOutputs(overlaps.Length > 0);
		}
		
		public override string GetSummary()
		{
			if (_hasOverlaps.IsNone && _noOverlaps.IsNone)
			{
				return "Check {_collider} -> {_result}";
			}
			
			var summary = _hasOverlaps.IsNone && _noOverlaps.IsSet
				? "If {_collider} has no overlaps {_noOverlaps}"
				: "If {_collider} has overlaps {_hasOverlaps}" +
				  (_noOverlaps.IsNone ? string.Empty : " else {_noOverlaps}");
			
			if (_result.IsAssigned)
			{
				summary += " -> {_result}";
			}
			
			return summary;
		}
		
		public override string ErrorCheck() =>
			!HasOutputs ? "Action does not send any events or store the result!" : null;

#if UNITY_EDITOR
		public override string GetDebugInfo()
		{
			var collider = _collider.Value;
			if (collider == null)
			{
				return "Collider: null\nOverlaps: 0";
			}

			var debugInfo = new StringBuilder();
			debugInfo.Append("Collider: ")
			         .Append(collider.name)
			         .Append(" (")
			         .Append(collider.GetType().Name)
			         .Append(")\nOverlaps: ")
			         .Append(_debugOverlaps.Length);

			for (var i = 0; i < _debugOverlaps.Length; i++)
			{
				var hit = _debugOverlaps[i];
				if (hit == null) continue;

				debugInfo.Append("\n- ")
				         .Append(hit.name)
				         .Append(" (")
				         .Append(hit.GetType().Name)
				         .Append(')');
			}

			return debugInfo.ToString();
		}
#endif
		
		private bool HasOutputs => _hasOverlaps.IsSet || _noOverlaps.IsSet || _result.IsAssigned;
		
		private void SetOutputs(bool hasOverlaps)
		{
			if (_result.IsAssigned)
			{
				_result.Value = hasOverlaps;
			}
			
			SendEvent(hasOverlaps ? _hasOverlaps : _noOverlaps);
		}
		
		private bool TryCheckCollider(Collider collider, out Collider[] overlaps)
		{
			return PhysicsColliderQueries.TryOverlapCollider(collider, _layerMask.Value, _hitTriggers, out overlaps);
		}
	}
}
