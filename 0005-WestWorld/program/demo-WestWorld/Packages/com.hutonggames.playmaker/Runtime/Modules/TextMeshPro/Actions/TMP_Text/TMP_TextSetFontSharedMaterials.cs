
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("A list containing the materials used by the text object.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetFontSharedMaterials : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Font Shared Materials")]
		[SerializeField]
		private MaterialListVar _setFontSharedMaterials;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setFontSharedMaterials);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.fontSharedMaterials = _setFontSharedMaterials.Values;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} font shared materials to {_setFontSharedMaterials}";
		}
	}
}
