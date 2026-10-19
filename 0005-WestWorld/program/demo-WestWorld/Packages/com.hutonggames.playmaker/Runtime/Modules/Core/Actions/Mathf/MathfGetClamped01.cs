
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Range)]
	[ActionDescription("Clamps value between 0 and 1 and returns value.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.Clamp01.html")]
	[MovedFrom(true, null, null, "MathfGetClamp01")]
	public sealed class MathfGetClamped01 : BaseAction
	{
		
		[Tooltip("Value to clamp.")]
		[SerializeField]
		private FloatRef _value;
		
		[Tooltip("Store the result in Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute() => CheckParameters(_value, _result);

		public override void Execute() => _result.Value = Mathf.Clamp01(_value.Value);

		public override string GetSummary() => "Clamp {_value} to 01 -> {_result}";
	}
}
