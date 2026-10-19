
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Tweens the alpha of the CanvasRenderer color associated with this Graphic.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextCrossFadeAlpha : BaseAction
	{
		
		[Tooltip("The TMP_Text.")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Alpha.")]
		[SerializeField]
		private FloatVar _alpha;
		
		[Tooltip("Duration.")]
		[SerializeField]
		private FloatVar _duration;
		
		[Tooltip("Use unscaled realtime.")]
		[SerializeField]
        [FormerlySerializedAs("_ignoreTimeScale")]
		private BoolVar _useRealtime;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _alpha, _duration, _useRealtime);
		}
		
		public override void Execute()
		{
			//TMPro.TMP_Text.CrossFadeAlpha(System.Single, System.Single, System.Boolean);
			_tMP_Text.Value.CrossFadeAlpha(_alpha.Value, _duration.Value, _useRealtime.Value);
		}
		
		public override string GetSummary()
		{
			return "Cross fade {_tMP_Text} alpha {_alpha} {_duration} {_useRealtime:option}";
		}
	}
}
