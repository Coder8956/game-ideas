
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rect)]
	[ActionDescription("The maximum Y coordinate of the rectangle.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rect-yMax.html")]
	public sealed class RectSetYMax : BaseAction
	{
		
		[Tooltip("The Rect")]
		[SerializeField]
		private RectRef _rect;
		
		[Tooltip("Set Rect YMax")]
		[SerializeField]
		private FloatVar _setYMax;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rect, _setYMax);
		}
		
		public override void Execute()
		{
			var value = _rect.Value;
			value.yMax = _setYMax.Value;
			_rect.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rect} YMax to {_setYMax}";
		}
	}
}
