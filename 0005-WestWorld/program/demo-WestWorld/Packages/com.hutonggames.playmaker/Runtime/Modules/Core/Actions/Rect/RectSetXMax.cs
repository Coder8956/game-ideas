
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rect)]
	[ActionDescription("The maximum X coordinate of the rectangle.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rect-xMax.html")]
	public sealed class RectSetXMax : BaseAction
	{
		
		[Tooltip("The Rect")]
		[SerializeField]
		private RectRef _rect;
		
		[Tooltip("Set Rect XMax")]
		[SerializeField]
		private FloatVar _setXMax;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rect, _setXMax);
		}
		
		public override void Execute()
		{
			var value = _rect.Value;
			value.xMax = _setXMax.Value;
			_rect.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rect} XMax to {_setXMax}";
		}
	}
}
