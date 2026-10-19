
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rect)]
	[ActionDescription("The position of the minimum corner of the rectangle.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rect-min.html")]
	public sealed class RectSetMin : BaseAction
	{
		
		[Tooltip("The Rect")]
		[SerializeField]
		private RectRef _rect;
		
		[Tooltip("Set Rect Min")]
		[SerializeField]
		private Vector2Var _setMin;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rect, _setMin);
		}
		
		public override void Execute()
		{
			var value = _rect.Value;
			value.min = _setMin.Value;
			_rect.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rect} Min to {_setMin}";
		}
	}
}
