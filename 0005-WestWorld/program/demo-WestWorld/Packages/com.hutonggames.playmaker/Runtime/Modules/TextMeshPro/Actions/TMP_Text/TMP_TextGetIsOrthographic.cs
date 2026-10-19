
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Get Is Orothographic.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetIsOrthographic : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Is Orthographic")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getIsOrthographic;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getIsOrthographic);
		}
		
		public override void Execute()
		{
			_getIsOrthographic.Value = _tMP_Text.Value.isOrthographic;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} is orthographic -> {_getIsOrthographic}";
		}
	}
}
