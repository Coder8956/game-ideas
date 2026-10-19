
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Controls the horizontal offset of the UV of the texture mapping mode for each line of the text object.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetMappingUvLineOffset : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Mapping Uv Line Offset")]
		[SerializeField]
		private FloatVar _setMappingUvLineOffset;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setMappingUvLineOffset);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.mappingUvLineOffset = _setMappingUvLineOffset.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} mapping UV line offset to {_setMappingUvLineOffset}";
		}
	}
}
