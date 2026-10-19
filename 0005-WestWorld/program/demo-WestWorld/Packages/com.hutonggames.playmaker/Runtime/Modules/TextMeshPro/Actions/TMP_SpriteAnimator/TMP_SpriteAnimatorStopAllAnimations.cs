
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_SpriteAnimator)]
	[ActionDescription("Stop all sprite animations")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_SpriteAnimator.html")]
	public sealed class TMP_SpriteAnimatorStopAllAnimations : BaseAction
	{
		
		[Tooltip("The TMP_SpriteAnimator.")]
		[SerializeField]
		private TMP_SpriteAnimatorVar _tMP_SpriteAnimator;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_SpriteAnimator);
		}
		
		public override void Execute()
		{
			//TMPro.TMP_SpriteAnimator.StopAllAnimations();
			_tMP_SpriteAnimator.Value.StopAllAnimations();
		}
		
		public override string GetSummary()
		{
			return "Stop all animations on {_tMP_SpriteAnimator}";
		}
	}
}
