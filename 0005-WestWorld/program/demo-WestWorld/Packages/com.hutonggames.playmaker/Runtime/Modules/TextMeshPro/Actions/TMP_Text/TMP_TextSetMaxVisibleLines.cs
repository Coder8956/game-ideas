
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Allows control over how many lines of text are displayed.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetMaxVisibleLines : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Max Visible Lines")]
		[SerializeField]
		private IntegerVar _setMaxVisibleLines;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setMaxVisibleLines);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.maxVisibleLines = _setMaxVisibleLines.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} max visible lines to {_setMaxVisibleLines}";
		}
	}
}
