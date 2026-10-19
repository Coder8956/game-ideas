
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Image)]
	[ActionDescription("How to display the image.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Image.html")]
	public sealed class ImageSetType : BaseAction
	{
		
		[Tooltip("The Image")]
		[SerializeField]
		private ImageVar _image;
		
		[Tooltip("Set Image Type")]
		[SerializeField]
		private Image_TypeVar _setType;
		
		public override bool CanExecute()
		{
			return CheckParameters(_image, _setType);
		}
		
		public override void Execute()
		{
			_image.Value.type = _setType.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_image} type to {_setType}";
		}
	}
}
