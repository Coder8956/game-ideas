
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
	public sealed class TMP_TextSetEnableKerning : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Enable Kerning")]
		[SerializeField]
		private BoolVar _setEnableKerning;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setEnableKerning);
		}
		
		public override void Execute()
		{
#if !UNITY_6000_0_OR_NEWER
			_tMP_Text.Value.enableKerning = _setEnableKerning.Value;
#endif
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} enable kerning to {_setEnableKerning}";
		}
	}
}
