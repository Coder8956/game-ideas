/* Not documented
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.Mathf)]
	[ActionDescription("Performs Mathf Gamma.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.Gamma.html")]
	public sealed class MathfGamma : BaseAction
	{
		
		[Tooltip("Value.")]
		[SerializeField]
		private FloatVar _value;
		
		[Tooltip("Absmax.")]
		[SerializeField]
		private FloatVar _absmax;
		
		[Tooltip("Gamma.")]
		[SerializeField]
		private FloatVar _gamma;
		
		[Tooltip("Store the result in Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_value, _absmax, _gamma, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Mathf.Gamma(System.Single, System.Single, System.Single);
			_result.Value = Mathf.Gamma(_value.Value, _absmax.Value, _gamma.Value);
		}
		
		public override string GetSummary()
		{
			return "Apply gamma {_value} {_absmax} {_gamma} -> {_result}";
		}
	}
}
*/
