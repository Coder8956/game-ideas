
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animator)]
	[ActionDescription("Plays a state.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animator.PlayInFixedTime.html")]
	public sealed class AnimatorPlayInFixedTime : BaseAction
	{
		
		[Tooltip("The Animator.")]
		[SerializeField]
		private AnimatorVar _animator;
		
		[Tooltip("The state name.")]
		[SerializeField]
		private StringVar _stateName;
		
		[Tooltip("The layer index. If layer is -1, it plays the first state with the given state name or hash.")]
		[SerializeField, DefaultValue(-1)]
		private IntegerVar _layer;
		
		[Tooltip("The time offset (in seconds).")]
		[SerializeField, DefaultValue("float.NegativeInfinity")]
		private FloatVar _fixedTime;
		
		private string _cachedStateName;
		private int _stateNameHash;
		
		public override bool CanExecute()
		{
			return CheckParameters(_animator, _stateName, _layer, _fixedTime);
		}
		
		public override void Execute()
		{
			UpdateCachedId();
			_animator.Value.PlayInFixedTime(_stateName.Value, _layer.Value, _fixedTime.Value);
		}
		
		private void UpdateCachedId()
		{
			if (_cachedStateName == _stateName.Value) return;
			_stateNameHash = Animator.StringToHash(_stateName.Value);
			_cachedStateName = _stateName.Value;
		}
		
		public override string GetSummary() =>
			"Play {_animator} {_stateName} at fixed time {_fixedTime} " +
			(_layer.IsNotDefault(-1) ? "layer {_layer}" : "");
	}
}
