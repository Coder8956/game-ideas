
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TextMeshProUGUI)]
	[ActionDescription("Override of the Cull function to provide for the ability to override the culling of the text object.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TextMeshProUGUI.html")]
	public sealed class TextMeshProUGUICull : BaseAction
	{
		
		[Tooltip("The TextMeshProUGUI.")]
		[SerializeField]
		private TextMeshProUGUIVar _textMeshProUGUI;
		
		[Tooltip("Clip Rect.")]
		[SerializeField]
		private RectVar _clipRect;
		
		[Tooltip("Valid Rect.")]
		[SerializeField]
		private BoolVar _validRect;
		
		public override bool CanExecute()
		{
			return CheckParameters(_textMeshProUGUI, _clipRect, _validRect);
		}
		
		public override void Execute()
		{
			//TMPro.TextMeshProUGUI.Cull(UnityEngine.Rect, System.Boolean);
			_textMeshProUGUI.Value.Cull(_clipRect.Value, _validRect.Value);
		}
		
		public override string GetSummary()
		{
			return "Cull {_textMeshProUGUI} {_clipRect} {_validRect}";
		}
	}
}
