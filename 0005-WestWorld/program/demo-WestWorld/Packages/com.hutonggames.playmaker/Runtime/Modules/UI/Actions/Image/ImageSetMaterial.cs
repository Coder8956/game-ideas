
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Image)]
	[ActionDescription("The specified Material used by this Image. The default Material is used instead i" +
		"f one wasn\'t specified.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Image.html")]
	public sealed class ImageSetMaterial : BaseAction
	{
		
		[Tooltip("The Image")]
		[SerializeField]
		private ImageVar _image;
		
		[Tooltip("Set Image Material")]
		[SerializeField, CanBeNullOrEmpty]
		private MaterialVar _setMaterial;
		
		public override bool CanExecute()
		{
			return CheckParameters(_image);
		}
		
		public override void Execute()
		{
			_image.Value.material = _setMaterial.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_image} material to {_setMaterial}";
		}
	}
}
