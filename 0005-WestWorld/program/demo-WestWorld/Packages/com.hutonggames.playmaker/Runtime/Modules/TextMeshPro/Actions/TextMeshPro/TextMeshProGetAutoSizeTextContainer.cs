
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TextMeshPro)]
	[ActionDescription("Determines if the size of the text container will be adjusted to fit the text obj" +
		"ect when it is first created.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TextMeshPro.html")]
	public sealed class TextMeshProGetAutoSizeTextContainer : BaseAction
	{
		
		[Tooltip("The TextMeshPro")]
		[SerializeField]
		private TextMeshProVar _textMeshPro;
		
		[Tooltip("Get TextMeshPro Auto Size Text Container")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getAutoSizeTextContainer;
		
		public override bool CanExecute()
		{
			return CheckParameters(_textMeshPro, _getAutoSizeTextContainer);
		}
		
		public override void Execute()
		{
			_getAutoSizeTextContainer.Value = _textMeshPro.Value.autoSizeTextContainer;
		}
		
		public override string GetSummary()
		{
			return "Get {_textMeshPro} auto size text container -> {_getAutoSizeTextContainer}";
		}
	}
}
