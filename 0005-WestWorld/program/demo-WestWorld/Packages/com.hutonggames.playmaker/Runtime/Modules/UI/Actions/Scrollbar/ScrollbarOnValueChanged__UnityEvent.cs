
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Scrollbar)]
	[ActionDescription("Handling for when the scrollbar value is changed.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Scrollbar.html")]
	public sealed class ScrollbarOnValueChanged__UnityEvent : BaseAction
	{
		
		[Tooltip("The Scrollbar")]
		[SerializeField]
		private ScrollbarVar _scrollbar;
		
		[Tooltip("Set Scrollbar On Value Changed")]
		[SerializeField]
		private Scrollbar_ScrollEventVar _onValueChanged;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scrollbar, _onValueChanged);
		}
		
		public override void Execute()
		{
			_scrollbar.Value.onValueChanged = _onValueChanged.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_scrollbar} on value changed to {_onValueChanged}";
		}
	}
}
