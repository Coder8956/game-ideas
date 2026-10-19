
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Float)]
	[ActionDescription("Represents not a number (NaN). This field is constant. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.single.nan")]
	public sealed class FloatGetNaN : BaseAction
	{
		
		[Tooltip("Get Float Na N")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getNaN;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getNaN);
		}
		
		public override void Execute()
		{
			_getNaN.Value = float.NaN;
		}
		
		public override string GetSummary()
		{
			return "Get Float NaN -> {_getNaN} ";
		}
	}
}
