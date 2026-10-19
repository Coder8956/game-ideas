
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
	public sealed class RectOffsetSetTop : BaseAction
	{
		
		[Tooltip("The RectOffset")]
		[SerializeField]
		private RectOffsetRef _rectOffset;
		
		[Tooltip("Set RectOffset Top")]
		[SerializeField]
		private IntegerVar _setTop;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rectOffset, _setTop);
		}
		
		public override void Execute()
		{
			_rectOffset.Value.top = _setTop.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rectOffset} Top to {_setTop}";
		}
	}
}
