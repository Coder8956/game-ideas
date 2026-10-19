
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("This is the default vertex color assigned to each vertices. Color tags will override vertex colors unless the overrideColorTags is set.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetColor : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Color")]
		[SerializeField]
		[WriteOnly]
		private ColorRef _getColor;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getColor);
		}
		
		public override void Execute()
		{
			_getColor.Value = _tMP_Text.Value.color;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} color -> {_getColor}";
		}
	}
}
