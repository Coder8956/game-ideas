
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Exponents)]
	[ActionDescription("Returns e raised to the specified power.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.Exp.html")]
	public sealed class MathfExp : BaseAction
	{
		
		[Tooltip("Power.")]
		[SerializeField]
		private FloatVar _power;
		
		[Tooltip("Store the result in Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_power, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Mathf.Exp(System.Single);
			_result.Value = Mathf.Exp(_power.Value);
		}
		
		public override string GetSummary()
		{
			return "Exp {_power} -> {_result}";
		}
	}
}
