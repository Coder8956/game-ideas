
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.InputSettings)]
	[ActionDescription("Returns true when Stylus Touch is supported by a device or platform.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Input-stylusTouchSupported.html")]
	public sealed class InputGetStylusTouchSupported : BaseAction
	{
		
		[Tooltip("Get Input Stylus Touch Supported")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getStylusTouchSupported;
		
		public override bool CanExecute() => CheckParameters(_getStylusTouchSupported);

		public override void Execute() => _getStylusTouchSupported.Value = Input.stylusTouchSupported;

		public override string GetSummary() => "Get StylusTouchSupported -> {_getStylusTouchSupported} ";
	}
}
