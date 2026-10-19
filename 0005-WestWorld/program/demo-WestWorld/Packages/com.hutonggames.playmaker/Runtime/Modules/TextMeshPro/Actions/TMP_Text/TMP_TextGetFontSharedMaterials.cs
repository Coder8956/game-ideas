
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("An array containing the materials used by the text object.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetFontSharedMaterials : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Font Shared Materials")]
		[SerializeField]
		[WriteOnly]
		private MaterialListRef _getFontSharedMaterials;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getFontSharedMaterials);
		}
		
		public override void Execute()
		{
			_getFontSharedMaterials.Values = _tMP_Text.Value.fontSharedMaterials;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} font shared materials -> {_getFontSharedMaterials}";
		}
	}
}
