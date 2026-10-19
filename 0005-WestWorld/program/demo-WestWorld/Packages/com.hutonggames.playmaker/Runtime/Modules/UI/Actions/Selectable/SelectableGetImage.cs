
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Selectable)]
	[ActionDescription("Convenience function that converts the referenced Graphic to a Image, if possible")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.UI.Selectable.html")]
	public sealed class SelectableGetImage : BaseAction
	{
		
		[Tooltip("The Selectable")]
		[SerializeField]
		private SelectableVar _selectable;
		
		[Tooltip("Get Selectable Image")]
		[SerializeField]
		[WriteOnly]
		private ImageRef _getImage;
		
		public override bool CanExecute()
		{
			return CheckParameters(_selectable, _getImage);
		}
		
		public override void Execute()
		{
			_getImage.Value = _selectable.Value.image;
		}
		
		public override string GetSummary()
		{
			return "Get {_selectable} image -> {_getImage}";
		}
	}
}
