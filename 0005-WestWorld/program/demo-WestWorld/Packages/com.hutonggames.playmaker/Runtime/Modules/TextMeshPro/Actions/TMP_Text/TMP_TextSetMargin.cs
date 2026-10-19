
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("The margins of the text object.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetMargin : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Margin")]
		[SerializeField]
		private Vector4Var _setMargin;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setMargin);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.margin = _setMargin.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} margin to {_setMargin}";
		}
	}
}
