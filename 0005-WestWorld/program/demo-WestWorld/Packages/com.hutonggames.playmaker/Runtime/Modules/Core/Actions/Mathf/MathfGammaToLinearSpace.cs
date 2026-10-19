
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Exponents)]
	[ActionDescription("Converts the given value from gamma (sRGB) to linear color space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.GammaToLinearSpace.html")]
	public sealed class MathfGammaToLinearSpace : BaseAction
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
			//UnityEngine.Mathf.GammaToLinearSpace(System.Single);
			_result.Value = Mathf.GammaToLinearSpace(_value.Value);
		}
		
		public override string GetSummary()
		{
			return "Convert gamma to linear space {_value} -> {_result}";
		}
	}
}
