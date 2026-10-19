
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
	public sealed class RectGetY : BaseAction
	{
		
		[Tooltip("The Rect")]
		[SerializeField]
		private RectRef _rect;
		
		[Tooltip("Get Rect Y")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getY;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rect, _getY);
		}
		
		public override void Execute()
		{
			_getY.Value = _rect.Value.y;
		}
		
		public override string GetSummary()
		{
			return "Get {_rect} y -> {_getY}";
		}
	}
}
