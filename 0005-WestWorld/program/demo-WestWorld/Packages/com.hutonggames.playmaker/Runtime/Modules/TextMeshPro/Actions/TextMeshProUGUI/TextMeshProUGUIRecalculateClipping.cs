
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TextMeshProUGUI)]
	[ActionDescription("Method called when the state of a parent changes.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TextMeshProUGUI.html")]
	public sealed class TextMeshProUGUIRecalculateClipping : BaseAction
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
			//TMPro.TextMeshProUGUI.RecalculateClipping();
			_textMeshProUGUI.Value.RecalculateClipping();
		}
		
		public override string GetSummary()
		{
			return "Recalculate {_textMeshProUGUI} clipping";
		}
	}
}
