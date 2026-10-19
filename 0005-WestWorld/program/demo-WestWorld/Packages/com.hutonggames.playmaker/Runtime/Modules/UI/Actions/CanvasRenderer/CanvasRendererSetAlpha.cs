
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CanvasRenderer)]
	[ActionDescription("Set the alpha of the renderer. Will be multiplied with the UIVertex alpha and the" +
		" Canvas alpha.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CanvasRenderer.SetAlpha.html")]
	public sealed class CanvasRendererSetAlpha : BaseAction
	{
		
		[Tooltip("The CanvasRenderer.")]
		[SerializeField]
		private CanvasRendererVar _canvasRenderer;
		
		[Tooltip("Alpha.")]
		[SerializeField]
		private FloatVar _alpha;
		
		public override bool CanExecute()
		{
			return CheckParameters(_canvasRenderer, _alpha);
		}
		
		public override void Execute()
		{
			//UnityEngine.CanvasRenderer.SetAlpha(System.Single);
			_canvasRenderer.Value.SetAlpha(_alpha.Value);
		}
		
		public override string GetSummary()
		{
			return "Set {_canvasRenderer} alpha to {_alpha}";
		}
	}
}
