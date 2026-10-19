
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Sets the thickness of the outline of the font. Setting this value will result in an instance of the material.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetOutlineWidth : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Outline Width")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getOutlineWidth;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getOutlineWidth);
		}
		
		public override void Execute()
		{
			_getOutlineWidth.Value = _tMP_Text.Value.outlineWidth;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} outline width -> {_getOutlineWidth}";
		}
	}
}
