
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Cursor)]
	[ActionDescription("Determines whether the hardware pointer is locked to the center of the view, cons" +
		"trained to the window, or not constrained at all.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Cursor-lockState.html")]
	public sealed class CursorSetLockState : BaseAction
	{
		
		[Tooltip("Set Cursor Lock State")]
		[SerializeField]
		private CursorLockModeVar _setLockState;
		
		public override bool CanExecute() => CheckParameters(_setLockState);

		public override void Execute() => Cursor.lockState = _setLockState.Value;

		public override string GetSummary() => "Set Cursor Lock State to {_setLockState}";
	}
}
