
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("The first character which should be made visible in conjunction with the Text Overflow Linked mode.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetFirstVisibleCharacter : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text First Visible Character")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getFirstVisibleCharacter;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getFirstVisibleCharacter);
		}
		
		public override void Execute()
		{
			_getFirstVisibleCharacter.Value = _tMP_Text.Value.firstVisibleCharacter;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} first visible character -> {_getFirstVisibleCharacter}";
		}
	}
}
