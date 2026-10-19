
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.KeyboardIME)]
	[ActionDescription("The current text input position used by IMEs to open windows.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Input-compositionCursorPos.html")]
	public sealed class InputGetCompositionCursorPos : BaseAction
	{
		
		[Tooltip("Get Input Composition Cursor Pos")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getCompositionCursorPos;
		
		public override bool CanExecute() => CheckParameters(_getCompositionCursorPos);

		public override void Execute() => _getCompositionCursorPos.Value = Input.compositionCursorPos;

		public override string GetSummary() => "Get CompositionCursorPos -> {_getCompositionCursorPos} ";
	}
}
