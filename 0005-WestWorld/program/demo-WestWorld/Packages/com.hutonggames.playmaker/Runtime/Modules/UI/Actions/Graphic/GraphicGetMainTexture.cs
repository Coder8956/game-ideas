
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Graphic)]
	[ActionDescription("The graphic\'s texture. (Read Only).")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.UI.Graphic.html")]
	public sealed class GraphicGetMainTexture : BaseAction
	{
		
		[Tooltip("The Graphic")]
		[SerializeField]
		private GraphicVar _graphic;
		
		[Tooltip("Get Graphic Main Texture")]
		[SerializeField]
		[WriteOnly]
		private TextureRef _getMainTexture;
		
		public override bool CanExecute()
		{
			return CheckParameters(_graphic, _getMainTexture);
		}
		
		public override void Execute()
		{
			_getMainTexture.Value = _graphic.Value.mainTexture;
		}
		
		public override string GetSummary()
		{
			return "Get {_graphic} main texture -> {_getMainTexture}";
		}
	}
}
