
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Determines if a text object will be excluded from the InternalUpdate callback used to handle updates of SDF Scale when the scale of the text object or parent(s) changes.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetIsTextObjectScaleStatic : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Is Text Object Scale Static")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getIsTextObjectScaleStatic;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getIsTextObjectScaleStatic);
		}
		
		public override void Execute()
		{
			_getIsTextObjectScaleStatic.Value = _tMP_Text.Value.isTextObjectScaleStatic;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} is text object scale static -> {_getIsTextObjectScaleStatic}";
		}
	}
}
