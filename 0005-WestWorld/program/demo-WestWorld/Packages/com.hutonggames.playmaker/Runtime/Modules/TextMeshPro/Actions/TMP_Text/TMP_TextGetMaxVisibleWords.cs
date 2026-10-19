
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Allows to control how many words are visible from the input.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetMaxVisibleWords : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Max Visible Words")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getMaxVisibleWords;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getMaxVisibleWords);
		}
		
		public override void Execute()
		{
			_getMaxVisibleWords.Value = _tMP_Text.Value.maxVisibleWords;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} max visible words -> {_getMaxVisibleWords}";
		}
	}
}
