
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TextMeshProUGUI)]
	[ActionDescription("Function to upload the updated vertex data and renderer.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TextMeshProUGUI.html")]
	public sealed class TextMeshProUGUIUpdateVertexData : BaseAction
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
			//TMPro.TextMeshProUGUI.UpdateVertexData();
			_textMeshProUGUI.Value.UpdateVertexData();
		}
		
		public override string GetSummary()
		{
			return "Update {_textMeshProUGUI} vertex data";
		}
	}
}
