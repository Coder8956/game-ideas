
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Float)]
	[ActionDescription("Returns a value indicating whether the specified number evaluates to positive infinity. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.single.ispositiveinfinity")]
	public sealed class FloatIsPositiveInfinity : BaseAction
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
			//System.Single.IsPositiveInfinity(System.Single);
			_result.Value = float.IsPositiveInfinity(_float.Value);
		}
		
		public override string GetSummary()
		{
			return "{_float} Is Positive Infinity -> {_result}";
		}
	}
}
