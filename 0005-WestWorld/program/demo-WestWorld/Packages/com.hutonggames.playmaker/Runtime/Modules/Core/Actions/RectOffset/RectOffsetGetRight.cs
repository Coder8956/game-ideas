
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RectOffset)]
	[ActionDescription("Right edge size.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RectOffset-right.html")]
	public sealed class RectOffsetGetRight : BaseAction
	{
		
		[Tooltip("The RectOffset")]
		[SerializeField]
		private RectOffsetRef _rectOffset;
		
		[Tooltip("Get RectOffset Right")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getRight;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rectOffset, _getRight);
		}
		
		public override void Execute()
		{
			_getRight.Value = _rectOffset.Value.right;
		}
		
		public override string GetSummary()
		{
			return "Get {_rectOffset} right -> {_getRight}";
		}
	}
}
