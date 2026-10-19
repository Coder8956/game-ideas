
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
	public sealed class RectGetHeight : BaseAction
	{
		
		[Tooltip("The Rect")]
		[SerializeField]
		private RectRef _rect;
		
		[Tooltip("Get Rect Height")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getHeight;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rect, _getHeight);
		}
		
		public override void Execute()
		{
			_getHeight.Value = _rect.Value.height;
		}
		
		public override string GetSummary()
		{
			return "Get {_rect} height -> {_getHeight}";
		}
	}
}
