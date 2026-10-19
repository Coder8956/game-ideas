
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
	public sealed class RectGetWidth : BaseAction
	{
		
		[Tooltip("The Rect")]
		[SerializeField]
		private RectRef _rect;
		
		[Tooltip("Get Rect Width")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getWidth;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rect, _getWidth);
		}
		
		public override void Execute()
		{
			_getWidth.Value = _rect.Value.width;
		}
		
		public override string GetSummary()
		{
			return "Get {_rect} width -> {_getWidth}";
		}
	}
}
