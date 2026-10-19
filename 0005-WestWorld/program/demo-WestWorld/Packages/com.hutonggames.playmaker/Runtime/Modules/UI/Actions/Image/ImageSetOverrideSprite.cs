
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Image)]
	[ActionDescription("Set an override sprite to be used for rendering.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Image.html")]
	public sealed class ImageSetOverrideSprite : BaseAction
	{
		
		[Tooltip("The Image")]
		[SerializeField]
		private ImageVar _image;
		
		[Tooltip("Set Image Override Sprite")]
		[SerializeField, CanBeNullOrEmpty]
		private SpriteVar _setOverrideSprite;
		
		public override bool CanExecute()
		{
			return CheckParameters(_image);
		}
		
		public override void Execute()
		{
			_image.Value.overrideSprite = _setOverrideSprite.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_image} override sprite to {_setOverrideSprite}";
		}
	}
}
