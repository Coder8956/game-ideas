
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Dropdown)]
	[ActionDescription("The time interval at which a drop down will appear and disappear")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Dropdown.html")]
	public sealed class TMP_DropdownGetAlphaFadeSpeed : BaseAction
	{
		
		[Tooltip("The TMP_Dropdown")]
		[SerializeField]
		private TMP_DropdownVar _tMP_Dropdown;
		
		[Tooltip("Get TMP_Dropdown Alpha Fade Speed")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getAlphaFadeSpeed;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Dropdown, _getAlphaFadeSpeed);
		}
		
		public override void Execute()
		{
			_getAlphaFadeSpeed.Value = _tMP_Dropdown.Value.alphaFadeSpeed;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Dropdown} alpha fade speed -> {_getAlphaFadeSpeed}";
		}
	}
}
