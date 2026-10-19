
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_RawImage)]
	[ActionDescription("The RawImage's texture. (ReadOnly).")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-RawImage.html")]
	public sealed class RawImageGetMainTexture : BaseAction
	{
		
		[Tooltip("The RawImage")]
		[SerializeField]
		private RawImageVar _rawImage;
		
		[Tooltip("Get RawImage Main Texture")]
		[SerializeField]
		[WriteOnly]
		private TextureRef _getMainTexture;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rawImage, _getMainTexture);
		}
		
		public override void Execute()
		{
			_getMainTexture.Value = _rawImage.Value.mainTexture;
		}
		
		public override string GetSummary()
		{
			return "Get {_rawImage} main texture -> {_getMainTexture}";
		}
	}
}
