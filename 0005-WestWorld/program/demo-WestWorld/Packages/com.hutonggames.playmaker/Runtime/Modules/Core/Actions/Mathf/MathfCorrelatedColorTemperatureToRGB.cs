
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.MathColor)]
	[ActionDescription("Convert a color temperature in Kelvin to RGB color.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.CorrelatedColorTemperatureToRGB.html")]
	public sealed class MathfCorrelatedColorTemperatureToRGB : BaseAction
	{
		
		[Tooltip("Temperature in Kelvin. Range 1000 to 40000 Kelvin.")]
		[SerializeField]
		private FloatVar _kelvin;
		
		[Tooltip("Store the result in Color variable.")]
		[SerializeField]
		[WriteOnly]
		private ColorRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_kelvin, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Mathf.CorrelatedColorTemperatureToRGB(System.Single);
			_result.Value = Mathf.CorrelatedColorTemperatureToRGB(_kelvin.Value);
		}
		
		public override string GetSummary()
		{
			return "Convert correlated color temperature {_kelvin} to RGB -> {_result}";
		}
	}
}
