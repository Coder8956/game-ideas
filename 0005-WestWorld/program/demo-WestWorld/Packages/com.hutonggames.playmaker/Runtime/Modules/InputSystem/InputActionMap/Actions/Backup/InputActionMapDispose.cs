/* NOT USED
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.InputActionMap
{
	
	
	[Serializable]
	[ActionCategory(Category.InputSystem.InputActionMap)]
	[ActionDescription("Release internal state held on to by the action map.")]
	[HelpURL(HelpUrls.InputActionMap +"#UnityEngine_InputSystem_InputActionMap_Dispose")]
	public sealed class InputActionMapDispose : BaseAction
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
			//UnityEngine.InputSystem.InputActionMap.Dispose();
			_inputActionMap.Value.Dispose();
		}
		
		public override string GetSummary()
		{
			return "{_inputActionMap} dispose ";
		}
	}
}
*/