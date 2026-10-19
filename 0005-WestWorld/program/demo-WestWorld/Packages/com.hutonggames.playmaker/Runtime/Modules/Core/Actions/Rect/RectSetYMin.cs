
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rect)]
	[ActionDescription("The minimum Y coordinate of the rectangle.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rect-yMin.html")]
	public sealed class RectSetYMin : BaseAction
	{
		
		[Tooltip("The Rect")]
		[SerializeField]
		private RectRef _rect;
		
		[Tooltip("Set Rect YMin")]
		[SerializeField]
		private FloatVar _setYMin;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rect, _setYMin);
		}
		
		public override void Execute()
		{
			var value = _rect.Value;
			value.yMin = _setYMin.Value;
			_rect.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rect} YMin to {_setYMin}";
		}
	}
}
