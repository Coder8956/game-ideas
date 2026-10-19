#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;
using UnityEngine.InputSystem;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.InputAction)]
	[ActionDescription("Event that is triggered when the action has been started but then canceled before being fully performed.")]
	[HelpURL(HelpUrls.InputAction+"#UnityEngine_InputSystem_InputAction_canceled")]
	public sealed class InputActionCanceled : BaseOnEventAction
	{
		
		[Tooltip("The InputAction to listen to." + Strings.InputActionEnabledNote)]
		[SerializeField]
		private InputActionReferenceVar _inputAction;
		
		[Tooltip("Event to send when the input action has been canceled.")]
		[SerializeField]
		private EventRef _canceled;
		
		private InputAction _runtimeAction;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputAction);
		}
		
		public override void OnStart()
		{
			_runtimeAction = _inputAction.Value.action;
			if (_runtimeAction == null) return;
			
			_runtimeAction.canceled += OnCanceled;;
		}
		
		public override void OnStop()
		{
			if (_runtimeAction == null) return;
			
			_runtimeAction.canceled -= OnCanceled;
			_runtimeAction = null;
		}
		
		private void OnCanceled(InputAction.CallbackContext obj)
		{
			SendEvent(_canceled);;
		}

		public override string GetSummary() => "If {_inputAction} canceled {_canceled}";
	}
}

#endif
