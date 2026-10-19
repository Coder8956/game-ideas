
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Graphic)]
	[ActionDescription("Get the base color of the Graphic.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.UI.Graphic.html")]
	public sealed class GraphicGetColor : BaseAction
	{
		
		[Tooltip("The Graphic")]
		[SerializeField]
		private GraphicVar _graphic;
		
		[Tooltip("Get Graphic Color")]
		[SerializeField]
		[WriteOnly]
		private ColorRef _getColor;
		
		public override bool CanExecute()
		{
			return CheckParameters(_graphic, _getColor);
		}
		
		public override void Execute()
		{
			_getColor.Value = _graphic.Value.color;
		}
		
		public override string GetSummary()
		{
			return "Get {_graphic} color -> {_getColor}";
		}
	}
}
