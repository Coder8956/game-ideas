
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Image)]
	[ActionDescription("Whether or not to render the center of a Tiled or Sliced image.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Image.html")]
	public sealed class ImageSetFillCenter : BaseAction
	{
		
		[Tooltip("The Image")]
		[SerializeField]
		private ImageVar _image;
		
		[Tooltip("Set Image Fill Center")]
		[SerializeField]
		private BoolVar _setFillCenter;
		
		public override bool CanExecute()
		{
			return CheckParameters(_image, _setFillCenter);
		}
		
		public override void Execute()
		{
			_image.Value.fillCenter = _setFillCenter.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_image} fill center to {_setFillCenter}";
		}
	}
}
