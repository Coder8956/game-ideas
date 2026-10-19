
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CanvasRenderer)]
	[ActionDescription("The number of materials usable by this renderer.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CanvasRenderer-materialCount.html")]
	public sealed class CanvasRendererSetMaterialCount : BaseAction
	{
		
		[Tooltip("The CanvasRenderer")]
		[SerializeField]
		private CanvasRendererVar _canvasRenderer;
		
		[Tooltip("Set CanvasRenderer Material Count")]
		[SerializeField]
		private IntegerVar _setMaterialCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_canvasRenderer, _setMaterialCount);
		}
		
		public override void Execute()
		{
			_canvasRenderer.Value.materialCount = _setMaterialCount.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_canvasRenderer} material count to {_setMaterialCount}";
		}
	}
}
