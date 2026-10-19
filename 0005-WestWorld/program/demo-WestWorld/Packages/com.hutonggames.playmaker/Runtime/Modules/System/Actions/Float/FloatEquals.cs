
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Float)]
	[ActionDescription("Returns a value indicating whether two instances of Single represent the same value. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.single.equals")]
	public sealed class FloatEquals : BaseAction
	{
		
		[Tooltip("The Float.")]
		[SerializeField]
		private FloatRef _float;
		
		[Tooltip("The other Float.")]
		[SerializeField]
		private FloatVar _other;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_float, _other, _result);
		}
		
		public override void Execute()
		{
			//System.Single.Equals(System.Single);
			_result.Value = _float.Value.Equals(_other.Value);
		}
		
		public override string GetSummary()
		{
			return "{_float} equals {_other} -> {_result}";
		}
	}
}
