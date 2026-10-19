
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_ScrollRect)]
	[ActionDescription("Callback executed when the scroll position of the slider is changed.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-ScrollRect.html")]
	public sealed class ScrollRectSetOnValueChanged : BaseAction
	{
		
		[Tooltip("The ScrollRect")]
		[SerializeField]
		private ScrollRectVar _scrollRect;
		
		[Tooltip("Set ScrollRect On Value Changed")]
		[SerializeField]
		private ScrollRect_ScrollRectEventVar _setOnValueChanged;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scrollRect, _setOnValueChanged);
		}
		
		public override void Execute()
		{
			_scrollRect.Value.onValueChanged = _setOnValueChanged.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_scrollRect} on value changed to {_setOnValueChanged}";
		}
	}
}
