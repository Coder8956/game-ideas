
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Dropdown)]
	[ActionDescription("The Image component to hold the image of the item")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Dropdown.html")]
	public sealed class TMP_DropdownGetItemImage : BaseAction
	{
		
		[Tooltip("The TMP_Dropdown")]
		[SerializeField]
		private TMP_DropdownVar _tMP_Dropdown;
		
		[Tooltip("Get TMP_Dropdown Item Image")]
		[SerializeField]
		[WriteOnly]
		private UI.ImageRef _getItemImage;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Dropdown, _getItemImage);
		}
		
		public override void Execute()
		{
			_getItemImage.Value = _tMP_Dropdown.Value.itemImage;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Dropdown} item image -> {_getItemImage}";
		}
	}
}
