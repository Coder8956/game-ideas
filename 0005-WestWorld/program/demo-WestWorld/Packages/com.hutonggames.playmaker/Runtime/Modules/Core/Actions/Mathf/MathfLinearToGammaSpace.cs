
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Exponents)]
	[ActionDescription("Converts the given value from linear to gamma (sRGB) color space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.LinearToGammaSpace.html")]
	public sealed class MathfLinearToGammaSpace : BaseAction
	{
		
		[Tooltip("Value.")]
		[SerializeField]
		private FloatVar _value;
		
		[Tooltip("Store the result in Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_value, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Mathf.LinearToGammaSpace(System.Single);
			_result.Value = Mathf.LinearToGammaSpace(_value.Value);
		}
		
		public override string GetSummary()
		{
			return "Convert linear to gamma space {_value} -> {_result}";
		}
	}
}
