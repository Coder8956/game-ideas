
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RectOffset)]
	[ActionDescription("Shortcut for left + right. (Read Only)")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RectOffset-horizontal.html")]
	public sealed class RectOffsetGetHorizontal : BaseAction
	{
		
		[Tooltip("The RectOffset")]
		[SerializeField]
		private RectOffsetRef _rectOffset;
		
		[Tooltip("Get RectOffset Horizontal")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getHorizontal;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rectOffset, _getHorizontal);
		}
		
		public override void Execute()
		{
			_getHorizontal.Value = _rectOffset.Value.horizontal;
		}
		
		public override string GetSummary()
		{
			return "Get {_rectOffset} horizontal -> {_getHorizontal}";
		}
	}
}
