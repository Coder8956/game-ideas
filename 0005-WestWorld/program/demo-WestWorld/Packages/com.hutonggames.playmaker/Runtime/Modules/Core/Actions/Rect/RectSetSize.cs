
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rect)]
	[ActionDescription("The width and height of the rectangle.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rect-size.html")]
	public sealed class RectSetSize : BaseAction
	{
		
		[Tooltip("The Rect")]
		[SerializeField]
		private RectRef _rect;
		
		[Tooltip("Set Rect Size")]
		[SerializeField]
		private Vector2Var _setSize;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rect, _setSize);
		}
		
		public override void Execute()
		{
			var value = _rect.Value;
			value.size = _setSize.Value;
			_rect.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rect} Size to {_setSize}";
		}
	}
}
