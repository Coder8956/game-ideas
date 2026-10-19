
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TextMeshProUGUI)]
	[ActionDescription("Function to clear the geometry of the Primary and Sub Text objects.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TextMeshProUGUI.html")]
	public sealed class TextMeshProUGUIClearMesh : BaseAction
	{
		
		[Tooltip("The TextMeshProUGUI.")]
		[SerializeField]
		private TextMeshProUGUIVar _textMeshProUGUI;
		
		public override bool CanExecute()
		{
			return CheckParameters(_textMeshProUGUI);
		}
		
		public override void Execute()
		{
			//TMPro.TextMeshProUGUI.ClearMesh();
			_textMeshProUGUI.Value.ClearMesh();
		}
		
		public override string GetSummary()
		{
			return "Clear {_textMeshProUGUI} mesh";
		}
	}
}
