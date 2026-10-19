
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
	public sealed class RectGetX : BaseAction
	{
		
		[Tooltip("The Rect")]
		[SerializeField]
		private RectRef _rect;
		
		[Tooltip("Get Rect X")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getX;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rect, _getX);
		}
		
		public override void Execute()
		{
			_getX.Value = _rect.Value.x;
		}
		
		public override string GetSummary()
		{
			return "Get {_rect} x -> {_getX}";
		}
	}
}
