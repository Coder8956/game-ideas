
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Controls the Text Overflow Mode")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetOverflowMode : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Overflow Mode")]
		[SerializeField]
		[WriteOnly]
		private TextOverflowModesRef _getOverflowMode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getOverflowMode);
		}
		
		public override void Execute()
		{
			_getOverflowMode.Value = _tMP_Text.Value.overflowMode;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} overflow mode -> {_getOverflowMode}";
		}
	}
}
