
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Control the weight of the font if an alternative font asset is assigned for the given weight in the font asset editor.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetFontWeight : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Font Weight")]
		[SerializeField]
		[WriteOnly]
		private FontWeightRef _getFontWeight;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getFontWeight);
		}
		
		public override void Execute()
		{
			_getFontWeight.Value = _tMP_Text.Value.fontWeight;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} font weight -> {_getFontWeight}";
		}
	}
}
