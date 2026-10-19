
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Float)]
	[ActionDescription("Returns a value indicating whether the specified number evaluates to negative or " +
		"positive infinity. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.single.isinfinity")]
	public sealed class FloatIsInfinity : BaseAction
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
			//System.Single.IsInfinity(System.Single);
			_result.Value = float.IsInfinity(_float.Value);
		}
		
		public override string GetSummary()
		{
			return "Is {_float} Infinity -> {_result}";
		}
	}
}
