/*
using JetBrains.Annotations;
using TMPro;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.TextMeshProUGUI)]
	[ActionDescription("Sends an event when Text Mesh Pro UGUI Pre Render Text.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TextMeshProUGUI.html")]
	public sealed class TextMeshProUGUIOnPreRenderText : BaseOnEventAction
	{
		
		[Tooltip("The TextMeshProUGUI")]
		[SerializeField]
		private TextMeshProUGUIVar _textMeshProUGUI;
		
		[Tooltip("TODO: Add tooltip!")]
		[SerializeField]
		private EventRef _onPreRenderText;
		
		public override bool CanExecute()
		{
			return CheckParameters(_textMeshProUGUI);
		}
		
		public override void OnStart()
		{
			_textMeshProUGUI.Value.OnPreRenderText += OnOnPreRenderText;
		}
		
		public override void OnStop()
		{
			_textMeshProUGUI.Value.OnPreRenderText -= OnOnPreRenderText;
		}
		
		private void OnOnPreRenderText(TMP_TextInfo obj)
		{
			SendEvent(_onPreRenderText);
		}
	}
}
*/