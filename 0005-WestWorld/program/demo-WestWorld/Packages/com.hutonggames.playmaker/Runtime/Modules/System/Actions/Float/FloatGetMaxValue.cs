
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Float)]
	[ActionDescription("Represents the largest possible value of a Float. This field is constant. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.single.maxvalue")]
	public sealed class FloatGetMaxValue : BaseAction
	{
		
		[Tooltip("Get Float Max Value")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getMaxValue;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getMaxValue);
		}
		
		public override void Execute()
		{
			_getMaxValue.Value = float.MaxValue;
		}
		
		public override string GetSummary()
		{
			return "Get Float MaxValue -> {_getMaxValue} ";
		}
	}
}
