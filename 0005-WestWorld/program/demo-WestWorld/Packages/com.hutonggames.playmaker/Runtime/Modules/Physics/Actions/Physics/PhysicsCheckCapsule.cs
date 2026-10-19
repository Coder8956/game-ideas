
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PhysicsQueries)]
	[ConvertibleGroup("PhysicsOverlap")]
	[ActionDescription("Checks if any colliders overlap a capsule-shaped volume in world space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics.CheckCapsule.html")]
	public sealed class PhysicsCheckCapsule : BaseAction
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
		
		[Tooltip("A Layer mask that is used to selectively ignore colliders.")]
		[DefaultValue("Physics.DefaultRaycastLayers")]
		[SerializeField]
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
			return CheckParameters(_start, _end, _radius, _layerMask);
		}
		
		public override void Execute()
		{
			var hasOverlaps = Physics.CheckCapsule(_start.Value, _end.Value, _radius.Value, _layerMask.Value, _hitTriggers);
			if (_result.IsAssigned)
			{
				_result.Value = hasOverlaps;
			}
			
			SendEvent(hasOverlaps ? _hasOverlaps : _noOverlaps);
		}
		
		public override string GetSummary()
		{
			if (_hasOverlaps.IsNone && _noOverlaps.IsNone)
			{
				return "Check capsule {_start} {_end} {_radius} {_layerMask} -> {_result}";
			}
			
			var summary = _hasOverlaps.IsNone && _noOverlaps.IsSet
				? "If capsule {_start} {_end} {_radius} {_layerMask} has no overlaps {_noOverlaps}"
				: "If capsule {_start} {_end} {_radius} {_layerMask} has overlaps {_hasOverlaps}" +
				  (_noOverlaps.IsNone ? string.Empty : " else {_noOverlaps}");
			
			if (_result.IsAssigned)
			{
				summary += " -> {_result}";
			}
			
			return summary;
		}
		
		public override string ErrorCheck() =>
			!HasOutputs ? "Action does not send any events or store the result!" : null;
		
		private bool HasOutputs => _hasOverlaps.IsSet || _noOverlaps.IsSet || _result.IsAssigned;
	}
}
