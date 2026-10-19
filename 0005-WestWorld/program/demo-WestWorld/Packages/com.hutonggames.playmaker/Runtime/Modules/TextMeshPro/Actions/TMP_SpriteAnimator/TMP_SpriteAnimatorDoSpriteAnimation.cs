
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_SpriteAnimator)]
	[ActionDescription("Animate a single sprite character.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_SpriteAnimator.html")]
	public sealed class TMP_SpriteAnimatorDoSpriteAnimation : BaseAction
	{
		
		[Tooltip("The TMP_SpriteAnimator.")]
		[SerializeField]
		private TMP_SpriteAnimatorVar _tMP_SpriteAnimator;
		
		[Tooltip("Current Character.")]
		[SerializeField]
		private IntegerVar _currentCharacter;
		
		[Tooltip("Sprite Asset.")]
		[SerializeField]
		private TMP_SpriteAssetVar _spriteAsset;
		
		[Tooltip("Start frame.")]
		[SerializeField]
		private IntegerVar _start;
		
		[Tooltip("End frame.")]
		[SerializeField]
		private IntegerVar _end;
		
		[Tooltip("Framerate.")]
		[SerializeField]
		private IntegerVar _framerate;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_SpriteAnimator, _currentCharacter, _spriteAsset, _start, _end, _framerate);
		}
		
		public override void Execute()
		{
			//TMPro.TMP_SpriteAnimator.DoSpriteAnimation(System.Int32, TMPro.TMP_SpriteAsset, System.Int32, System.Int32, System.Int32);
			_tMP_SpriteAnimator.Value.DoSpriteAnimation(_currentCharacter.Value, _spriteAsset.Value, _start.Value, _end.Value, _framerate.Value);
		}
		
		public override string GetSummary()
		{
			return "Do sprite animation on {_tMP_SpriteAnimator} {_currentCharacter} {_spriteAsset} {_start} {_end} {_framerate}";
		}
	}
}
