
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RectOffset)]
	[ActionDescription("Bottom edge size.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RectOffset-bottom.html")]
	public sealed class RectOffsetGetBottom : BaseAction
	{
		
		[Tooltip("The RectOffset")]
		[SerializeField]
		private RectOffsetRef _rectOffset;
		
		[Tooltip("Get RectOffset Bottom")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getBottom;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rectOffset, _getBottom);
		}
		
		public override void Execute()
		{
			_getBottom.Value = _rectOffset.Value.bottom;
		}
		
		public override string GetSummary()
		{
			return "Get {_rectOffset} bottom -> {_getBottom}";
		}
	}
}
