
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Property to handle legacy animation component.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetIsUsingLegacyAnimationComponent : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Is Using Legacy Animation Component")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getIsUsingLegacyAnimationComponent;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getIsUsingLegacyAnimationComponent);
		}
		
		public override void Execute()
		{
			_getIsUsingLegacyAnimationComponent.Value = _tMP_Text.Value.isUsingLegacyAnimationComponent;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} is using legacy animation component -> {_getIsUsingLegacyAnimationComponent}";
		}
	}
}
