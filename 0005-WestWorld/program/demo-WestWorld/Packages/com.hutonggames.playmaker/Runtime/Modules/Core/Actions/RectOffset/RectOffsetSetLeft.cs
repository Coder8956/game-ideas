
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
	public sealed class RectOffsetSetLeft : BaseAction
	{
		
		[Tooltip("The RectOffset")]
		[SerializeField]
		private RectOffsetRef _rectOffset;
		
		[Tooltip("Set RectOffset Left")]
		[SerializeField]
		private IntegerVar _setLeft;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rectOffset, _setLeft);
		}
		
		public override void Execute()
		{
			_rectOffset.Value.left = _setLeft.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rectOffset} Left to {_setLeft}";
		}
	}
}
