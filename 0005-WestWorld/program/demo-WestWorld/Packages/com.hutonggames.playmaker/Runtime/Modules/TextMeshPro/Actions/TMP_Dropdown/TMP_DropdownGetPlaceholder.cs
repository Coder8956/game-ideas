
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Dropdown)]
	[ActionDescription("The placeholder Graphic component. Shown when no option is selected.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Dropdown.html")]
	public sealed class TMP_DropdownGetPlaceholder : BaseAction
	{
		
		[Tooltip("The TMP_Dropdown")]
		[SerializeField]
		private TMP_DropdownVar _tMP_Dropdown;
		
		[Tooltip("Get TMP_Dropdown Placeholder")]
		[SerializeField]
		[WriteOnly]
		private UI.GraphicVar _getPlaceholder;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Dropdown, _getPlaceholder);
		}
		
		public override void Execute()
		{
			_getPlaceholder.Value = _tMP_Dropdown.Value.placeholder;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Dropdown} placeholder -> {_getPlaceholder}";
		}
	}
}
