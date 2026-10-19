#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM && !ENABLE_LEGACY_INPUT_MANAGER
#define NEW_INPUT_SYSTEM_ONLY
using System;
#endif

using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	
#if NEW_INPUT_SYSTEM_ONLY
	[System.Obsolete(Strings.RequiresLegacyInputSystem)]
#endif
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Keyboard)]
	[ActionDescription("Returns the keyboard input entered this frame. (Read Only)")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Input-inputString.html")]
	public sealed class InputGetInputString : BaseLegacyInputAction
	{
		
		[Tooltip("Get Input Input String")]
		[SerializeField]
		[WriteOnly]
		private StringRef _getInputString;
		
		public override bool CanExecute() => base.CanExecute() && CheckParameters(_getInputString);
		
#if !NEW_INPUT_SYSTEM_ONLY
		public override void Execute() => _getInputString.Value = Input.inputString;
#endif
		public override string GetSummary() => "Get InputString -> {_getInputString} ";
	}
}
