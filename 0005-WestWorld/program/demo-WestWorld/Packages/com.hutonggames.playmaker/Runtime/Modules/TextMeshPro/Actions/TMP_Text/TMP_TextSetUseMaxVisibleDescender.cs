
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Use Max Visible Descender.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetUseMaxVisibleDescender : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Use Max Visible Descender")]
		[SerializeField]
		private BoolVar _setUseMaxVisibleDescender;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setUseMaxVisibleDescender);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.useMaxVisibleDescender = _setUseMaxVisibleDescender.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} use max visible descender to {_setUseMaxVisibleDescender}";
		}
	}
}
