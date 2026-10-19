#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.InputActionMap
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.InputActionMap)]
	[ActionDescription("Disable all the actions in the map.")]
	[HelpURL(HelpUrls.InputActionMap +"#UnityEngine_InputSystem_InputActionMap_Disable")]
	public sealed class InputActionMapDisable : BaseAction
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
			//UnityEngine.InputSystem.InputActionMap.Disable();
			_inputActionMap.Value.Disable();
		}
		
		public override string GetSummary()
		{
			return "Disable {_inputActionMap}";
		}
	}
}

#endif
