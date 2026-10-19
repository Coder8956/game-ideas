
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("The first character which exceeds the vertical bounds of its text container.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetFirstOverflowCharacterIndex : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text First Overflow Character Index")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getFirstOverflowCharacterIndex;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getFirstOverflowCharacterIndex);
		}
		
		public override void Execute()
		{
			_getFirstOverflowCharacterIndex.Value = _tMP_Text.Value.firstOverflowCharacterIndex;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} first overflow character index -> {_getFirstOverflowCharacterIndex}";
		}
	}
}
