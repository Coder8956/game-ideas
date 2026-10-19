
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Image)]
	[ActionDescription("Pixel per unit modifier to change how sliced sprites are generated.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Image.html")]
	public sealed class ImageSetPixelsPerUnitMultiplier : BaseAction
	{
		
		[Tooltip("The Image")]
		[SerializeField]
		private ImageVar _image;
		
		[Tooltip("Set Image Pixels Per Unit Multiplier")]
		[SerializeField]
		private FloatVar _setPixelsPerUnitMultiplier;
		
		public override bool CanExecute()
		{
			return CheckParameters(_image, _setPixelsPerUnitMultiplier);
		}
		
		public override void Execute()
		{
			_image.Value.pixelsPerUnitMultiplier = _setPixelsPerUnitMultiplier.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_image} pixels per unit multiplier to {_setPixelsPerUnitMultiplier}";
		}
	}
}
