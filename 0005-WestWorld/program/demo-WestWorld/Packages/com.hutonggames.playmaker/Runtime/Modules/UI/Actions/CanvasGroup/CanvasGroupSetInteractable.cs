
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CanvasGroup)]
	[ActionDescription("Is the group interactable (are the elements beneath the group enabled).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CanvasGroup-interactable.html")]
	public sealed class CanvasGroupSetInteractable : BaseAction
	{
		
		[Tooltip("The CanvasGroup")]
		[SerializeField]
		private CanvasGroupVar _canvasGroup;
		
		[Tooltip("Set CanvasGroup Interactable")]
		[SerializeField]
		private BoolVar _setInteractable;
		
		public override bool CanExecute()
		{
			return CheckParameters(_canvasGroup, _setInteractable);
		}
		
		public override void Execute()
		{
			_canvasGroup.Value.interactable = _setInteractable.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_canvasGroup} interactable to {_setInteractable}";
		}
	}
}
