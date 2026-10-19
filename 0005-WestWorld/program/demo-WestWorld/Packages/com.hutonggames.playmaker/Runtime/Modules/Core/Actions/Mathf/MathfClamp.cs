
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Range)]
	[ActionDescription("Clamps a value between minimum and maximum values. ")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.Clamp.html")]
	public sealed class MathfClamp : BaseAction
	{
		
		[Tooltip("The Float variable to restrict inside the range defined by the minimum and " +
			"maximum values.")]
		[SerializeField]
		private FloatRef _value;
		
		[Tooltip("The minimum floating point value to compare against.")]
		[SerializeField]
		private FloatVar _min;
		
		[Tooltip("The maximum floating point value to compare against.")]
		[SerializeField]
		private FloatVar _max;
		
		public override bool CanExecute() => CheckParameters(_value, _min, _max);

		public override void Execute() => _value.Value = Mathf.Clamp(_value.Value, _min.Value, _max.Value);

		public override string GetSummary() => "Clamp {_value} to {_min} {_max}";
	}
}
