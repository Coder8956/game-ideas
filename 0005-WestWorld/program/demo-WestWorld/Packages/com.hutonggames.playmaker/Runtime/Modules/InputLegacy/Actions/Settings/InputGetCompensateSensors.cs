
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.InputSettings)]
	[ActionDescription("This property controls if input sensors should be compensated for screen orientation.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Input-compensateSensors.html")]
	public sealed class InputGetCompensateSensors : BaseAction
	{
		
		[Tooltip("Get Input Compensate Sensors")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getCompensateSensors;
		
		public override bool CanExecute() => CheckParameters(_getCompensateSensors);

		public override void Execute() => _getCompensateSensors.Value = Input.compensateSensors;

		public override string GetSummary() => "Get CompensateSensors -> {_getCompensateSensors} ";
	}
}
