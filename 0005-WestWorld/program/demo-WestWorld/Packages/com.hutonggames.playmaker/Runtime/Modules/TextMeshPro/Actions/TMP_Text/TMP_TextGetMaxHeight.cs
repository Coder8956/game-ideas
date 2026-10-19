
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Allows to control how many characters are visible from the input.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetMaxHeight : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Max Height")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getMaxHeight;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getMaxHeight);
		}
		
		public override void Execute()
		{
			_getMaxHeight.Value = _tMP_Text.Value.maxHeight;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} max height -> {_getMaxHeight}";
		}
	}
}
