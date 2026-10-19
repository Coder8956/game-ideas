
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Function to be used to force recomputing of character padding when Shader / Material properties have been changed via script.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextUpdateMeshPadding : BaseAction
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
			//TMPro.TMP_Text.UpdateMeshPadding();
			_tMP_Text.Value.UpdateMeshPadding();
		}
		
		public override string GetSummary()
		{
			return "Update {_tMP_Text} mesh padding";
		}
	}
}
