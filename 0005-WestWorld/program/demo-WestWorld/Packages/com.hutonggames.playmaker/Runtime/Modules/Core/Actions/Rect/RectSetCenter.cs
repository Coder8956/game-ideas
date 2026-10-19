
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rect)]
	[ActionDescription("The position of the center of the rectangle.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rect-center.html")]
	public sealed class RectSetCenter : BaseAction
	{
		
		[Tooltip("The Rect")]
		[SerializeField]
		private RectRef _rect;
		
		[Tooltip("Set Rect Center")]
		[SerializeField]
		private Vector2Var _setCenter;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rect, _setCenter);
		}
		
		public override void Execute()
		{
			var value = _rect.Value;
			value.center = _setCenter.Value;
			_rect.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rect} Center to {_setCenter}";
		}
	}
}
