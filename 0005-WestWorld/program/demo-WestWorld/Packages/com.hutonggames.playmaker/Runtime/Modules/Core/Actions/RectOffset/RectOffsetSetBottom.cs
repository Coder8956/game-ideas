
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
	public sealed class RectOffsetSetBottom : BaseAction
	{
		
		[Tooltip("The RectOffset")]
		[SerializeField]
		private RectOffsetRef _rectOffset;
		
		[Tooltip("Set RectOffset Bottom")]
		[SerializeField]
		private IntegerVar _setBottom;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rectOffset, _setBottom);
		}
		
		public override void Execute()
		{
			_rectOffset.Value.bottom = _setBottom.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rectOffset} Bottom to {_setBottom}";
		}
	}
}
