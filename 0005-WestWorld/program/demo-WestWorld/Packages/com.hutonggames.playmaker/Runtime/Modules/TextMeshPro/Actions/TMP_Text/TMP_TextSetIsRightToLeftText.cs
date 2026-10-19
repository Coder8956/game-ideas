
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Is Right To Left Text")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetIsRightToLeftText : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Is Right To Left Text")]
		[SerializeField]
		private BoolVar _setIsRightToLeftText;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setIsRightToLeftText);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.isRightToLeftText = _setIsRightToLeftText.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} is right to left text to {_setIsRightToLeftText}";
		}
	}
}
