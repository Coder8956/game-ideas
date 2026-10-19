
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Determines whether or not the sprite color is multiplies by the vertex color of the text.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetTintAllSprites : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Tint All Sprites")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getTintAllSprites;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getTintAllSprites);
		}
		
		public override void Execute()
		{
			_getTintAllSprites.Value = _tMP_Text.Value.tintAllSprites;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} tint all sprites -> {_getTintAllSprites}";
		}
	}
}
