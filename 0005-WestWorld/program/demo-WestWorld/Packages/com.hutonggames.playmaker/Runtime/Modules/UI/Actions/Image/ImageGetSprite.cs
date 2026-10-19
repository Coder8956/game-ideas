
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Image)]
	[ActionDescription("The sprite that is used to render this image.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Image.html")]
	public sealed class ImageGetSprite : BaseAction
	{
		
		[Tooltip("The Image")]
		[SerializeField]
		private ImageVar _image;
		
		[Tooltip("Get Image Sprite")]
		[SerializeField]
		[WriteOnly]
		private SpriteRef _getSprite;
		
		public override bool CanExecute()
		{
			return CheckParameters(_image, _getSprite);
		}
		
		public override void Execute()
		{
			_getSprite.Value = _image.Value.sprite;
		}
		
		public override string GetSummary()
		{
			return "Get {_image} sprite -> {_getSprite}";
		}
	}
}
