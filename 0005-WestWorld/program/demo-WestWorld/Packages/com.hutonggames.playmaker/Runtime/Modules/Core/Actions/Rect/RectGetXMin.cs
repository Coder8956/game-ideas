
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rect)]
	[ActionDescription("The minimum X coordinate of the rectangle.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rect-xMin.html")]
	public sealed class RectGetXMin : BaseAction
	{
		
		[Tooltip("The Rect")]
		[SerializeField]
		private RectRef _rect;
		
		[Tooltip("Get Rect XMin")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getXMin;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rect, _getXMin);
		}
		
		public override void Execute()
		{
			_getXMin.Value = _rect.Value.xMin;
		}
		
		public override string GetSummary()
		{
			return "Get {_rect} xMin -> {_getXMin}";
		}
	}
}
