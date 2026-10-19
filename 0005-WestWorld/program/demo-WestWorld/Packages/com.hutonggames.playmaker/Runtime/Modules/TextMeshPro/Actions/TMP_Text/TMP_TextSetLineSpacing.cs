
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("The amount of additional spacing to add between each lines of text.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetLineSpacing : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Line Spacing")]
		[SerializeField]
		private FloatVar _setLineSpacing;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setLineSpacing);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.lineSpacing = _setLineSpacing.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} line spacing to {_setLineSpacing}";
		}
	}
}
