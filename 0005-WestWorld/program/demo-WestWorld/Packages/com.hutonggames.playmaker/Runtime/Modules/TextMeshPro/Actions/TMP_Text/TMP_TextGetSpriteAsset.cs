
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Sprite Asset used by the text object.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetSpriteAsset : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Sprite Asset")]
		[SerializeField]
		[WriteOnly]
		private TMP_SpriteAssetRef _getSpriteAsset;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getSpriteAsset);
		}
		
		public override void Execute()
		{
			_getSpriteAsset.Value = _tMP_Text.Value.spriteAsset;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} sprite asset -> {_getSpriteAsset}";
		}
	}
}
