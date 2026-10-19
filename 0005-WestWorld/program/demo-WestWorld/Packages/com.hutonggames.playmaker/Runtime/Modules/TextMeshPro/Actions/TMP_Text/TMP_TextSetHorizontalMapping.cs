
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Controls how the face and outline textures will be applied to the text object.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetHorizontalMapping : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Horizontal Mapping")]
		[SerializeField]
		private TextureMappingOptionsVar _setHorizontalMapping;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setHorizontalMapping);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.horizontalMapping = _setHorizontalMapping.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} horizontal mapping to {_setHorizontalMapping}";
		}
	}
}
