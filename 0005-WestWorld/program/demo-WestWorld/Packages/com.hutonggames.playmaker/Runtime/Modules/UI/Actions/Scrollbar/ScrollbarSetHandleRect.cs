
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Scrollbar)]
	[ActionDescription("The RectTransform to use for the handle.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Scrollbar.html")]
	public sealed class ScrollbarSetHandleRect : BaseAction
	{
		
		[Tooltip("The Scrollbar")]
		[SerializeField]
		private ScrollbarVar _scrollbar;
		
		[Tooltip("Set Scrollbar Handle Rect")]
		[SerializeField, CanBeNullOrEmpty]
		private RectTransformVar _setHandleRect;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scrollbar);
		}
		
		public override void Execute()
		{
			_scrollbar.Value.handleRect = _setHandleRect.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_scrollbar} handle rect to {_setHandleRect}";
		}
	}
}
