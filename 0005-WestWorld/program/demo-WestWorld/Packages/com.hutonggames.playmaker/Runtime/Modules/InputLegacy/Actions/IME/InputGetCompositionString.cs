
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.KeyboardIME)]
	[ActionDescription("The current IME composition string being typed by the user.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Input-compositionString.html")]
	public sealed class InputGetCompositionString : BaseAction
	{
		
		[Tooltip("Get Input Composition String")]
		[SerializeField]
		[WriteOnly]
		private StringRef _getCompositionString;
		
		public override bool CanExecute() => CheckParameters(_getCompositionString);

		public override void Execute() => _getCompositionString.Value = Input.compositionString;

		public override string GetSummary() => "Get CompositionString -> {_getCompositionString} ";
	}
}
