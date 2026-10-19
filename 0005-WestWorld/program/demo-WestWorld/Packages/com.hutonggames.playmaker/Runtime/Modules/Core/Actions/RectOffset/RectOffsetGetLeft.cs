
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RectOffset)]
	[ActionDescription("Left edge size.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RectOffset-left.html")]
	public sealed class RectOffsetGetLeft : BaseAction
	{
		
		[Tooltip("The RectOffset")]
		[SerializeField]
		private RectOffsetRef _rectOffset;
		
		[Tooltip("Get RectOffset Left")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getLeft;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rectOffset, _getLeft);
		}
		
		public override void Execute()
		{
			_getLeft.Value = _rectOffset.Value.left;
		}
		
		public override string GetSummary()
		{
			return "Get {_rectOffset} left -> {_getLeft}";
		}
	}
}
