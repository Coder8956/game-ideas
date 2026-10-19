
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using System;


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
	public sealed class TMP_TextSetEnableWordWrapping : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Enable Word Wrapping")]
		[SerializeField]
		private BoolVar _setEnableWordWrapping;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setEnableWordWrapping);
		}
		
		public override void Execute()
		{
#if UNITY_6000_0_OR_NEWER
			_tMP_Text.Value.textWrappingMode = _setEnableWordWrapping.Value ? TextWrappingModes.Normal : TextWrappingModes.NoWrap;
#else
			_tMP_Text.Value.enableWordWrapping = _setEnableWordWrapping.Value;
#endif
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} enable word wrapping to {_setEnableWordWrapping}";
		}
	}
}
