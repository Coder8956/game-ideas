
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Computed preferred width of the text object.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetPreferredWidth : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Preferred Width")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getPreferredWidth;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getPreferredWidth);
		}
		
		public override void Execute()
		{
			_getPreferredWidth.Value = _tMP_Text.Value.preferredWidth;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} preferred width -> {_getPreferredWidth}";
		}
	}
}
