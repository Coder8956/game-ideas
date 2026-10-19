
using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_ToggleGroup)]
	[ActionDescription("Notify the group that the given toggle is enabled.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-ToggleGroup.html")]
	public sealed class ToggleGroupNotifyToggleOn : BaseAction
	{
		
		[Tooltip("The ToggleGroup.")]
		[SerializeField]
		private ToggleGroupVar _toggleGroup;
		
		[Tooltip("Toggle.")]
		[SerializeField]
		private ToggleVar _toggle;
		
		[Tooltip("Send Callback.")]
		[SerializeField]
		private BoolVar _sendCallback;
		
		public override bool CanExecute()
		{
			return CheckParameters(_toggleGroup, _toggle, _sendCallback);
		}
		
		public override void Execute()
		{
			//UnityEngine.UI.ToggleGroup.NotifyToggleOn(UnityEngine.UI.Toggle, System.Boolean);
			_toggleGroup.Value.NotifyToggleOn(_toggle.Value, _sendCallback.Value);
		}
		
		public override string GetSummary()
		{
			return "Notify {_toggleGroup} toggle on {_toggle} {_sendCallback}";
		}
	}
}
