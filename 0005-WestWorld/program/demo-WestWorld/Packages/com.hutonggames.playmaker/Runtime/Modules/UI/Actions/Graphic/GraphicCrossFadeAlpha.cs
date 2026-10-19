
using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.Serialization;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Graphic)]
	[ActionDescription("Tweens the alpha of the CanvasRenderer color associated with this Graphic.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.UI.Graphic.html")]
	public sealed class GraphicCrossFadeAlpha : BaseAction
	{
		
		[Tooltip("The Graphic.")]
		[SerializeField]
		private GraphicVar _graphic;
		
		[Tooltip("Target alpha.")]
		[SerializeField]
		private FloatVar _alpha;
		
		[Tooltip("Duration of the tween in seconds.")]
		[SerializeField]
		private FloatVar _duration;
		
		[Tooltip("Use unscaled realtime.")]
		[SerializeField]
        [FormerlySerializedAs("_ignoreTimeScale")]
		private BoolVar _useRealtime;
		
		public override bool CanExecute()
		{
			return CheckParameters(_graphic, _alpha, _duration, _useRealtime);
		}
		
		public override void Execute()
		{
			//UnityEngine.UI.Graphic.CrossFadeAlpha(System.Single, System.Single, System.Boolean);
			_graphic.Value.CrossFadeAlpha(_alpha.Value, _duration.Value, _useRealtime.Value);
		}
		
		public override string GetSummary()
		{
			return "Cross fade {_graphic} alpha to {_alpha} {_duration} {_useRealtime:option}";
		}
	}
}
