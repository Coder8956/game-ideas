
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rect)]
	[ActionDescription("The X coordinate of the rectangle.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rect-x.html")]
	public sealed class RectSetX : BaseAction
	{
		
		[Tooltip("The Rect")]
		[SerializeField]
		private RectRef _rect;
		
		[Tooltip("Set Rect X")]
		[SerializeField]
		private FloatVar _setX;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rect, _setX);
		}
		
		public override void Execute()
		{
			var value = _rect.Value;
			value.x = _setX.Value;
			_rect.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rect} X to {_setX}";
		}
	}
}
