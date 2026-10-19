#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.InputAction)]
	[ActionDescription("Get the completion percentage of the timeout (if any) running on the current interaction.")]
	[HelpURL(HelpUrls.InputAction+"#UnityEngine_InputSystem_InputAction_GetTimeoutCompletionPercentage")]
	public sealed class InputActionGetTimeoutCompletionPercentage : BaseAction
	{
		
		[Tooltip("The InputAction whose timeout progress is read." + Strings.InputActionEnabledNote)]
		[SerializeField]
		private InputActionReferenceVar _inputAction;
		
		[Tooltip("A value >= 0 (no progress) and <= 1 (finished) indicating the level of completion of the currently running timeout.")]
		[SerializeField, WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute() => CheckParameters(_inputAction, _result);

		public override void Execute() => _result.Value = _inputAction.Value.action?.GetTimeoutCompletionPercentage() ?? 0;

		public override string GetSummary() => "Get {_inputAction} timeout completion -> {_result}";
	}
}

#endif
