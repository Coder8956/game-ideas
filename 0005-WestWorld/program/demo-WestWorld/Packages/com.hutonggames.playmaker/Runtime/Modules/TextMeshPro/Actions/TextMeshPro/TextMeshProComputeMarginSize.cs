
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TextMeshPro)]
	[ActionDescription("Update the margin width and height")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TextMeshPro.html")]
	public sealed class TextMeshProComputeMarginSize : BaseAction
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
			//TMPro.TextMeshPro.ComputeMarginSize();
			_textMeshPro.Value.ComputeMarginSize();
		}
		
		public override string GetSummary()
		{
			return "Compute {_textMeshPro} margin size";
		}
	}
}
