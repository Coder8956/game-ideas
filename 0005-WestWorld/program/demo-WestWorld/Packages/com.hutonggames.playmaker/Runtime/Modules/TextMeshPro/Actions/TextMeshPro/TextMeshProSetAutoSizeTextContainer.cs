
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
	public sealed class TextMeshProSetAutoSizeTextContainer : BaseAction
	{
		
		[Tooltip("The TextMeshPro")]
		[SerializeField]
		private TextMeshProVar _textMeshPro;
		
		[Tooltip("Set TextMeshPro Auto Size Text Container")]
		[SerializeField]
		private BoolVar _setAutoSizeTextContainer;
		
		public override bool CanExecute()
		{
			return CheckParameters(_textMeshPro, _setAutoSizeTextContainer);
		}
		
		public override void Execute()
		{
			_textMeshPro.Value.autoSizeTextContainer = _setAutoSizeTextContainer.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_textMeshPro} auto size text container to {_setAutoSizeTextContainer}";
		}
	}
}
