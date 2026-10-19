
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Vertical alignment options.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetVerticalAlignment : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Vertical Alignment")]
		[SerializeField]
		private VerticalAlignmentOptionsVar _setVerticalAlignment;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setVerticalAlignment);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.verticalAlignment = _setVerticalAlignment.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} vertical alignment to {_setVerticalAlignment}";
		}
	}
}
