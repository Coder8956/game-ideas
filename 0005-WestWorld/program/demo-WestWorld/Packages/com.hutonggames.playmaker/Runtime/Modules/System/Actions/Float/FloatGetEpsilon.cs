
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Float)]
	[ActionDescription("Represents the smallest positive Single value that is greater than zero.")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.single.epsilon")]
	public sealed class FloatGetEpsilon : BaseAction
	{
		
		[Tooltip("Get Float Epsilon")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getEpsilon;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getEpsilon);
		}
		
		public override void Execute()
		{
			_getEpsilon.Value = float.Epsilon;
		}
		
		public override string GetSummary()
		{
			return "Get Float Epsilon -> {_getEpsilon} ";
		}
	}
}
