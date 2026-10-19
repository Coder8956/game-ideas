
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Image)]
	[ActionDescription("Adjusts the image size to make it pixel-perfect.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Image.html")]
	public sealed class ImageSetNativeSize : BaseAction
	{
		
		[Tooltip("The Image.")]
		[SerializeField]
		private ImageVar _image;
		
		public override bool CanExecute()
		{
			return CheckParameters(_image);
		}
		
		public override void Execute()
		{
			//UnityEngine.UI.Image.SetNativeSize();
			_image.Value.SetNativeSize();
		}
		
		public override string GetSummary()
		{
			return "Set {_image} native size";
		}
	}
}
