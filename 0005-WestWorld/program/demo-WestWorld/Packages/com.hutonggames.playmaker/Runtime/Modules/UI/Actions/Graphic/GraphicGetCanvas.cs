
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Graphic)]
	[ActionDescription("A reference to the Canvas this Graphic is rendering to.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.UI.Graphic.html")]
	public sealed class GraphicGetCanvas : BaseAction
	{
		
		[Tooltip("The Graphic")]
		[SerializeField]
		private GraphicVar _graphic;
		
		[Tooltip("Get Graphic Canvas")]
		[SerializeField]
		[WriteOnly]
		private CanvasVar _getCanvas;
		
		public override bool CanExecute()
		{
			return CheckParameters(_graphic, _getCanvas);
		}
		
		public override void Execute()
		{
			_getCanvas.Value = _graphic.Value.canvas;
		}
		
		public override string GetSummary()
		{
			return "Get {_graphic} canvas -> {_getCanvas}";
		}
	}
}
