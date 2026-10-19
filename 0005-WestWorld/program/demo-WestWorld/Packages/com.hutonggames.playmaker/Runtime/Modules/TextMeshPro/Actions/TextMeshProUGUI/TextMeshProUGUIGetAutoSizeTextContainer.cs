
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TextMeshProUGUI)]
	[ActionDescription("Determines if the size of the text container will be adjusted to fit the text object when it is first created.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TextMeshProUGUI.html")]
	public sealed class TextMeshProUGUIGetAutoSizeTextContainer : BaseAction
	{
		
		[Tooltip("The TextMeshProUGUI")]
		[SerializeField]
		private TextMeshProUGUIVar _textMeshProUGUI;
		
		[Tooltip("Get TextMeshProUGUI Auto Size Text Container")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getAutoSizeTextContainer;
		
		public override bool CanExecute()
		{
			return CheckParameters(_textMeshProUGUI, _getAutoSizeTextContainer);
		}
		
		public override void Execute()
		{
			_getAutoSizeTextContainer.Value = _textMeshProUGUI.Value.autoSizeTextContainer;
		}
		
		public override string GetSummary()
		{
			return "Get {_textMeshProUGUI} auto size text container -> {_getAutoSizeTextContainer}";
		}
	}
}
