
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Determines if a text object will be excluded from the InternalUpdate callback used to handle updates of SDF Scale when the scale of the text object or parent(s) changes.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetIsTextObjectScaleStatic : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Is Text Object Scale Static")]
		[SerializeField]
		private BoolVar _setIsTextObjectScaleStatic;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setIsTextObjectScaleStatic);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.isTextObjectScaleStatic = _setIsTextObjectScaleStatic.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} is text object scale static to {_setIsTextObjectScaleStatic}";
		}
	}
}
