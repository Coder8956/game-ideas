
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("The material to be assigned to this text object.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetFontSharedMaterial : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Font Shared Material")]
		[SerializeField, CanBeNullOrEmpty]
		private MaterialVar _setFontSharedMaterial;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.fontSharedMaterial = _setFontSharedMaterial.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} font shared material to {_setFontSharedMaterial}";
		}
	}
}
