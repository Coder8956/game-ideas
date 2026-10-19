
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Range)]
	[ActionDescription("Clamps the given value between the given minimum float and maximum float values. " +
		"Returns the given value if it is within the minimum and maximum range.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.Clamp.html")]
	[MovedFrom(true, null, null, "MathfGetClamp")]
	public sealed class MathfGetClamped : BaseAction
	{
		
		[Tooltip("The floating point value to restrict inside the range defined by the minimum and " +
			"maximum values.")]
		[SerializeField]
		private FloatVar _value;
		
		[Tooltip("The minimum floating point value to compare against.")]
		[SerializeField]
		private FloatVar _min;
		
		[Tooltip("The maximum floating point value to compare against.")]
		[SerializeField]
		private FloatVar _max;
		
		[Tooltip("Store the result in Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute() => CheckParameters(_value, _min, _max, _result);

		public override void Execute() => _result.Value = Mathf.Clamp(_value.Value, _min.Value, _max.Value);

		public override string GetSummary() => "Clamp {_value} to {_min} {_max} -> {_result}";
	}
}
