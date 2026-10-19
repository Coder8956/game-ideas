
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Sets the thickness of the outline of the font. Setting this value will result in an instance of the material.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetOutlineWidth : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Outline Width")]
		[SerializeField]
		private FloatVar _setOutlineWidth;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setOutlineWidth);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.outlineWidth = _setOutlineWidth.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} outline width to {_setOutlineWidth}";
		}
	}
}
