
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Determines if the geometry of the characters will be quads or volumetric (cubes).")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetIsVolumetricText : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Is Volumetric Text")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getIsVolumetricText;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getIsVolumetricText);
		}
		
		public override void Execute()
		{
			_getIsVolumetricText.Value = _tMP_Text.Value.isVolumetricText;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} is volumetric text -> {_getIsVolumetricText}";
		}
	}
}
