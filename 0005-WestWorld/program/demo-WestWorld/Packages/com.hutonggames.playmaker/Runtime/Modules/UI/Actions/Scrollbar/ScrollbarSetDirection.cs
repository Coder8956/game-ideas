
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Scrollbar)]
	[ActionDescription("Set the direction of the scrollbar, optionally setting the layout as well.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Scrollbar.html")]
	public sealed class ScrollbarSetDirection : BaseAction
	{
		
		[Tooltip("The direction of the scrollbar.")]
		[SerializeField]
		private ScrollbarVar _scrollbar;
		
		[Tooltip("Direction.")]
		[SerializeField]
		private Scrollbar_DirectionVar _direction;
		
		[Tooltip("Should the layout be flipped together with the direction?")]
		[SerializeField]
		private BoolVar _includeRectLayouts;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scrollbar, _direction, _includeRectLayouts);
		}
		
		public override void Execute()
		{
			//UnityEngine.UI.Scrollbar.SetDirection(UnityEngine.UI.Scrollbar+Direction, System.Boolean);
			_scrollbar.Value.SetDirection(_direction.Value, _includeRectLayouts.Value);
		}
		
		public override string GetSummary()
		{
			return "Set {_scrollbar} direction to {_direction} {_includeRectLayouts}";
		}
	}
}
