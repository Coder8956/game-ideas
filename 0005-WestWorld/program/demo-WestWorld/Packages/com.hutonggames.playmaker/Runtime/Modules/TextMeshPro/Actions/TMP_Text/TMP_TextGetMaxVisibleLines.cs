
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Allows control over how many lines of text are displayed.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetMaxVisibleLines : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Max Visible Lines")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getMaxVisibleLines;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getMaxVisibleLines);
		}
		
		public override void Execute()
		{
			_getMaxVisibleLines.Value = _tMP_Text.Value.maxVisibleLines;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} max visible lines -> {_getMaxVisibleLines}";
		}
	}
}
