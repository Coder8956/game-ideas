
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Image)]
	[ActionDescription("The alpha threshold specifies the minimum alpha a pixel must have for the event t" +
		"o considered a \"hit\" on the Image.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Image.html")]
	public sealed class ImageSetAlphaHitTestMinimumThreshold : BaseAction
	{
		
		[Tooltip("The Image")]
		[SerializeField]
		private ImageVar _image;
		
		[Tooltip("Set Image Alpha Hit Test Minimum Threshold")]
		[SerializeField]
		private FloatVar _setAlphaHitTestMinimumThreshold;
		
		public override bool CanExecute()
		{
			return CheckParameters(_image, _setAlphaHitTestMinimumThreshold);
		}
		
		public override void Execute()
		{
			_image.Value.alphaHitTestMinimumThreshold = _setAlphaHitTestMinimumThreshold.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_image} alpha hit test minimum threshold to {_setAlphaHitTestMinimumThreshold}";
		}
	}
}
