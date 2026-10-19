
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.InputSettings)]
	[ActionDescription("Bool value which let\'s users check if touch pressure is supported.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Input-touchPressureSupported.html")]
	public sealed class InputGetTouchPressureSupported : BaseAction
	{
		
		[Tooltip("Get Input Touch Pressure Supported")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getTouchPressureSupported;
		
		public override bool CanExecute() => CheckParameters(_getTouchPressureSupported);

		public override void Execute() => _getTouchPressureSupported.Value = Input.touchPressureSupported;

		public override string GetSummary() => "Get TouchPressureSupported -> {_getTouchPressureSupported} ";
	}
}
