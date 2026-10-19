
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Forces objects that are not visible to get refreshed.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetIgnoreVisibility : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Ignore Visibility")]
		[SerializeField]
		private BoolVar _setIgnoreVisibility;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setIgnoreVisibility);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.ignoreVisibility = _setIgnoreVisibility.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} ignore visibility to {_setIgnoreVisibility}";
		}
	}
}
