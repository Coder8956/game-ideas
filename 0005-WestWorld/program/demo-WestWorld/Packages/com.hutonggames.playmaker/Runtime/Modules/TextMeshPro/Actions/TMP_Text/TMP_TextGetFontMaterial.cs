
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("The material to be assigned to this text object. An instance of the material will be assigned to the object's renderer.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetFontMaterial : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Font Material")]
		[SerializeField]
		[WriteOnly]
		private MaterialRef _getFontMaterial;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getFontMaterial);
		}
		
		public override void Execute()
		{
			_getFontMaterial.Value = _tMP_Text.Value.fontMaterial;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} font material -> {_getFontMaterial}";
		}
	}
}
