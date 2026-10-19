
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Scrollbar)]
	[ActionDescription("The size of the scrollbar handle where 1 means it fills the entire scrollbar.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Scrollbar.html")]
	public sealed class ScrollbarSetSize : BaseAction
	{
		
		[Tooltip("The Scrollbar")]
		[SerializeField]
		private ScrollbarVar _scrollbar;
		
		[Tooltip("Set Scrollbar Size")]
		[SerializeField]
		private FloatVar _setSize;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scrollbar, _setSize);
		}
		
		public override void Execute()
		{
			_scrollbar.Value.size = _setSize.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_scrollbar} size to {_setSize}";
		}
	}
}
