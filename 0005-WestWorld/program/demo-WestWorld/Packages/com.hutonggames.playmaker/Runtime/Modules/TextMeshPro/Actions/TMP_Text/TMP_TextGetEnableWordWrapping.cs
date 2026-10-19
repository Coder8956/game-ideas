
using JetBrains.Annotations;
using UnityEngine;
using System;
using TMPro;


namespace HutongGames.PlayMaker.Actions
{
#if UNITY_6000_0_OR_NEWER
	[Obsolete("The enabledWordWrapping property is now obsolete. Please use the textWrappingMode property instead.")]	
#endif	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Controls whether or not word wrapping is applied. When disabled, the text will be displayed on a single line.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetEnableWordWrapping : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Enable Word Wrapping")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getEnableWordWrapping;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getEnableWordWrapping);
		}
		
		public override void Execute()
		{
#if !UNITY_6000_0_OR_NEWER
			_getEnableWordWrapping.Value = _tMP_Text.Value.enableWordWrapping;
#else
			_getEnableWordWrapping.Value = _tMP_Text.Value.textWrappingMode == TextWrappingModes.Normal;
#endif
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} enable word wrapping -> {_getEnableWordWrapping}";
		}
	}
}
