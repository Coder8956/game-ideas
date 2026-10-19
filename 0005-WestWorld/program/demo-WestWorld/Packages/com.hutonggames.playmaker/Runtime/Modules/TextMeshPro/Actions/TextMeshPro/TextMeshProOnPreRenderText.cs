
using JetBrains.Annotations;
using TMPro;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TextMeshPro)]
	[ActionDescription("Event to allow users to modify the content of the text info before the text is rendered.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TextMeshPro.html")]
	public sealed class TextMeshProOnPreRenderText : BaseOnEventAction
	{
		
		[Tooltip("The TextMeshPro")]
		[SerializeField]
		private TextMeshProVar _textMeshPro;
		
		[Tooltip("Event to allow users to modify the content of the text info before the text is rendered.")]
		[SerializeField]
		private EventRef _onPreRenderText;
		
		public override bool CanExecute()
		{
			return CheckParameters(_textMeshPro);
		}
		
		public override void OnStart()
		{
			_textMeshPro.Value.OnPreRenderText += OnOnPreRenderText;
		}
		
		public override void OnStop()
		{
			_textMeshPro.Value.OnPreRenderText -= OnOnPreRenderText;
		}
		
		private void OnOnPreRenderText(TMP_TextInfo obj)
		{
			SendEvent(_onPreRenderText);
		}

		public override string GetSummary() => "On {_textMeshPro} pre render text {_onPreRenderText}";
	}
}
