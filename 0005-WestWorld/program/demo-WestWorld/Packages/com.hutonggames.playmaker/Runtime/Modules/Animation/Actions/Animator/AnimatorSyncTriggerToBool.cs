
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animator)]
	[ActionDescription("Sets a trigger parameter based on a bool variable.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Animator.SetTrigger.html")]
	public sealed class AnimatorSyncTriggerToBool : BaseAction
	{
		public enum TriggerCondition
		{
			Changes,
			ChangesToTrue,
			ChangesToFalse,
			IsTrue,
			IsFalse
		}
		
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

		[Tooltip("The Animator to sync.")]
		[SerializeField]
		private AnimatorVar _animator;

		[Tooltip("The trigger parameter name.")]
		[AnimatorParameter(AnimatorControllerParameterType.Trigger)]
		[SerializeField]
		private StringVar _triggerName;
		
		[Tooltip("The bool variable to check for changes.")]
		[SerializeField]
		private BoolRef _boolVariable;
		
		[Tooltip("When to set the trigger.")]
		[SerializeField]
		private TriggerCondition _triggerCondition;
		
		private bool _currentValue;
		
		public override bool CanExecute() => CheckParameters(_animator, _triggerName, _boolVariable);

		public override void OnStart()
		{
			_currentValue = _boolVariable.Value;
		}

		public override void Execute()
		{
			switch (_triggerCondition)
			{
				case TriggerCondition.IsTrue:
					SetTrigger(_boolVariable.Value);
					break;
				case TriggerCondition.IsFalse:
					SetTrigger(!_boolVariable.Value);
					break;
				case TriggerCondition.ChangesToTrue:
					SetTrigger(_boolVariable.Value && !_currentValue);
					break;
				case TriggerCondition.ChangesToFalse:
					SetTrigger(!_boolVariable.Value && _currentValue);
					break;
				case TriggerCondition.Changes:
					SetTrigger(_boolVariable.Value != _currentValue);
					break;
			}

			_currentValue = _boolVariable.Value;
		}
		
		private void SetTrigger(bool value)
		{
			if (value)
			{
				_animator.Value.SetTrigger(_triggerName.Value);
			}
		}
		
		
		public override string GetSummary() => 
			"Set {_animator} trigger {_triggerName} when {_boolVariable} {_triggerCondition}";
	}
}
