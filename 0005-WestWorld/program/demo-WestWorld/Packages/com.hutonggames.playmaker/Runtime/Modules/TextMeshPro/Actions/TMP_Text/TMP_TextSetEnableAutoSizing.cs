
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Enable text auto-sizing")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetEnableAutoSizing : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Enable Auto Sizing")]
		[SerializeField]
		private BoolVar _setEnableAutoSizing;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setEnableAutoSizing);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.enableAutoSizing = _setEnableAutoSizing.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} enable auto sizing to {_setEnableAutoSizing}";
		}
	}
}
