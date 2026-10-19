
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Property to handle legacy animation component.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetIsUsingLegacyAnimationComponent : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Is Using Legacy Animation Component")]
		[SerializeField]
		private BoolVar _setIsUsingLegacyAnimationComponent;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setIsUsingLegacyAnimationComponent);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.isUsingLegacyAnimationComponent = _setIsUsingLegacyAnimationComponent.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} is using legacy animation component to {_setIsUsingLegacyAnimationComponent}";
		}
	}
}
