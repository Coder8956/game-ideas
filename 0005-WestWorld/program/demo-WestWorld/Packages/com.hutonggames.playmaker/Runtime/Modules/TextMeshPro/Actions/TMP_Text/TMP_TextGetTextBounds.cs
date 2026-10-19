
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Returns the bounds of the text of the text object.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetTextBounds : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Text Bounds")]
		[SerializeField]
		[WriteOnly]
		private BoundsRef _getTextBounds;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getTextBounds);
		}
		
		public override void Execute()
		{
			_getTextBounds.Value = _tMP_Text.Value.textBounds;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} text bounds -> {_getTextBounds}";
		}
	}
}
