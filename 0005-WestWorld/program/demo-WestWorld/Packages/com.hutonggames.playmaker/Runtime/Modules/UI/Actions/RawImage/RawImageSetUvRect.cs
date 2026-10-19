
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_RawImage)]
	[ActionDescription("The RawImage texture coordinates.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-RawImage.html")]
	public sealed class RawImageSetUvRect : BaseAction
	{
		
		[Tooltip("The RawImage")]
		[SerializeField]
		private RawImageVar _rawImage;
		
		[Tooltip("Set RawImage Uv Rect")]
		[SerializeField]
		private RectVar _setUvRect;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rawImage, _setUvRect);
		}
		
		public override void Execute()
		{
			_rawImage.Value.uvRect = _setUvRect.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rawImage} UV rect to {_setUvRect}";
		}
	}
}
