#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.InputActionMap
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.InputActionMap)]
	[ActionDescription("Enable all the actions in the map.")]
	[HelpURL(HelpUrls.InputActionMap +"#UnityEngine_InputSystem_InputActionMap_Enable")]
	public sealed class InputActionMapEnable : BaseAction
	{
		
		[Tooltip("The InputActionMap.")]
		[SerializeField]
		private InputActionMapRef _inputActionMap;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputActionMap);
		}
		
		public override void Execute()
		{
			//UnityEngine.InputSystem.InputActionMap.Enable();
			_inputActionMap.Value.Enable();
		}
		
		public override string GetSummary()
		{
			return "Enable {_inputActionMap}";
		}
	}
}

#endif
