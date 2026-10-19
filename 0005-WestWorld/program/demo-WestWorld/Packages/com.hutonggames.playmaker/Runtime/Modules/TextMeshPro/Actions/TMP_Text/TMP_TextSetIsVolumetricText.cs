
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Determines if the geometry of the characters will be quads or volumetric (cubes).")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetIsVolumetricText : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Is Volumetric Text")]
		[SerializeField]
		private BoolVar _setIsVolumetricText;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setIsVolumetricText);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.isVolumetricText = _setIsVolumetricText.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} is volumetric text to {_setIsVolumetricText}";
		}
	}
}
