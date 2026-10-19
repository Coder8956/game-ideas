
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CanvasGroup)]
	[ActionDescription("Does this group block raycasting (allow collision).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CanvasGroup-blocksRaycasts.html")]
	public sealed class CanvasGroupSetBlocksRaycasts : BaseAction
	{
		
		[Tooltip("The CanvasGroup")]
		[SerializeField]
		private CanvasGroupVar _canvasGroup;
		
		[Tooltip("Set CanvasGroup Blocks Raycasts")]
		[SerializeField]
		private BoolVar _setBlocksRaycasts;
		
		public override bool CanExecute()
		{
			return CheckParameters(_canvasGroup, _setBlocksRaycasts);
		}
		
		public override void Execute()
		{
			_canvasGroup.Value.blocksRaycasts = _setBlocksRaycasts.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_canvasGroup} blocks raycasts to {_setBlocksRaycasts}";
		}
	}
}
