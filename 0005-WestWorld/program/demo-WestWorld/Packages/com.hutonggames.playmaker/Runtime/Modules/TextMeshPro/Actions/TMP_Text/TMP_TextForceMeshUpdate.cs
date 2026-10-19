
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Function to force regeneration of the text object before its normal process time. This is useful when changes to the text object properties need to be applied immediately.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextForceMeshUpdate : BaseAction
	{
		
		[Tooltip("The TMP_Text.")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Ignore Active State of text objects. Inactive objects are ignored by default.")]
		[SerializeField]
		private BoolVar _ignoreActiveState;
		
		[Tooltip("Force Text Reparsing.")]
		[SerializeField]
		private BoolVar _forceTextReparsing;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _ignoreActiveState, _forceTextReparsing);
		}
		
		public override void Execute()
		{
			//TMPro.TMP_Text.ForceMeshUpdate(System.Boolean, System.Boolean);
			_tMP_Text.Value.ForceMeshUpdate(_ignoreActiveState.Value, _forceTextReparsing.Value);
		}
		
		public override string GetSummary()
		{
			return "Force {_tMP_Text} mesh update {_ignoreActiveState} {_forceTextReparsing}";
		}
	}
}
