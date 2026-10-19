
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Function to force an update of the margin size.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextComputeMarginSize : BaseAction
	{
		
		[Tooltip("The TMP_Text.")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text);
		}
		
		public override void Execute()
		{
			//TMPro.TMP_Text.ComputeMarginSize();
			_tMP_Text.Value.ComputeMarginSize();
		}
		
		public override string GetSummary()
		{
			return "Compute {_tMP_Text} margin size";
		}
	}
}
