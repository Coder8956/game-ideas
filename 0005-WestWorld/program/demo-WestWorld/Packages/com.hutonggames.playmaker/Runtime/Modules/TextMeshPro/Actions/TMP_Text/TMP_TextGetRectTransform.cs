
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Returns are reference to the RectTransform")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetRectTransform : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Rect Transform")]
		[SerializeField]
		[WriteOnly]
		private RectTransformVar _getRectTransform;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getRectTransform);
		}
		
		public override void Execute()
		{
			_getRectTransform.Value = _tMP_Text.Value.rectTransform;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} rect transform -> {_getRectTransform}";
		}
	}
}
