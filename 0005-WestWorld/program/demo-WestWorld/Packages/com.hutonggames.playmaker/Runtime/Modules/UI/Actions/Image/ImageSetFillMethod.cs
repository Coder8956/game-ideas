
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Image)]
	[ActionDescription("What type of fill method to use.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Image.html")]
	public sealed class ImageSetFillMethod : BaseAction
	{
		
		[Tooltip("The Image")]
		[SerializeField]
		private ImageVar _image;
		
		[Tooltip("Set Image Fill Method")]
		[SerializeField]
		private Image_FillMethodVar _setFillMethod;
		
		public override bool CanExecute()
		{
			return CheckParameters(_image, _setFillMethod);
		}
		
		public override void Execute()
		{
			_image.Value.fillMethod = _setFillMethod.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_image} fill method to {_setFillMethod}";
		}
	}
}
