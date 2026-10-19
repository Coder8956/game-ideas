
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_ToggleGroup)]
	[ActionDescription("Switch all toggles off.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-ToggleGroup.html")]
	public sealed class ToggleGroupSetAllTogglesOff : BaseAction
	{
		
		[Tooltip("The ToggleGroup.")]
		[SerializeField]
		private ToggleGroupVar _toggleGroup;
		
		[Tooltip("Send Callback.")]
		[SerializeField]
		private BoolVar _sendCallback;
		
		public override bool CanExecute()
		{
			return CheckParameters(_toggleGroup, _sendCallback);
		}
		
		public override void Execute()
		{
			//UnityEngine.UI.ToggleGroup.SetAllTogglesOff(System.Boolean);
			_toggleGroup.Value.SetAllTogglesOff(_sendCallback.Value);
		}
		
		public override string GetSummary()
		{
			return "Set {_toggleGroup} all toggles off {_sendCallback}";
		}
	}
}
