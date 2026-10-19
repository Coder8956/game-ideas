
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Character spacing.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetCharacterSpacing : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Character Spacing")]
		[SerializeField]
		private FloatVar _setCharacterSpacing;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setCharacterSpacing);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.characterSpacing = _setCharacterSpacing.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} character spacing to {_setCharacterSpacing}";
		}
	}
}
