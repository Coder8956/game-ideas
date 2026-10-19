
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Dropdown)]
	[ActionDescription("The time interval at which a drop down will appear and disappear")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Dropdown.html")]
	public sealed class TMP_DropdownSetAlphaFadeSpeed : BaseAction
	{
		
		[Tooltip("The TMP_Dropdown")]
		[SerializeField]
		private TMP_DropdownVar _tMP_Dropdown;
		
		[Tooltip("Set TMP_Dropdown Alpha Fade Speed")]
		[SerializeField]
		private FloatVar _setAlphaFadeSpeed;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Dropdown, _setAlphaFadeSpeed);
		}
		
		public override void Execute()
		{
			_tMP_Dropdown.Value.alphaFadeSpeed = _setAlphaFadeSpeed.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Dropdown} alpha fade speed to {_setAlphaFadeSpeed}";
		}
	}
}
