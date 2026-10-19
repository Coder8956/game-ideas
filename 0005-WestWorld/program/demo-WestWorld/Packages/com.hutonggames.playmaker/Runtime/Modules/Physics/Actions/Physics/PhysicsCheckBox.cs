
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PhysicsQueries)]
	[ConvertibleGroup("PhysicsOverlap")]
	[ActionDescription("Check whether the given box overlaps with other colliders or not.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics.CheckBox.html")]
	public sealed class PhysicsCheckBox : BaseAction
	{
		
		[Tooltip("Center of the box.")]
		[SerializeField]
		private Vector3Var _center;
		
		[Tooltip("Half the size of the box in each dimension.")]
		[SerializeField]
		private Vector3Var _halfExtents;
		
		[Tooltip("Rotation of the box.")]
		[SerializeField]
		[DefaultValue("Quaternion.identity")]
		private QuaternionVar _orientation;
		
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
			return CheckParameters(_center, _halfExtents, _orientation, _layerMask);
		}
		
		public override void Execute()
		{
			var hasOverlaps = Physics.CheckBox(_center.Value, _halfExtents.Value, _orientation.Value, _layerMask.Value, _hitTriggers);
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
				return "Check box {_center} {_halfExtents} {_orientation} {_layerMask} -> {_result}";
			}
			
			var summary = _hasOverlaps.IsNone && _noOverlaps.IsSet
				? "If box {_center} {_halfExtents} {_orientation} {_layerMask} has no overlaps {_noOverlaps}"
				: "If box {_center} {_halfExtents} {_orientation} {_layerMask} has overlaps {_hasOverlaps}" +
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
