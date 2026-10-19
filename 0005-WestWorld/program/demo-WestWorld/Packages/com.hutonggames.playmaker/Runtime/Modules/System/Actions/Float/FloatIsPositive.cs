
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Float)]
	[ActionDescription("Determines whether the specified value is positive. ")]
	public sealed class FloatIsPositive : BaseAction
	{
		
		[Tooltip("The float.")]
		[SerializeField]
		private FloatRef _float;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute() => CheckParameters(_float, _result);

		public override void Execute() => _result.Value = _float.Value > 0;

		public override string GetSummary() => "Is {_float} Positive -> {_result}";
	}
}
