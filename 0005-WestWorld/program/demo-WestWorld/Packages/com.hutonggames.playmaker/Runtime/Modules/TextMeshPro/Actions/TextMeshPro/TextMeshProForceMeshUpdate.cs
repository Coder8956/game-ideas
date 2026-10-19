
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TextMeshPro)]
	[ActionDescription("Function to force regeneration of the text object before its normal process time." +
		" This is useful when changes to the text object properties need to be applied im" +
		"mediately.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TextMeshPro.html")]
	public sealed class TextMeshProForceMeshUpdate : BaseAction
	{
		
		[Tooltip("The TextMeshPro.")]
		[SerializeField]
		private TextMeshProVar _textMeshPro;
		
		[Tooltip("Ignore Active State.")]
		[SerializeField]
		private BoolVar _ignoreActiveState;
		
		[Tooltip("Force Text Reparsing.")]
		[SerializeField]
		private BoolVar _forceTextReparsing;
		
		public override bool CanExecute()
		{
			return CheckParameters(_textMeshPro, _ignoreActiveState, _forceTextReparsing);
		}
		
		public override void Execute()
		{
			//TMPro.TextMeshPro.ForceMeshUpdate(System.Boolean, System.Boolean);
			_textMeshPro.Value.ForceMeshUpdate(_ignoreActiveState.Value, _forceTextReparsing.Value);
		}
		
		public override string GetSummary()
		{
			return "Force {_textMeshPro} mesh update {_ignoreActiveState} {_forceTextReparsing}";
		}
	}
}
