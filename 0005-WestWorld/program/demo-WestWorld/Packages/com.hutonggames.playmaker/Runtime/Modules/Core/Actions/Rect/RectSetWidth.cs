
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rect)]
	[ActionDescription("The width of the rectangle, measured from the X position.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rect-width.html")]
	public sealed class RectSetWidth : BaseAction
	{
		
		[Tooltip("The Rect")]
		[SerializeField]
		private RectRef _rect;
		
		[Tooltip("Set Rect Width")]
		[SerializeField]
		private FloatVar _setWidth;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rect, _setWidth);
		}
		
		public override void Execute()
		{
			var value = _rect.Value;
			value.width = _setWidth.Value;
			_rect.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rect} Width to {_setWidth}";
		}
	}
}
