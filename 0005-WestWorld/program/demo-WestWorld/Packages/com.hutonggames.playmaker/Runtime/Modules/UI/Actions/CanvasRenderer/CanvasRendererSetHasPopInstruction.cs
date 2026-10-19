
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CanvasRenderer)]
	[ActionDescription("Enable \'render stack\' pop draw call.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CanvasRenderer-hasPopInstruction.html")]
	public sealed class CanvasRendererSetHasPopInstruction : BaseAction
	{
		
		[Tooltip("The CanvasRenderer")]
		[SerializeField]
		private CanvasRendererVar _canvasRenderer;
		
		[Tooltip("Set CanvasRenderer Has Pop Instruction")]
		[SerializeField]
		private BoolVar _setHasPopInstruction;
		
		public override bool CanExecute()
		{
			return CheckParameters(_canvasRenderer, _setHasPopInstruction);
		}
		
		public override void Execute()
		{
			_canvasRenderer.Value.hasPopInstruction = _setHasPopInstruction.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_canvasRenderer} has pop instruction to {_setHasPopInstruction}";
		}
	}
}
