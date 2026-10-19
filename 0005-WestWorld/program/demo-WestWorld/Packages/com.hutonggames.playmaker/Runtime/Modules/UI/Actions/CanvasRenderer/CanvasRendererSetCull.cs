
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CanvasRenderer)]
	[ActionDescription("Indicates whether geometry emitted by this renderer is ignored.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CanvasRenderer-cull.html")]
	public sealed class CanvasRendererSetCull : BaseAction
	{
		
		[Tooltip("The CanvasRenderer")]
		[SerializeField]
		private CanvasRendererVar _canvasRenderer;
		
		[Tooltip("Set CanvasRenderer Cull")]
		[SerializeField]
		private BoolVar _setCull;
		
		public override bool CanExecute()
		{
			return CheckParameters(_canvasRenderer, _setCull);
		}
		
		public override void Execute()
		{
			_canvasRenderer.Value.cull = _setCull.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_canvasRenderer} cull to {_setCull}";
		}
	}
}
