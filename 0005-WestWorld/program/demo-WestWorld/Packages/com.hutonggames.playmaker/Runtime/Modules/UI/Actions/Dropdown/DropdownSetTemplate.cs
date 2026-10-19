
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Dropdown)]
	[ActionDescription("The Rect Transform of the template for the dropdown list.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Dropdown.html")]
	public sealed class DropdownSetTemplate : BaseAction
	{
		
		[Tooltip("The Dropdown")]
		[SerializeField]
		private DropdownVar _dropdown;
		
		[Tooltip("Set Dropdown Template")]
		[SerializeField, CanBeNullOrEmpty]
		private RectTransformVar _setTemplate;
		
		public override bool CanExecute()
		{
			return CheckParameters(_dropdown);
		}
		
		public override void Execute()
		{
			_dropdown.Value.template = _setTemplate.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_dropdown} Template to {_setTemplate}";
		}
	}
}
