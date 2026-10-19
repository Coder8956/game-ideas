
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Toggle)]
	[ActionDescription("Callback executed when the value of the toggle is changed.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Toggle.html")]
	public sealed class ToggleOnValueChanged__UnityEvent : BaseAction
	{
		
		[Tooltip("The Toggle")]
		[SerializeField]
		private ToggleVar _toggle;
		
		[Tooltip("Set Toggle On Value Changed")]
		[SerializeField]
		private Toggle_ToggleEventVar _onValueChanged;
		
		public override bool CanExecute()
		{
			return CheckParameters(_toggle, _onValueChanged);
		}
		
		public override void Execute()
		{
			_toggle.Value.onValueChanged = _onValueChanged.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_toggle} on value changed to {_onValueChanged}";
		}
	}
}
