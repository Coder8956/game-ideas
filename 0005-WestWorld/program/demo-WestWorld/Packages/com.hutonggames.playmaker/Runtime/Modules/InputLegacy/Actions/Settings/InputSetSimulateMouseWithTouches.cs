
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.InputSettings)]
	[ActionDescription("Enables/Disables mouse simulation with touches. By default this option is enabled.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Input-simulateMouseWithTouches.html")]
	public sealed class InputSetSimulateMouseWithTouches : BaseAction
	{
		
		[Tooltip("Set Input Simulate Mouse With Touches")]
		[SerializeField]
		private BoolVar _setSimulateMouseWithTouches;
		
		public override bool CanExecute() => CheckParameters(_setSimulateMouseWithTouches);

		public override void Execute() => Input.simulateMouseWithTouches = _setSimulateMouseWithTouches.Value;

		public override string GetSummary() => "Set InputSimulateMouseWithTouches to {_setSimulateMouseWithTouches}";
	}
}
