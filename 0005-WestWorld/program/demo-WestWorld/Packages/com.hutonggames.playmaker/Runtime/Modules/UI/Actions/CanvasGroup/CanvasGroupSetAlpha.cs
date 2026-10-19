
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CanvasGroup)]
	[ActionDescription("Set the alpha of the group.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CanvasGroup-alpha.html")]
	public sealed class CanvasGroupSetAlpha : BaseAction
	{
		
		[Tooltip("The CanvasGroup")]
		[SerializeField]
		private CanvasGroupVar _canvasGroup;
		
		[Tooltip("Set CanvasGroup Alpha")]
		[SerializeField]
		private FloatVar _setAlpha;
		
		public override bool CanExecute()
		{
			return CheckParameters(_canvasGroup, _setAlpha);
		}
		
		public override void Execute()
		{
			_canvasGroup.Value.alpha = _setAlpha.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_canvasGroup} alpha to {_setAlpha}";
		}
	}
}
