
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Min Width.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetMinWidth : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Min Width")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getMinWidth;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getMinWidth);
		}
		
		public override void Execute()
		{
			_getMinWidth.Value = _tMP_Text.Value.minWidth;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} min width -> {_getMinWidth}";
		}
	}
}
