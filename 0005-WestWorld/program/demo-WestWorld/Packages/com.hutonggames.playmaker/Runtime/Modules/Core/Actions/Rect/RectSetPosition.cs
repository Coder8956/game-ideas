
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rect)]
	[ActionDescription("The X and Y position of the rectangle.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rect-position.html")]
	public sealed class RectSetPosition : BaseAction
	{
		
		[Tooltip("The Rect")]
		[SerializeField]
		private RectRef _rect;
		
		[Tooltip("Set Rect Position")]
		[SerializeField]
		private Vector2Var _setPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rect, _setPosition);
		}
		
		public override void Execute()
		{
			var value = _rect.Value;
			value.position = _setPosition.Value;
			_rect.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rect} Position to {_setPosition}";
		}
	}
}
