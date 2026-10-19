
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Range)]
	[ActionDescription("Clamps the given value between a range defined by the given minimum integer and m" +
		"aximum integer values. Returns the given value if it is within min and max.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.Clamp.html")]
	public sealed class MathfClamp__Int : BaseAction
	{
		
		[Tooltip("The integer point value to restrict inside the min-to-max range.")]
		[SerializeField]
		private IntegerVar _value;
		
		[Tooltip("The minimum integer point value to compare against.")]
		[SerializeField]
		private IntegerVar _min;
		
		[Tooltip("The maximum integer point value to compare against.")]
		[SerializeField]
		private IntegerVar _max;
		
		[Tooltip("Store the result in Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_value, _min, _max, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Mathf.Clamp(System.Int32, System.Int32, System.Int32);
			_result.Value = Mathf.Clamp(_value.Value, _min.Value, _max.Value);
		}
		
		public override string GetSummary()
		{
			return "Clamp {_value} to {_min} {_max} -> {_result}";
		}
	}
}
