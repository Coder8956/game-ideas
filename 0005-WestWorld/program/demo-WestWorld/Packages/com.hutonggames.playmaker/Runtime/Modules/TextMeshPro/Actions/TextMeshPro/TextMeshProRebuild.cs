
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TextMeshPro)]
	[ActionDescription("Rebuilds the graphic geometry and its material on the PreRender cycle.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TextMeshPro.html")]
	public sealed class TextMeshProRebuild : BaseAction
	{
		
		[Tooltip("The TextMeshPro.")]
		[SerializeField]
		private TextMeshProVar _textMeshPro;
		
		[Tooltip("Update.")]
		[SerializeField]
		private UI.CanvasUpdateVar _update;
		
		public override bool CanExecute()
		{
			return CheckParameters(_textMeshPro, _update);
		}
		
		public override void Execute()
		{
			//TMPro.TextMeshPro.Rebuild(UnityEngine.UI.CanvasUpdate);
			_textMeshPro.Value.Rebuild(_update.Value);
		}
		
		public override string GetSummary()
		{
			return "Rebuild {_textMeshPro} {_update}";
		}
	}
}
