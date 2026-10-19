
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Determines if the Mesh will be rendered.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetRenderMode : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Render Mode")]
		[SerializeField]
		private TextRenderFlagsVar _setRenderMode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setRenderMode);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.renderMode = _setRenderMode.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} render mode to {_setRenderMode}";
		}
	}
}
