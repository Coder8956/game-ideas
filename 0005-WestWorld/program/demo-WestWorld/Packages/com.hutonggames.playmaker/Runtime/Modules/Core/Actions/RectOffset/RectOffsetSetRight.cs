
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
	public sealed class RectOffsetSetRight : BaseAction
	{
		
		[Tooltip("The RectOffset")]
		[SerializeField]
		private RectOffsetRef _rectOffset;
		
		[Tooltip("Set RectOffset Right")]
		[SerializeField]
		private IntegerVar _setRight;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rectOffset, _setRight);
		}
		
		public override void Execute()
		{
			_rectOffset.Value.right = _setRight.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rectOffset} Right to {_setRight}";
		}
	}
}
