
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Float)]
	[ActionDescription("Returns a value that indicates whether the specified value is not a number (NaN)." +
		" ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.single.isnan")]
	public sealed class FloatIsNaN : BaseAction
	{
		
		[Tooltip("The Float.")]
		[SerializeField]
		private FloatRef _float;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_float, _result);
		}
		
		public override void Execute()
		{
			//System.Single.IsNaN(System.Single);
			_result.Value = float.IsNaN(_float.Value);
		}
		
		public override string GetSummary()
		{
			return "Is {_float} NaN -> {_result}";
		}
	}
}
