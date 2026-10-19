
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Control the weight of the font if an alternative font asset is assigned for the given weight in the font asset editor.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetFontWeight : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Font Weight")]
		[SerializeField]
		private FontWeightVar _setFontWeight;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setFontWeight);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.fontWeight = _setFontWeight.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} font weight to {_setFontWeight}";
		}
	}
}
