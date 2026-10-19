
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
	public sealed class RectGetYMax : BaseAction
	{
		
		[Tooltip("The Rect")]
		[SerializeField]
		private RectRef _rect;
		
		[Tooltip("Get Rect YMax")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getYMax;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rect, _getYMax);
		}
		
		public override void Execute()
		{
			_getYMax.Value = _rect.Value.yMax;
		}
		
		public override string GetSummary()
		{
			return "Get {_rect} yMax -> {_getYMax}";
		}
	}
}
