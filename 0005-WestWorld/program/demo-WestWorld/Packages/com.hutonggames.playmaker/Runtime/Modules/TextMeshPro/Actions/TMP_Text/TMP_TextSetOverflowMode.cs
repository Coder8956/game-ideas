
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Controls the Text Overflow Mode")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetOverflowMode : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Overflow Mode")]
		[SerializeField]
		private TextOverflowModesVar _setOverflowMode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setOverflowMode);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.overflowMode = _setOverflowMode.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} overflow mode to {_setOverflowMode}";
		}
	}
}
