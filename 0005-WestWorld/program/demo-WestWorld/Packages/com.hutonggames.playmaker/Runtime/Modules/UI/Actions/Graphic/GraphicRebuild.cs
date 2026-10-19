
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Graphic)]
	[ActionDescription("Rebuilds the graphic geometry and its material on the PreRender cycle.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.UI.Graphic.html")]
	public sealed class GraphicRebuild : BaseAction
	{
		
		[Tooltip("The Graphic.")]
		[SerializeField]
		private GraphicVar _graphic;
		
		[Tooltip("The current step of the rendering CanvasUpdate cycle.")]
		[SerializeField]
		private CanvasUpdateVar _update;
		
		public override bool CanExecute()
		{
			return CheckParameters(_graphic, _update);
		}
		
		public override void Execute()
		{
			//UnityEngine.UI.Graphic.Rebuild(UnityEngine.UI.CanvasUpdate);
			_graphic.Value.Rebuild(_update.Value);
		}
		
		public override string GetSummary()
		{
			return "Rebuild {_graphic} {_update}";
		}
	}
}
