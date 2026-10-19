
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Selectable)]
	[ActionDescription("Convenience function that converts the referenced Graphic to a Image, if possible.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.UI.Selectable.html")]
	public sealed class SelectableSetImage : BaseAction
	{
		
		[Tooltip("The Selectable")]
		[SerializeField]
		private SelectableVar _selectable;
		
		[Tooltip("Set Selectable Image")]
		[SerializeField, CanBeNullOrEmpty]
		private ImageVar _setImage;
		
		public override bool CanExecute()
		{
			return CheckParameters(_selectable);
		}
		
		public override void Execute()
		{
			_selectable.Value.image = _setImage.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_selectable} image to {_setImage}";
		}
	}
}
