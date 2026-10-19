
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Float)]
	[ActionDescription("Represents the smallest possible value of a Float. This field is constant. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.single.minvalue")]
	public sealed class FloatGetMinValue : BaseAction
	{
		
		[Tooltip("Get Float Min Value")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getMinValue;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getMinValue);
		}
		
		public override void Execute()
		{
			_getMinValue.Value = float.MinValue;
		}
		
		public override string GetSummary()
		{
			return "Get Float MinValue -> {_getMinValue} ";
		}
	}
}
