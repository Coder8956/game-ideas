
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Vertical mapping options.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetVerticalMapping : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Vertical Mapping")]
		[SerializeField]
		[WriteOnly]
		private TextureMappingOptionsRef _getVerticalMapping;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getVerticalMapping);
		}
		
		public override void Execute()
		{
			_getVerticalMapping.Value = _tMP_Text.Value.verticalMapping;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} vertical mapping -> {_getVerticalMapping}";
		}
	}
}
