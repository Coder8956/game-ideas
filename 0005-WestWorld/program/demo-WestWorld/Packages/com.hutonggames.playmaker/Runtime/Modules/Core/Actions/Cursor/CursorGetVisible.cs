
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Cursor)]
	[ActionDescription("Determines whether the hardware pointer is visible or not.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Cursor-visible.html")]
	public sealed class CursorGetVisible : BaseAction
	{
		
		[Tooltip("Get Cursor Visible")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getVisible;
		
		public override bool CanExecute() => CheckParameters(_getVisible);

		public override void Execute() => _getVisible.Value = Cursor.visible;

		public override string GetSummary() => "Get Cursor Visible -> {_getVisible} ";
	}
}
