
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rect)]
	[ActionDescription("The Y coordinate of the rectangle.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rect-y.html")]
	public sealed class RectSetY : BaseAction
	{
		
		[Tooltip("The Rect")]
		[SerializeField]
		private RectRef _rect;
		
		[Tooltip("Set Rect Y")]
		[SerializeField]
		private FloatVar _setY;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rect, _setY);
		}
		
		public override void Execute()
		{
			var value = _rect.Value;
			value.y = _setY.Value;
			_rect.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rect} Y to {_setY}";
		}
	}
}
