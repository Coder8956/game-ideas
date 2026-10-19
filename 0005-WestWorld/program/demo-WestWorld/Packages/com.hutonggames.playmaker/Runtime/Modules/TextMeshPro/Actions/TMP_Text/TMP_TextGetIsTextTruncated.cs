
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Property indicating whether the text is Truncated or using Ellipsis.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetIsTextTruncated : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Is Text Truncated")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getIsTextTruncated;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getIsTextTruncated);
		}
		
		public override void Execute()
		{
			_getIsTextTruncated.Value = _tMP_Text.Value.isTextTruncated;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} is text truncated -> {_getIsTextTruncated}";
		}
	}
}
