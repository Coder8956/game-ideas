
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_ScrollRect)]
	[ActionDescription("See member in base class.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-ScrollRect.html")]
	public sealed class ScrollRectIsActive : BaseAction
	{
		
		[Tooltip("The ScrollRect.")]
		[SerializeField]
		private ScrollRectVar _scrollRect;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scrollRect, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.UI.ScrollRect.IsActive();
			_result.Value = _scrollRect.Value.IsActive();
		}
		
		public override string GetSummary()
		{
			return "Check {_scrollRect} is active -> {_result}";
		}
	}
}
