
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("The vertex color alpha value.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetAlpha : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Alpha")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getAlpha;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getAlpha);
		}
		
		public override void Execute()
		{
			_getAlpha.Value = _tMP_Text.Value.alpha;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} alpha -> {_getAlpha}";
		}
	}
}
