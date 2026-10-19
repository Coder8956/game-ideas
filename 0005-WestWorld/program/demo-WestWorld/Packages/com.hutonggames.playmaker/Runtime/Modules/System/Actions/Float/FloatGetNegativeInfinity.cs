
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Float)]
	[ActionDescription("Represents negative infinity. This field is constant. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.single.negativeinfinity")]
	public sealed class FloatGetNegativeInfinity : BaseAction
	{
		
		[Tooltip("Get Float Negative Infinity")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getNegativeInfinity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getNegativeInfinity);
		}
		
		public override void Execute()
		{
			_getNegativeInfinity.Value = float.NegativeInfinity;
		}
		
		public override string GetSummary()
		{
			return "Get Float NegativeInfinity -> {_getNegativeInfinity} ";
		}
	}
}
