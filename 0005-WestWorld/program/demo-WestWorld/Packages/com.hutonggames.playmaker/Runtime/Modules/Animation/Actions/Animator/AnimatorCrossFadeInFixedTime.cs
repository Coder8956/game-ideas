
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animator)]
	[ActionDescription("Creates a crossfade from the current state to any other state using times in seconds." +
	                   "\n\nWhen you specify a state name, or the string used to generate a hash, " +
	                   "it should include the name of the parent layer. For example, if you have a Run state " +
	                   "in the Base Layer, the name is Base Layer.Run.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animator.CrossFadeInFixedTime.html")]
	public sealed class AnimatorCrossFadeInFixedTime : BaseAction
	{
		
		[Tooltip("The Animator.")]
		[SerializeField]
		private AnimatorVar _animator;
		
		[Tooltip("State Name.")]
		[SerializeField]
		private StringVar _stateName;
		
		[Tooltip("Fixed Transition Duration.")]
		[SerializeField]
		private FloatVar _fixedTransitionDuration;
		
		[Tooltip("Layer.")]
		[SerializeField]
		private IntegerVar _layer;
		
		[Tooltip("Fixed Time Offset.")]
		[SerializeField]
		private FloatVar _fixedTimeOffset;
		
		[Tooltip("Normalized Transition Time.")]
		[SerializeField]
		private FloatVar _normalizedTransitionTime;
		
		private string _cachedStateName;
		private int _stateNameHash;
		public override bool CanExecute()
		{
			return CheckParameters(_animator, _stateName, _fixedTransitionDuration, _layer, _fixedTimeOffset, _normalizedTransitionTime);
		}
		
		public override void Execute()
		{
			UpdateCachedId();
			_animator.Value.CrossFadeInFixedTime(_stateNameHash, _fixedTransitionDuration.Value, _layer.Value, _fixedTimeOffset.Value, _normalizedTransitionTime.Value);
		}
		
		private void UpdateCachedId()
		{
			if (_cachedStateName == _stateName.Value) return;
			_stateNameHash = Animator.StringToHash(_stateName.Value);
			_cachedStateName = _stateName.Value;
		}
		
		public override string GetSummary()
		{
			return "Cross fade {_animator} to {_stateName} in fixed time {_fixedTransitionDuration} {_layer} {_fixedTimeOffset} {_normalizedTransitionTime}";
		}
	}
}
