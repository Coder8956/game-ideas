
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CanvasGroup)]
	[ActionDescription("Should the group ignore parent groups?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CanvasGroup-ignoreParentGroups.html")]
	public sealed class CanvasGroupSetIgnoreParentGroups : BaseAction
	{
		
		[Tooltip("The CanvasGroup")]
		[SerializeField]
		private CanvasGroupVar _canvasGroup;
		
		[Tooltip("Set CanvasGroup Ignore Parent Groups")]
		[SerializeField]
		private BoolVar _setIgnoreParentGroups;
		
		public override bool CanExecute()
		{
			return CheckParameters(_canvasGroup, _setIgnoreParentGroups);
		}
		
		public override void Execute()
		{
			_canvasGroup.Value.ignoreParentGroups = _setIgnoreParentGroups.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_canvasGroup} ignore parent groups to {_setIgnoreParentGroups}";
		}
	}
}
