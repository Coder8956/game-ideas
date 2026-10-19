/* NOT USED
using System;
using UnityEngine;
using UnityEngine.InputSystem;


namespace HutongGames.PlayMaker.Actions.InputActionMap
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.InputActionMap)]
	[ActionDescription("Send an event when an action in the map changes its InputActionPhase.")]
	[HelpURL(HelpUrls.InputActionMap +"#UnityEngine_InputSystem_InputActionMap_actionTriggered")]
	public sealed class InputActionMapActionTriggered : BaseOnEventAction
	{
		
		[Tooltip("The InputActionMap")]
		[SerializeField]
		private InputActionMapRef _inputActionMap;
		
		[Tooltip("TODO: Add tooltip!")]
		[SerializeField]
		private EventRef _actionTriggered;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputActionMap);
		}
		
		public override void OnStart()
		{
			if (_inputActionMap.Value == null) return;
			_inputActionMap.Value.actionTriggered += OnActionTriggered;;
		}
		
		public override void OnStop()
		{
			if (_inputActionMap.Value == null) return;
			_inputActionMap.Value.actionTriggered -= OnActionTriggered;;
		}
		
		private void OnActionTriggered(InputAction.CallbackContext obj)
		{
			SendEvent(_actionTriggered);;
		}
	}
}
*/