
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TextMeshProUGUI)]
	[ActionDescription("Rebuilds the graphic geometry and its material on the PreRender cycle.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TextMeshProUGUI.html")]
	public sealed class TextMeshProUGUIRebuild : BaseAction
	{
		
		[Tooltip("The TextMeshProUGUI.")]
		[SerializeField]
		private TextMeshProUGUIVar _textMeshProUGUI;
		
		[Tooltip("Update.")]
		[SerializeField]
		private UI.CanvasUpdateVar _update;
		
		public override bool CanExecute()
		{
			return CheckParameters(_textMeshProUGUI, _update);
		}
		
		public override void Execute()
		{
			//TMPro.TextMeshProUGUI.Rebuild(UnityEngine.UI.CanvasUpdate);
			_textMeshProUGUI.Value.Rebuild(_update.Value);
		}
		
		public override string GetSummary()
		{
			return "Rebuild {_textMeshProUGUI} {_update}";
		}
	}
}
