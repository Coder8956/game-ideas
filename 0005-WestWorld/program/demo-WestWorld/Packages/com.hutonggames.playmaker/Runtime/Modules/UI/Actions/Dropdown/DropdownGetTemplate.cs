
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Dropdown)]
	[ActionDescription("The Rect Transform of the template for the dropdown list.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Dropdown.html")]
	public sealed class DropdownGetTemplate : BaseAction
	{
		
		[Tooltip("The Dropdown")]
		[SerializeField]
		private DropdownVar _dropdown;
		
		[Tooltip("Get Dropdown Template")]
		[SerializeField]
		[WriteOnly]
		private RectTransformVar _getTemplate;
		
		public override bool CanExecute()
		{
			return CheckParameters(_dropdown, _getTemplate);
		}
		
		public override void Execute()
		{
			_getTemplate.Value = _dropdown.Value.template;
		}
		
		public override string GetSummary()
		{
			return "Get {_dropdown} Template -> {_getTemplate}";
		}
	}
}
