
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TextMeshProUGUI)]
	[ActionDescription("Function to be used to force recomputing of character padding when Shader / Mater" +
	                   "ial properties have been changed via script.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TextMeshProUGUI.html")]
	public sealed class TextMeshProUGUIUpdateMeshPadding : BaseAction
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
			//TMPro.TextMeshProUGUI.UpdateMeshPadding();
			_textMeshProUGUI.Value.UpdateMeshPadding();
		}
		
		public override string GetSummary()
		{
			return "Update {_textMeshProUGUI} mesh padding";
		}
	}
}
