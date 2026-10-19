
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CanvasRenderer)]
	[ActionDescription("The number of materials usable by this renderer. Used internally for masking.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CanvasRenderer-popMaterialCount.html")]
	public sealed class CanvasRendererSetPopMaterialCount : BaseAction
	{
		
		[Tooltip("The CanvasRenderer")]
		[SerializeField]
		private CanvasRendererVar _canvasRenderer;
		
		[Tooltip("Set CanvasRenderer Pop Material Count")]
		[SerializeField]
		private IntegerVar _setPopMaterialCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_canvasRenderer, _setPopMaterialCount);
		}
		
		public override void Execute()
		{
			_canvasRenderer.Value.popMaterialCount = _setPopMaterialCount.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_canvasRenderer} pop material count to {_setPopMaterialCount}";
		}
	}
}
