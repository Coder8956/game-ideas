
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.MathUtilities)]
	[ActionDescription("Convert a half precision float to a 32-bit floating point value.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.HalfToFloat.html")]
	public sealed class MathfHalfToFloat : BaseAction
	{
		
		[Tooltip("The half precision value to convert.")]
		[SerializeField]
		private UShortVar _val;
		
		[Tooltip("Store the result in Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_val, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Mathf.HalfToFloat(System.UInt16);
			_result.Value = Mathf.HalfToFloat(_val.Value);
		}
		
		public override string GetSummary()
		{
			return "Convert {_val} to float -> {_result}";
		}
	}
}
