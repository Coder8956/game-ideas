
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Image)]
	[ActionDescription("Amount of the Image shown when the Image.type is set to Image.Type.Filled.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Image.html")]
	public sealed class ImageSetFillAmount : BaseAction
	{
		
		[Tooltip("The Image")]
		[SerializeField]
		private ImageVar _image;
		
		[Tooltip("Set Image Fill Amount")]
		[SerializeField]
		private FloatVar _setFillAmount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_image, _setFillAmount);
		}
		
		public override void Execute()
		{
			_image.Value.fillAmount = _setFillAmount.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_image} fill amount to {_setFillAmount}";
		}
	}
}
