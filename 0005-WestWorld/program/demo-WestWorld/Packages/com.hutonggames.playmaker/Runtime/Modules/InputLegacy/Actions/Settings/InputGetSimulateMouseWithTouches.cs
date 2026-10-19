
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.InputSettings)]
	[ActionDescription("Enables/Disables mouse simulation with touches. By default this option is enabled" +
		".")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Input-simulateMouseWithTouches.html")]
	public sealed class InputGetSimulateMouseWithTouches : BaseAction
	{
		
		[Tooltip("Get Input Simulate Mouse With Touches")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getSimulateMouseWithTouches;
		
		public override bool CanExecute() => CheckParameters(_getSimulateMouseWithTouches);

		public override void Execute() => _getSimulateMouseWithTouches.Value = Input.simulateMouseWithTouches;

		public override string GetSummary() => "Get SimulateMouseWithTouches -> {_getSimulateMouseWithTouches} ";
	}
}
