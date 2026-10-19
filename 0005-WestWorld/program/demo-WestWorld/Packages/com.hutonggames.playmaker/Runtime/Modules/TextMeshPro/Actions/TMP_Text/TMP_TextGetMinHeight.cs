
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Min Height.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetMinHeight : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Min Height")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getMinHeight;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getMinHeight);
		}
		
		public override void Execute()
		{
			_getMinHeight.Value = _tMP_Text.Value.minHeight;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} min height -> {_getMinHeight}";
		}
	}
}
