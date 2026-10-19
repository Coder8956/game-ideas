using System;
using UnityEngine;
using Random = UnityEngine.Random;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.Animator)]
	[ConvertibleGroup("AnimatorParameter")]
	[ActionDescription("Periodically sets the given trigger parameter. " +
	                   "Useful to repeatedly set an idle trigger like Blink or Fidget")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animator.SetTrigger.html")]
	public sealed class AnimatorSetTriggerRepeated : BaseAnimatorParameterAction
	{
		public override UpdateMode RequiredUpdateModes => UpdateMode.EveryFrame;
		
		[Tooltip("The minimum delay between each trigger")]
		[SerializeField, DefaultValue(1f)]
		private FloatVar _minDelay;
		
		[Tooltip("The maximum delay between each trigger")]	
		[SerializeField, DefaultValue(1f)]
		private FloatVar _maxDelay;
		
		private float _elapsedTime;
		private float _triggerTime;
		private float _triggerStartTime;
		
		private float CurrentTime => InFixedUpdate ? Time.fixedTime : Time.time;
		
		public override void OnStart()
		{
			ResetTriggerTime();
		}

		private void ResetTriggerTime()
		{
			_elapsedTime = 0f;
			_triggerTime = Random.Range(_minDelay.Value, _maxDelay.Value);
			_triggerStartTime = CurrentTime;
		}

		public override void Execute()
		{
			base.Execute();
			
			_elapsedTime = Mathf.Max(0f, CurrentTime - _triggerStartTime);
			if (_elapsedTime < _triggerTime) return;
			
			_animator.Value.SetTrigger(ParameterID);
			ResetTriggerTime();
		}
		
		public override string GetSummary() => "Set {_animator} trigger {_name} min delay {_minDelay} max delay {_maxDelay} ";
	}
}
