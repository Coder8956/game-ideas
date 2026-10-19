
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Enables control over setting the size of the text container to match the text object.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetAutoSizeTextContainer : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Auto Size Text Container")]
		[SerializeField]
		private BoolVar _setAutoSizeTextContainer;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setAutoSizeTextContainer);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.autoSizeTextContainer = _setAutoSizeTextContainer.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} auto size text container to {_setAutoSizeTextContainer}";
		}
	}
}
