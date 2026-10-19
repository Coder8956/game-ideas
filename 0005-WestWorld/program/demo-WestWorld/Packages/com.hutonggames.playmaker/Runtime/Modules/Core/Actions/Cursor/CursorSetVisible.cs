
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
	public sealed class CursorSetVisible : BaseAction
	{
		
		[Tooltip("Set Cursor Visible")]
		[SerializeField]
		private BoolVar _setVisible;
		
		public override bool CanExecute() => CheckParameters(_setVisible);

		public override void Execute() => Cursor.visible = _setVisible.Value;

		public override string GetSummary() => "Set Cursor Visible to {_setVisible}";
	}
}
