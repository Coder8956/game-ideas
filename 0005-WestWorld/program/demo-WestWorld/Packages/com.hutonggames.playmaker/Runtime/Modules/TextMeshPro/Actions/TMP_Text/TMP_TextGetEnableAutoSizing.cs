
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Enable text auto-sizing")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetEnableAutoSizing : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Enable Auto Sizing")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getEnableAutoSizing;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getEnableAutoSizing);
		}
		
		public override void Execute()
		{
			_getEnableAutoSizing.Value = _tMP_Text.Value.enableAutoSizing;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} enable auto sizing -> {_getEnableAutoSizing}";
		}
	}
}
