
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.InputSettings)]
	[ActionDescription("This property controls if input sensors should be compensated for screen orientat" +
		"ion.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Input-compensateSensors.html")]
	public sealed class InputSetCompensateSensors : BaseAction
	{
		
		[Tooltip("Set Input Compensate Sensors")]
		[SerializeField]
		private BoolVar _setCompensateSensors;
		
		public override bool CanExecute() => CheckParameters(_setCompensateSensors);

		public override void Execute() => Input.compensateSensors = _setCompensateSensors.Value;

		public override string GetSummary() => "Set CompensateSensors to {_setCompensateSensors}";
	}
}
