
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("The Font Asset to be assigned to this text object.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetFont : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Font")]
		[SerializeField, CanBeNullOrEmpty]
		private TMP_FontAssetVar _setFont;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.font = _setFont.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} font to {_setFont}";
		}
	}
}
