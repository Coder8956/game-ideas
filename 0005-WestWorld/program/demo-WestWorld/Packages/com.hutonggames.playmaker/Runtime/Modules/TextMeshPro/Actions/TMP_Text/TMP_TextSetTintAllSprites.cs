
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Tint all sprites.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetTintAllSprites : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Tint All Sprites")]
		[SerializeField]
		private BoolVar _setTintAllSprites;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setTintAllSprites);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.tintAllSprites = _setTintAllSprites.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} tint all sprites to {_setTintAllSprites}";
		}
	}
}
