
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Range)]
	[ActionDescription("Clamps value between 0 and 1.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.Clamp01.html")]
	public sealed class MathfClamp01 : BaseAction
	{
		
		[Tooltip("Value to clamp.")]
		[SerializeField]
		private FloatRef _value;
		
		public override bool CanExecute() => CheckParameters(_value);

		public override void Execute() => _value.Value = Mathf.Clamp01(_value.Value);

	public override string GetSummary() => "Clamp {_value} to 01";
	}
}
