#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.InputAction)]
	[ActionDescription("Get the name of the action.")]
	[HelpURL(HelpUrls.InputAction+"#UnityEngine_InputSystem_InputAction_name")]
	public sealed class InputActionGetName : BaseAction
	{
		
		[Tooltip("The InputAction")]
		[SerializeField]
		private InputActionReferenceVar _inputAction;
		
		[Tooltip("Plain-text name of the action.")]
		[SerializeField]
		[WriteOnly]
		private StringRef _getName;
		
		public override bool CanExecute() => CheckParameters(_inputAction, _getName);

		public override void Execute() => _getName.Value = GetActionName();

		private string GetActionName()
		{
			var reference = _inputAction.Value;
			var actionName = reference != null ? reference.action?.name : null;
			if (!string.IsNullOrEmpty(actionName))
			{
				return actionName;
			}

			var referenceName = reference != null ? reference.name : null;
			if (string.IsNullOrEmpty(referenceName))
			{
				return string.Empty;
			}

			var slashIndex = referenceName.LastIndexOf('/');
			return slashIndex >= 0 && slashIndex + 1 < referenceName.Length
				? referenceName.Substring(slashIndex + 1)
				: referenceName;
		}

		public override string GetSummary() => "Get {_inputAction} name -> {_getName}";
	}
}

#endif
