
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.MathUtilities)]
	[ActionDescription("Encode a floating point value into a 16-bit representation.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.FloatToHalf.html")]
	public sealed class MathfFloatToHalf : BaseAction
	{
		
		[Tooltip("The floating point value to convert.")]
		[SerializeField]
		private FloatVar _val;
		
		[Tooltip("Store the result in Unsigned Short variable.")]
		[SerializeField]
		[WriteOnly]
		private UShortRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_val, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Mathf.FloatToHalf(System.Single);
			_result.Value = Mathf.FloatToHalf(_val.Value);
		}
		
		public override string GetSummary()
		{
			return "Convert {_val} to half -> {_result}";
		}
	}
}
