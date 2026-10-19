
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animator)]
	[ActionDescription("Plays a state.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animator.Play.html")]
	public sealed class AnimatorPlay : BaseAction
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
		
		[Tooltip("The time offset between zero and one.")]
		[SerializeField, DefaultValue("float.NegativeInfinity")]
		private FloatVar _normalizedTime;

		private string _cachedStateName;
		private int _stateNameHash;
		
		public override bool CanExecute()
		{
			return CheckParameters(_animator, _stateName, _layer, _normalizedTime);
		}
		
		public override void Execute()
		{
			UpdateCachedId();
			_animator.Value.Play(_stateNameHash, _layer.Value, _normalizedTime.Value);
		}
		
		private void UpdateCachedId()
		{
			if (_cachedStateName == _stateName.Value) return;
			_stateNameHash = Animator.StringToHash(_stateName.Value);
			_cachedStateName = _stateName.Value;
		}
		
		public override string GetSummary() =>
			"Play {_animator} {_stateName} " +
			(_layer.IsNotDefault(-1) ? "layer {_layer}" : "") +
			(_normalizedTime.IsNotDefault(float.NegativeInfinity) ? " at {_normalizedTime}" : "");
	}
}
