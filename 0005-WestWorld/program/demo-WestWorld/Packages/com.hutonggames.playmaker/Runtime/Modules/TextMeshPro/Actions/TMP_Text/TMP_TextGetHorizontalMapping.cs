
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Controls how the face and outline textures will be applied to the text object.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetHorizontalMapping : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Horizontal Mapping")]
		[SerializeField]
		[WriteOnly]
		private TextureMappingOptionsRef _getHorizontalMapping;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getHorizontalMapping);
		}
		
		public override void Execute()
		{
			_getHorizontalMapping.Value = _tMP_Text.Value.horizontalMapping;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} horizontal mapping -> {_getHorizontalMapping}";
		}
	}
}
