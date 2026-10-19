
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_RawImage)]
	[ActionDescription("The RawImage's texture.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-RawImage.html")]
	public sealed class RawImageSetTexture : BaseAction
	{
		
		[Tooltip("The RawImage")]
		[SerializeField]
		private RawImageVar _rawImage;
		
		[Tooltip("Set RawImage Texture")]
		[SerializeField, CanBeNullOrEmpty]
		private TextureVar _setTexture;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rawImage);
		}
		
		public override void Execute()
		{
			_rawImage.Value.texture = _setTexture.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rawImage} texture to {_setTexture}";
		}
	}
}
