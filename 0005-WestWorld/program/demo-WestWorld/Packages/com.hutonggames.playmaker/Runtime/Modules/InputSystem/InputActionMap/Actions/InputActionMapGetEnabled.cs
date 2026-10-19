#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.InputActionMap
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.InputActionMap)]
	[ActionDescription("Whether any action in the map is currently enabled.")]
	[HelpURL(HelpUrls.InputActionMap +"#UnityEngine_InputSystem_InputActionMap_enabled")]
	public sealed class InputActionMapGetEnabled : BaseAction
	{
		
		[Tooltip("The InputActionMap")]
		[SerializeField]
		private InputActionMapRef _inputActionMap;
		
		[Tooltip("Get InputActionMap Enabled")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getEnabled;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputActionMap, _getEnabled);
		}
		
		public override void Execute()
		{
			_getEnabled.Value = _inputActionMap.Value.enabled;
		}
		
		public override string GetSummary()
		{
			return "Get {_inputActionMap} Enabled -> {_getEnabled}";
		}
	}
}
#endif