
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.InputSettings)]
	[ActionDescription("Controls enabling and disabling of IME input composition.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Input-imeCompositionMode.html")]
	public sealed class InputGetImeCompositionMode : BaseAction
	{
		
		[Tooltip("Get Input Ime Composition Mode")]
		[SerializeField]
		[WriteOnly]
		private IMECompositionModeRef _getImeCompositionMode;
		
		public override bool CanExecute() => CheckParameters(_getImeCompositionMode);

		public override void Execute() => _getImeCompositionMode.Value = Input.imeCompositionMode;

		public override string GetSummary() => "Get IME CompositionMode -> {_getImeCompositionMode} ";
	}
}
