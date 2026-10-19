/*
#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.InputActionMap
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.InputActionMap)]
	[ActionDescription("Name of the action map.")]
	[HelpURL(HelpUrls.InputActionMap +"#UnityEngine_InputSystem_InputActionMap_name")]
	public sealed class InputActionMapGetName : BaseAction
	{
		
		[Tooltip("The InputActionMap")]
		[SerializeField]
		private InputActionMapRef _inputActionMap;
		
		[Tooltip("Get InputActionMap Name")]
		[SerializeField]
		[WriteOnly]
		private StringRef _getName;
		
		public override bool CanExecute()
		{
			return CheckParameters(_inputActionMap, _getName);
		}
		
		public override void Execute()
		{
			_getName.Value = _inputActionMap.Value.name;
		}
		
		public override string GetSummary()
		{
			return "Get {_inputActionMap} name -> {_getName}";
		}
	}
}
#endif
*/