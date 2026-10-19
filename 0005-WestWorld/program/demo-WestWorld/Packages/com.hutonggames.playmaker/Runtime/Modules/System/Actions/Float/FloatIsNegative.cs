
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Float)]
	[ActionDescription("Determines whether the specified value is negative. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.single.isnegative")]
	public sealed class FloatIsNegative : BaseAction
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
			//System.Single.IsNegative(System.Single);
			_result.Value = float.IsNegative(_float.Value);
		}
		
		public override string GetSummary()
		{
			return "Is {_float} Negative -> {_result}";
		}
	}
}
