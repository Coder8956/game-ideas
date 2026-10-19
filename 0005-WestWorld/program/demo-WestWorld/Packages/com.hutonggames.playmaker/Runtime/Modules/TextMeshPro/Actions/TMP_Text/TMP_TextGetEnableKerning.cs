
using JetBrains.Annotations;
using UnityEngine;
using System;


namespace HutongGames.PlayMaker.Actions
{
#if UNITY_6000_0_OR_NEWER
	[Obsolete("The enableKerning property has been deprecated. " +
	          "Use the fontFeatures property to control what features are enabled on the text component.'")]	
#endif
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Determines if kerning is enabled or disabled.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetEnableKerning : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Enable Kerning")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getEnableKerning;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getEnableKerning);
		}
		
		public override void Execute()
		{
#if !UNITY_6000_0_OR_NEWER
			_getEnableKerning.Value = _tMP_Text.Value.enableKerning;
#endif
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} enable kerning -> {_getEnableKerning}";
		}
	}
}
