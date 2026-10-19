
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rect)]
	[ActionDescription("The minimum X coordinate of the rectangle.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rect-xMin.html")]
	public sealed class RectSetXMin : BaseAction
	{
		
		[Tooltip("The Rect")]
		[SerializeField]
		private RectRef _rect;
		
		[Tooltip("Set Rect XMin")]
		[SerializeField]
		private FloatVar _setXMin;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rect, _setXMin);
		}
		
		public override void Execute()
		{
			var value = _rect.Value;
			value.xMin = _setXMin.Value;
			_rect.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rect} XMin to {_setXMin}";
		}
	}
}
