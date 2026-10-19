
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Dropdown)]
	[ActionDescription("The Image component to hold the image of the item.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Dropdown.html")]
	public sealed class DropdownSetItemImage : BaseAction
	{
		
		[Tooltip("The Dropdown")]
		[SerializeField]
		private DropdownVar _dropdown;
		
		[Tooltip("Set Dropdown Item Image")]
		[SerializeField, CanBeNullOrEmpty]
		private ImageVar _setItemImage;
		
		public override bool CanExecute()
		{
			return CheckParameters(_dropdown);
		}
		
		public override void Execute()
		{
			_dropdown.Value.itemImage = _setItemImage.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_dropdown} Item Image to {_setItemImage}";
		}
	}
}
