
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_RawImage)]
	[ActionDescription("The RawImage's texture.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-RawImage.html")]
	public sealed class RawImageGetTexture : BaseAction
	{
		
		[Tooltip("The RawImage")]
		[SerializeField]
		private RawImageVar _rawImage;
		
		[Tooltip("Get RawImage Texture")]
		[SerializeField]
		[WriteOnly]
		private TextureRef _getTexture;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rawImage, _getTexture);
		}
		
		public override void Execute()
		{
			_getTexture.Value = _rawImage.Value.texture;
		}
		
		public override string GetSummary()
		{
			return "Get {_rawImage} texture -> {_getTexture}";
		}
	}
}
