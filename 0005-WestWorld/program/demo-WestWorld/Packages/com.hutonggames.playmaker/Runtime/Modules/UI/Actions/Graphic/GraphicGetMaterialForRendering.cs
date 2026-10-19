
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Graphic)]
	[ActionDescription("The material that will be sent for Rendering (Read only).")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.UI.Graphic.html")]
	public sealed class GraphicGetMaterialForRendering : BaseAction
	{
		
		[Tooltip("The Graphic")]
		[SerializeField]
		private GraphicVar _graphic;
		
		[Tooltip("Get Graphic Material For Rendering")]
		[SerializeField]
		[WriteOnly]
		private MaterialRef _getMaterialForRendering;
		
		public override bool CanExecute()
		{
			return CheckParameters(_graphic, _getMaterialForRendering);
		}
		
		public override void Execute()
		{
			_getMaterialForRendering.Value = _graphic.Value.materialForRendering;
		}
		
		public override string GetSummary()
		{
			return "Get {_graphic} material for rendering -> {_getMaterialForRendering}";
		}
	}
}
