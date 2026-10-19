
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Text alignment options")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetAlignment : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Alignment")]
		[SerializeField]
		private TextAlignmentOptionsVar _setAlignment;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setAlignment);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.alignment = _setAlignment.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} alignment to {_setAlignment}";
		}
	}
}
