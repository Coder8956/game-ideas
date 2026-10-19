
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("This is the default vertex color assigned to each vertices. Color tags will override vertex colors unless the overrideColorTags is set.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetColor : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Color")]
		[SerializeField]
		private ColorVar _setColor;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setColor);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.color = _setColor.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} color to {_setColor}";
		}
	}
}
