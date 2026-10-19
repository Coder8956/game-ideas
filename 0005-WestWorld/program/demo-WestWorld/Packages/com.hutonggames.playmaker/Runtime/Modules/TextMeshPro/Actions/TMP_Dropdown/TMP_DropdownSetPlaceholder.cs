
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Dropdown)]
	[ActionDescription("The placeholder Graphic component. Shown when no option is selected.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Dropdown.html")]
	public sealed class TMP_DropdownSetPlaceholder : BaseAction
	{
		
		[Tooltip("The TMP_Dropdown")]
		[SerializeField]
		private TMP_DropdownVar _tMP_Dropdown;
		
		[Tooltip("Set TMP_Dropdown Placeholder")]
		[SerializeField, CanBeNullOrEmpty]
		private UI.GraphicVar _setPlaceholder;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Dropdown);
		}
		
		public override void Execute()
		{
			_tMP_Dropdown.Value.placeholder = _setPlaceholder.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Dropdown} placeholder to {_setPlaceholder}";
		}
	}
}
