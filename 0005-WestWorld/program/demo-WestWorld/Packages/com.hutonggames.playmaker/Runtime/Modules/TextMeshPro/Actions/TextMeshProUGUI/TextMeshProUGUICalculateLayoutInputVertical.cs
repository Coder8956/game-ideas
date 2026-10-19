/*
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.TextMeshProUGUI)]
	[ActionDescription("After this method is invoked, layout vertical input properties should return up-to-date values. Children will already have up-to-date layout vertical inputs when this methods is called.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TextMeshProUGUI.html")]
	public sealed class TextMeshProUGUICalculateLayoutInputVertical : BaseAction
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
			//TMPro.TextMeshProUGUI.CalculateLayoutInputVertical();
			_textMeshProUGUI.Value.CalculateLayoutInputVertical();
		}
		
		public override string GetSummary()
		{
			return "Calculate {_textMeshProUGUI} layout input vertical";
		}
	}
}
*/