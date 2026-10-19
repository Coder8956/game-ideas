
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rect)]
	[ActionDescription("The height of the rectangle, measured from the Y position.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rect-height.html")]
	public sealed class RectSetHeight : BaseAction
	{
		
		[Tooltip("The Rect")]
		[SerializeField]
		private RectRef _rect;
		
		[Tooltip("Set Rect Height")]
		[SerializeField]
		private FloatVar _setHeight;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rect, _setHeight);
		}
		
		public override void Execute()
		{
			var value = _rect.Value;
			value.height = _setHeight.Value;
			_rect.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rect} Height to {_setHeight}";
		}
	}
}
