
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Sets the color of the _OutlineColor property of the assigned material. Changing outline color will result in an instance of the material.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetOutlineColor : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Outline Color")]
		[SerializeField]
		[WriteOnly]
		private Color32Ref _getOutlineColor;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getOutlineColor);
		}
		
		public override void Execute()
		{
			_getOutlineColor.Value = _tMP_Text.Value.outlineColor;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} outline color -> {_getOutlineColor}";
		}
	}
}
