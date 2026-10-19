/*
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.TextMeshPro)]
	[ActionDescription("")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TextMeshPro.html")]
	public sealed class TextMeshProCalculateLayoutInputVertical : BaseAction
	{
		
		[Tooltip("The TextMeshPro.")]
		[SerializeField]
		private TextMeshProVar _textMeshPro;
		
		public override bool CanExecute()
		{
			return CheckParameters(_textMeshPro);
		}
		
		public override void Execute()
		{
			//TMPro.TextMeshPro.CalculateLayoutInputVertical();
			_textMeshPro.Value.CalculateLayoutInputVertical();
		}
		
		public override string GetSummary()
		{
			return "Calculate {_textMeshPro} layout input vertical";
		}
	}
}
*/