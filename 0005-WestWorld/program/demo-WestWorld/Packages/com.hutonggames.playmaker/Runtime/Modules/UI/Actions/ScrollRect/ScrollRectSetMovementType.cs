
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_ScrollRect)]
	[ActionDescription("The behavior to use when the content moves beyond the scroll rect.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-ScrollRect.html")]
	public sealed class ScrollRectSetMovementType : BaseAction
	{
		
		[Tooltip("The ScrollRect")]
		[SerializeField]
		private ScrollRectVar _scrollRect;
		
		[Tooltip("Set ScrollRect Movement Type")]
		[SerializeField]
		private ScrollRect_MovementTypeVar _setMovementType;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scrollRect, _setMovementType);
		}
		
		public override void Execute()
		{
			_scrollRect.Value.movementType = _setMovementType.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_scrollRect} movement type to {_setMovementType}";
		}
	}
}
