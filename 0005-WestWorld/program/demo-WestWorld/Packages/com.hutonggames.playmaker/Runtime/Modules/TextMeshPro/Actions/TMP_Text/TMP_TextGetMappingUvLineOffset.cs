
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Controls the horizontal offset of the UV of the texture mapping mode for each line of the text object.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetMappingUvLineOffset : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Mapping Uv Line Offset")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getMappingUvLineOffset;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getMappingUvLineOffset);
		}
		
		public override void Execute()
		{
			_getMappingUvLineOffset.Value = _tMP_Text.Value.mappingUvLineOffset;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} mapping UV line offset -> {_getMappingUvLineOffset}";
		}
	}
}
