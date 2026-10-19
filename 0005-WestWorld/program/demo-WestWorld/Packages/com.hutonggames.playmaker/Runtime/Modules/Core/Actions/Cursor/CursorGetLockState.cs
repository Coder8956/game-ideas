
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
	public sealed class CursorGetLockState : BaseAction
	{
		
		[Tooltip("Get Cursor Lock State")]
		[SerializeField]
		[WriteOnly]
		private CursorLockModeRef _getLockState;
		
		public override bool CanExecute() => CheckParameters(_getLockState);

		public override void Execute() => _getLockState.Value = Cursor.lockState;

		public override string GetSummary() => "Get Cursor Lock State -> {_getLockState} ";
	}
}
