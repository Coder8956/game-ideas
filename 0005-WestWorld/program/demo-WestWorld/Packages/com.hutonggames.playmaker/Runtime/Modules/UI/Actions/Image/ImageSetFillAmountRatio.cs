
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Image)]
	[ActionDescription("Set an Image fill using the ratio of two floats. e.g., current health / max health.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Image.html")]
	public sealed class ImageSetFillAmountRatio : BaseAction
	{
		
		[Tooltip("The Image")]
		[SerializeField]
		private ImageVar _image;
		
		[Tooltip("The current value")]
		[SerializeField]
		private FloatVar _value;
		
		[Tooltip("Teh max value used to calculate the fill amount")]
		[SerializeField]
		private FloatVar _maxValue;
		
		public override bool CanExecute() => CheckParameters(_image, _value, _maxValue);

		public override void Execute() => _image.Value.fillAmount = _value.Value/_maxValue.Value;

		public override string GetSummary() => "Set {_image} fill amount to {_value} / {_maxValue}";
	}
}
