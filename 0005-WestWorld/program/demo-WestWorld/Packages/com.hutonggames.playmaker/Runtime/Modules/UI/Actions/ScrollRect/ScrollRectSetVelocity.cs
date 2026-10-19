
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_ScrollRect)]
	[ActionDescription("The current velocity of the content.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-ScrollRect.html")]
	public sealed class ScrollRectSetVelocity : BaseAction
	{
		
		[Tooltip("The ScrollRect")]
		[SerializeField]
		private ScrollRectVar _scrollRect;
		
		[Tooltip("Set ScrollRect Velocity")]
		[SerializeField]
		private Vector2Var _setVelocity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scrollRect, _setVelocity);
		}
		
		public override void Execute()
		{
			_scrollRect.Value.velocity = _setVelocity.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_scrollRect} velocity to {_setVelocity}";
		}
	}
}
