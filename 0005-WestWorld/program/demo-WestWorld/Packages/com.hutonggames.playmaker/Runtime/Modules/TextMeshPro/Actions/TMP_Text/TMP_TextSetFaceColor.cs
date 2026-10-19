
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Sets the color of the _FaceColor property of the assigned material. Changing face color will result in an instance of the material.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetFaceColor : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Face Color")]
		[SerializeField]
		private Color32Var _setFaceColor;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setFaceColor);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.faceColor = _setFaceColor.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} face color to {_setFaceColor}";
		}
	}
}
