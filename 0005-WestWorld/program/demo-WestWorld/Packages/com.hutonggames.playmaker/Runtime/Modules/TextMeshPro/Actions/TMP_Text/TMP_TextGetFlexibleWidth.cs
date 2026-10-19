
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Get Flexible Width.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetFlexibleWidth : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Flexible Width")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getFlexibleWidth;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getFlexibleWidth);
		}
		
		public override void Execute()
		{
			_getFlexibleWidth.Value = _tMP_Text.Value.flexibleWidth;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} flexible width -> {_getFlexibleWidth}";
		}
	}
}
