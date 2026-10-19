
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Sets the color of the _FaceColor property of the assigned material. Changing face color will result in an instance of the material.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetFaceColor : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Face Color")]
		[SerializeField]
		[WriteOnly]
		private Color32Ref _getFaceColor;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getFaceColor);
		}
		
		public override void Execute()
		{
			_getFaceColor.Value = _tMP_Text.Value.faceColor;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} face color -> {_getFaceColor}";
		}
	}
}
