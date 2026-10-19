
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Sets the color of the _OutlineColor property of the assigned material. Changing outline color will result in an instance of the material.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetOutlineColor : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Outline Color")]
		[SerializeField]
		private Color32Var _setOutlineColor;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setOutlineColor);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.outlineColor = _setOutlineColor.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} outline color to {_setOutlineColor}";
		}
	}
}
