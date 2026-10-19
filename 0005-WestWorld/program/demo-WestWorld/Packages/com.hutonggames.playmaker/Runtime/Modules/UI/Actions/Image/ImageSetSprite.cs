
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Image)]
	[ActionDescription("The sprite that is used to render this image.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Image.html")]
	public sealed class ImageSetSprite : BaseAction
	{
		
		[Tooltip("The Image")]
		[SerializeField]
		private ImageVar _image;
		
		[Tooltip("Set Image Sprite")]
		[SerializeField, CanBeNullOrEmpty]
		private SpriteVar _setSprite;
		
		public override bool CanExecute() => CheckParameters(_image);

		public override void Execute() => _image.Value.sprite = _setSprite?.Value;

		public override string GetSummary() => "Set {_image} sprite to {_setSprite}";
	}
}
