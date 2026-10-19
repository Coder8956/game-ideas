
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Property tracking if any of the text properties have changed. Flag is set before the text is regenerated.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetHavePropertiesChanged : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Have Properties Changed")]
		[SerializeField]
		private BoolVar _setHavePropertiesChanged;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setHavePropertiesChanged);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.havePropertiesChanged = _setHavePropertiesChanged.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} have properties changed to {_setHavePropertiesChanged}";
		}
	}
}
