
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RectOffset)]
	[ActionDescription("Shortcut for top + bottom. (Read Only)")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RectOffset-vertical.html")]
	public sealed class RectOffsetGetVertical : BaseAction
	{
		
		[Tooltip("The RectOffset")]
		[SerializeField]
		private RectOffsetRef _rectOffset;
		
		[Tooltip("Get RectOffset Vertical")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getVertical;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rectOffset, _getVertical);
		}
		
		public override void Execute()
		{
			_getVertical.Value = _rectOffset.Value.vertical;
		}
		
		public override string GetSummary()
		{
			return "Get {_rectOffset} vertical -> {_getVertical}";
		}
	}
}
