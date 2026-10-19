
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rect)]
	[ActionDescription("The maximum X coordinate of the rectangle.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rect-xMax.html")]
	public sealed class RectGetXMax : BaseAction
	{
		
		[Tooltip("The Rect")]
		[SerializeField]
		private RectRef _rect;
		
		[Tooltip("Get Rect XMax")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getXMax;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rect, _getXMax);
		}
		
		public override void Execute()
		{
			_getXMax.Value = _rect.Value.xMax;
		}
		
		public override string GetSummary()
		{
			return "Get {_rect} xMax -> {_getXMax}";
		}
	}
}
