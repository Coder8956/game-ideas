
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Sprite Asset used by the text object.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetSpriteAsset : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Sprite Asset")]
		[SerializeField, CanBeNullOrEmpty]
		private TMP_SpriteAssetVar _setSpriteAsset;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.spriteAsset = _setSpriteAsset.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} sprite asset to {_setSpriteAsset}";
		}
	}
}
