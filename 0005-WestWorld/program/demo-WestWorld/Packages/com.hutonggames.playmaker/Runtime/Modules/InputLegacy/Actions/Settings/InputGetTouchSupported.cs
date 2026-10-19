
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.InputSettings)]
	[ActionDescription("Returns whether the device on which application is currently running supports tou" +
		"ch input.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Input-touchSupported.html")]
	public sealed class InputGetTouchSupported : BaseAction
	{
		
		[Tooltip("Get Input Touch Supported")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getTouchSupported;
		
		public override bool CanExecute() => CheckParameters(_getTouchSupported);

		public override void Execute() => _getTouchSupported.Value = Input.touchSupported;

		public override string GetSummary() => "Get TouchSupported -> {_getTouchSupported} ";
	}
}
