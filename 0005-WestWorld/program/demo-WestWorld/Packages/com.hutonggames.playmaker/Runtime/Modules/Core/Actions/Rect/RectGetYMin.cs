
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
	public sealed class RectGetYMin : BaseAction
	{
		
		[Tooltip("The Rect")]
		[SerializeField]
		private RectRef _rect;
		
		[Tooltip("Get Rect YMin")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getYMin;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rect, _getYMin);
		}
		
		public override void Execute()
		{
			_getYMin.Value = _rect.Value.yMin;
		}
		
		public override string GetSummary()
		{
			return "Get {_rect} yMin -> {_getYMin}";
		}
	}
}
