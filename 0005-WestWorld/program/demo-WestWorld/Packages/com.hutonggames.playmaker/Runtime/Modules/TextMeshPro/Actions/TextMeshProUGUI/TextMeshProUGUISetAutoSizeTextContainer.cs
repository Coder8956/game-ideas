
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TextMeshProUGUI)]
	[ActionDescription("Determines if the size of the text container will be adjusted to fit the text object when it is first created.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TextMeshProUGUI.html")]
	public sealed class TextMeshProUGUISetAutoSizeTextContainer : BaseAction
	{
		
		[Tooltip("The TextMeshProUGUI")]
		[SerializeField]
		private TextMeshProUGUIVar _textMeshProUGUI;
		
		[Tooltip("Set TextMeshProUGUI Auto Size Text Container")]
		[SerializeField]
		private BoolVar _setAutoSizeTextContainer;
		
		public override bool CanExecute()
		{
			return CheckParameters(_textMeshProUGUI, _setAutoSizeTextContainer);
		}
		
		public override void Execute()
		{
			_textMeshProUGUI.Value.autoSizeTextContainer = _setAutoSizeTextContainer.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_textMeshProUGUI} auto size text container to {_setAutoSizeTextContainer}";
		}
	}
}
