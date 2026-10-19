
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Dropdown)]
	[ActionDescription("The Image component to hold the image of the item")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Dropdown.html")]
	public sealed class TMP_DropdownSetItemImage : BaseAction
	{
		
		[Tooltip("The TMP_Dropdown")]
		[SerializeField]
		private TMP_DropdownVar _tMP_Dropdown;
		
		[Tooltip("Set TMP_Dropdown Item Image")]
		[SerializeField, CanBeNullOrEmpty]
		private UI.ImageVar _setItemImage;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Dropdown);
		}
		
		public override void Execute()
		{
			_tMP_Dropdown.Value.itemImage = _setItemImage.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Dropdown} item image to {_setItemImage}";
		}
	}
}
