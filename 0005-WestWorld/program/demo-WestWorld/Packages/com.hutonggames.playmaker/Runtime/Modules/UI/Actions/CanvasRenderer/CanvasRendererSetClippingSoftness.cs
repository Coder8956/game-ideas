
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CanvasRenderer)]
	[ActionDescription("The clipping softness to apply to the renderer.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CanvasRenderer-clippingSoftness.html")]
	public sealed class CanvasRendererSetClippingSoftness : BaseAction
	{
		
		[Tooltip("The CanvasRenderer")]
		[SerializeField]
		private CanvasRendererVar _canvasRenderer;
		
		[Tooltip("Set CanvasRenderer Clipping Softness")]
		[SerializeField]
		private Vector2Var _setClippingSoftness;
		
		public override bool CanExecute()
		{
			return CheckParameters(_canvasRenderer, _setClippingSoftness);
		}
		
		public override void Execute()
		{
			_canvasRenderer.Value.clippingSoftness = _setClippingSoftness.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_canvasRenderer} clipping softness to {_setClippingSoftness}";
		}
	}
}
