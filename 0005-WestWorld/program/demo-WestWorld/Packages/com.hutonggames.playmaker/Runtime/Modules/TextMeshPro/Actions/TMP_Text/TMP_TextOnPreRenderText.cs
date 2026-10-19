/*
using JetBrains.Annotations;
using TMPro;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Sends an event when TMP Text Pre Render Text.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextOnPreRenderText : BaseOnEventAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("TODO: Add tooltip!")]
		[SerializeField]
		private EventRef _onPreRenderText;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text);
		}
		
		public override void OnStart()
		{
			_tMP_Text.Value.OnPreRenderText += OnOnPreRenderText;
		}
		
		public override void OnStop()
		{
			_tMP_Text.Value.OnPreRenderText -= OnOnPreRenderText;
		}
		
		private void OnOnPreRenderText(TMP_TextInfo obj)
		{
			SendEvent(_onPreRenderText);
		}
	}
}
*/