
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Computed preferred height of the text object.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetPreferredHeight : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Preferred Height")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getPreferredHeight;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getPreferredHeight);
		}
		
		public override void Execute()
		{
			_getPreferredHeight.Value = _tMP_Text.Value.preferredHeight;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} preferred height -> {_getPreferredHeight}";
		}
	}
}
