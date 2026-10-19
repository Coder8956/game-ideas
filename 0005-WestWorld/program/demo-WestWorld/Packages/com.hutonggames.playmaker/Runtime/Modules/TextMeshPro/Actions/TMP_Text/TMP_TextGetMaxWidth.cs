
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Max Width")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetMaxWidth : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Max Width")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getMaxWidth;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getMaxWidth);
		}
		
		public override void Execute()
		{
			_getMaxWidth.Value = _tMP_Text.Value.maxWidth;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} max width -> {_getMaxWidth}";
		}
	}
}
