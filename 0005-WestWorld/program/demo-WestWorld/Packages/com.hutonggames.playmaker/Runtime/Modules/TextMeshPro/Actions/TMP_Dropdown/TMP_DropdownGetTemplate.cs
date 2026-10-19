
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Dropdown)]
	[ActionDescription("The Rect Transform of the template for the dropdown list.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Dropdown.html")]
	public sealed class TMP_DropdownGetTemplate : BaseAction
	{
		
		[Tooltip("The TMP_Dropdown")]
		[SerializeField]
		private TMP_DropdownVar _tMP_Dropdown;
		
		[Tooltip("Get TMP_Dropdown Template")]
		[SerializeField]
		[WriteOnly]
		private RectTransformVar _getTemplate;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Dropdown, _getTemplate);
		}
		
		public override void Execute()
		{
			_getTemplate.Value = _tMP_Dropdown.Value.template;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Dropdown} template -> {_getTemplate}";
		}
	}
}
