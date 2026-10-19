
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Property used in conjunction with padding calculation for the geometry.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetIsUsingBold : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Is Using Bold")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getIsUsingBold;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getIsUsingBold);
		}
		
		public override void Execute()
		{
			_getIsUsingBold.Value = _tMP_Text.Value.isUsingBold;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} is using bold -> {_getIsUsingBold}";
		}
	}
}
