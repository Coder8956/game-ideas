
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Interpolation)]
	[ActionDescription("Determines where a value lies between two points.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.InverseLerp.html")]
	public sealed class MathfInverseLerp : BaseAction
	{
		
		[Tooltip("The start of the range.")]
		[SerializeField]
		private FloatVar _a;
		
		[Tooltip("The end of the range.")]
		[SerializeField]
		private FloatVar _b;
		
		[Tooltip("The point within the range you want to calculate.")]
		[SerializeField]
		private FloatVar _value;
		
		[Tooltip("Store the result in Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_a, _b, _value, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Mathf.InverseLerp(System.Single, System.Single, System.Single);
			_result.Value = Mathf.InverseLerp(_a.Value, _b.Value, _value.Value);
		}
		
		public override string GetSummary()
		{
			return "Inverse lerp {_a} {_b} at {_value} -> {_result}";
		}
	}
}
