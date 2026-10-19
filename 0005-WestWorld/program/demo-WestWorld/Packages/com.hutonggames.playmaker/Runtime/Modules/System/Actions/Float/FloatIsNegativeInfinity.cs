
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Float)]
	[ActionDescription("Returns a value indicating whether the specified number evaluates to negative inf" +
		"inity. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.single.isnegativeinfinity")]
	public sealed class FloatIsNegativeInfinity : BaseAction
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
			//System.Single.IsNegativeInfinity(System.Single);
			_result.Value = float.IsNegativeInfinity(_float.Value);
		}
		
		public override string GetSummary()
		{
			return "Is {_float} Negative Infinity -> {_result}";
		}
	}
}
