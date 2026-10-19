
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.KeyboardIME)]
	[ActionDescription("The current text input position used by IMEs to open windows.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Input-compositionCursorPos.html")]
	public sealed class InputSetCompositionCursorPos : BaseAction
	{
		
		[Tooltip("Set Input Composition Cursor Pos")]
		[SerializeField]
		private Vector2Var _setCompositionCursorPos;
		
		public override bool CanExecute() => CheckParameters(_setCompositionCursorPos);

		public override void Execute() => Input.compositionCursorPos = _setCompositionCursorPos.Value;

		public override string GetSummary() => "Set CompositionCursorPos to {_setCompositionCursorPos}";
	}
}
