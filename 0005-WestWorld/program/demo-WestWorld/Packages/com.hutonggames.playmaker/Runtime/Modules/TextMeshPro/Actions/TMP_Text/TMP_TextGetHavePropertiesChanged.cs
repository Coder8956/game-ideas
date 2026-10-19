
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Property tracking if any of the text properties have changed. Flag is set before the text is regenerated.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetHavePropertiesChanged : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Have Properties Changed")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getHavePropertiesChanged;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getHavePropertiesChanged);
		}
		
		public override void Execute()
		{
			_getHavePropertiesChanged.Value = _tMP_Text.Value.havePropertiesChanged;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} have properties changed -> {_getHavePropertiesChanged}";
		}
	}
}
