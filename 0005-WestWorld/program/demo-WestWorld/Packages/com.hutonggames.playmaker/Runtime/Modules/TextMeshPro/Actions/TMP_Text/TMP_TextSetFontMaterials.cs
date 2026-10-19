
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("The materials to be assigned to this text object. An instance of the materials will be assigned.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetFontMaterials : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Font Materials")]
		[SerializeField]
		private MaterialListVar _setFontMaterials;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setFontMaterials);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.fontMaterials = _setFontMaterials.Values;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} font materials to {_setFontMaterials}";
		}
	}
}
