
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animator)]
	[ActionDescription("Creates a crossfade from the current state to any other state using normalized times." +
	                   "\n\nWhen you specify a state name, or the string used to generate a hash, " +
	                   "it should include the name of the parent layer. For example, if you have a Run state " +
	                   "in the Base Layer, the name is Base Layer.Run.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animator.CrossFade.html")]
	public sealed class AnimatorCrossFade : BaseAction
	{
		
		[Tooltip("The Animator.")]
		[SerializeField]
		private AnimatorVar _animator;
		
		[Tooltip("State Name.")]
		[SerializeField]
		private StringVar _stateName;
		
		[Tooltip("Normalized Transition Duration.")]
		[SerializeField]
		private FloatVar _normalizedTransitionDuration;
		
		[Tooltip("Layer.")]
		[SerializeField, DefaultValue(-1)]
		private IntegerVar _layer;
		
		[Tooltip("Normalized Time Offset.")]
		[SerializeField, DefaultValue("float.NegativeInfinity")]
		private FloatVar _normalizedTimeOffset;
		
		[Tooltip("Normalized Transition Time.")]
		[SerializeField, DefaultValue(0f)]
		private FloatVar _normalizedTransitionTime;
		
		private string _cachedStateName;
		private int _stateNameHash;

		public override bool CanExecute()
		{
			return CheckParameters(_animator, _stateName, _normalizedTransitionDuration, _layer, _normalizedTimeOffset, _normalizedTransitionTime);
		}
		
		public override void Execute()
		{
			UpdateCachedId();
			_animator.Value.CrossFade(_stateNameHash, _normalizedTransitionDuration.Value, _layer.Value, _normalizedTimeOffset.Value, _normalizedTransitionTime.Value);
		}
		
		private void UpdateCachedId()
		{
			if (_cachedStateName == _stateName.Value) return;
			_stateNameHash = Animator.StringToHash(_stateName.Value);
			_cachedStateName = _stateName.Value;
		}
		
		public override string GetSummary()
		{
			return "Cross fade {_animator} to {_stateName} duration {_normalizedTransitionDuration} layer {_layer} {_normalizedTimeOffset} {_normalizedTransitionTime}";
		}
	}
}
