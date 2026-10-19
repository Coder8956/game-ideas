
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.InputSettings)]
	[ActionDescription("Controls enabling and disabling of IME input composition.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Input-imeCompositionMode.html")]
	public sealed class InputSetImeCompositionMode : BaseAction
	{
		
		[Tooltip("Set Input Ime Composition Mode")]
		[SerializeField]
		private IMECompositionModeVar _setImeCompositionMode;
		
		public override bool CanExecute() => CheckParameters(_setImeCompositionMode);

		public override void Execute() => Input.imeCompositionMode = _setImeCompositionMode.Value;

		public override string GetSummary() => "Set IME CompositionMode to {_setImeCompositionMode}";
	}
}
