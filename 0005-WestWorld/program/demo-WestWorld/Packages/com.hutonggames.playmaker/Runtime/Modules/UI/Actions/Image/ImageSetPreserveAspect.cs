
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Image)]
	[ActionDescription("Whether this image should preserve its Sprite aspect ratio.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Image.html")]
	public sealed class ImageSetPreserveAspect : BaseAction
	{
		
		[Tooltip("The Image")]
		[SerializeField]
		private ImageVar _image;
		
		[Tooltip("Set Image Preserve Aspect")]
		[SerializeField]
		private BoolVar _setPreserveAspect;
		
		public override bool CanExecute()
		{
			return CheckParameters(_image, _setPreserveAspect);
		}
		
		public override void Execute()
		{
			_image.Value.preserveAspect = _setPreserveAspect.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_image} preserve aspect to {_setPreserveAspect}";
		}
	}
}
