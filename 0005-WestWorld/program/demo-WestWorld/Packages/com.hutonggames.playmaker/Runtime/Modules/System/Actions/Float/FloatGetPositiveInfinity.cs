
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Float)]
	[ActionDescription("Represents positive infinity. This field is constant. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.single.positiveinfinity")]
	public sealed class FloatGetPositiveInfinity : BaseAction
	{
		
		[Tooltip("Get Float Positive Infinity")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getPositiveInfinity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getPositiveInfinity);
		}
		
		public override void Execute()
		{
			_getPositiveInfinity.Value = float.PositiveInfinity;
		}
		
		public override string GetSummary()
		{
			return "Get Float PositiveInfinity -> {_getPositiveInfinity} ";
		}
	}
}
