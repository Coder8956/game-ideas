/*
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.TextMeshProUGUI)]
	[ActionDescription("After this method is invoked, layout horizontal input properties should return up-to-date values. Children will already have up-to-date layout horizontal inputs when this methods is called.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TextMeshProUGUI.html")]
	public sealed class TextMeshProUGUICalculateLayoutInputHorizontal : BaseAction
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
			//TMPro.TextMeshProUGUI.CalculateLayoutInputHorizontal();
			_textMeshProUGUI.Value.CalculateLayoutInputHorizontal();
		}
		
		public override string GetSummary()
		{
			return "Calculate {_textMeshProUGUI} layout input horizontal";
		}
	}
}
*/