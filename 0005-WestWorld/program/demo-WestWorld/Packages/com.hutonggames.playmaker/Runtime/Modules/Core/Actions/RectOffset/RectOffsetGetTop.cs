
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RectOffset)]
	[ActionDescription("Top edge size.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RectOffset-top.html")]
	public sealed class RectOffsetGetTop : BaseAction
	{
		
		[Tooltip("The RectOffset")]
		[SerializeField]
		private RectOffsetRef _rectOffset;
		
		[Tooltip("Get RectOffset Top")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getTop;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rectOffset, _getTop);
		}
		
		public override void Execute()
		{
			_getTop.Value = _rectOffset.Value.top;
		}
		
		public override string GetSummary()
		{
			return "Get {_rectOffset} top -> {_getTop}";
		}
	}
}
