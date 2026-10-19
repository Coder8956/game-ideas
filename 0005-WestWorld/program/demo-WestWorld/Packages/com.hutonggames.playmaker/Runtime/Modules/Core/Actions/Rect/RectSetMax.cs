
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rect)]
	[ActionDescription("The position of the maximum corner of the rectangle.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rect-max.html")]
	public sealed class RectSetMax : BaseAction
	{
		
		[Tooltip("The Rect")]
		[SerializeField]
		private RectRef _rect;
		
		[Tooltip("Set Rect Max")]
		[SerializeField]
		private Vector2Var _setMax;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rect, _setMax);
		}
		
		public override void Execute()
		{
			var value = _rect.Value;
			value.max = _setMax.Value;
			_rect.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rect} Max to {_setMax}";
		}
	}
}
