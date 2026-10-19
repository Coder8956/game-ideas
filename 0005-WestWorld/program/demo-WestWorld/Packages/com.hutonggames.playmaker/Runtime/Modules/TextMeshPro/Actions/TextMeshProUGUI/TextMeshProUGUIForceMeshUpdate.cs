
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TextMeshProUGUI)]
	[ActionDescription("Function to force regeneration of the text object before its normal process time. " +
	                   "This is useful when changes to the text object properties need to be applied immediately.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TextMeshProUGUI.html")]
	public sealed class TextMeshProUGUIForceMeshUpdate : BaseAction
	{
		
		[Tooltip("The TextMeshProUGUI.")]
		[SerializeField]
		private TextMeshProUGUIVar _textMeshProUGUI;
		
		[Tooltip("Ignore Active State of text objects. Inactive objects are ignored by default.")]
		[SerializeField]
		private BoolVar _ignoreActiveState;
		
		[Tooltip("Force re-parsing of the text.")]
		[SerializeField]
		private BoolVar _forceTextReparsing;
		
		public override bool CanExecute()
		{
			return CheckParameters(_textMeshProUGUI, _ignoreActiveState, _forceTextReparsing);
		}
		
		public override void Execute()
		{
			//TMPro.TextMeshProUGUI.ForceMeshUpdate(System.Boolean, System.Boolean);
			_textMeshProUGUI.Value.ForceMeshUpdate(_ignoreActiveState.Value, _forceTextReparsing.Value);
		}
		
		public override string GetSummary()
		{
			return "Force {_textMeshProUGUI} mesh update {_ignoreActiveState} {_forceTextReparsing}";
		}
	}
}
