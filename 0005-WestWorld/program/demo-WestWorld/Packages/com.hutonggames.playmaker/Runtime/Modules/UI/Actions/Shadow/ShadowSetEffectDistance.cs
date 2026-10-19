
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Shadow)]
	[ActionDescription("How far is the shadow from the graphic.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Shadow.html")]
	public sealed class ShadowSetEffectDistance : BaseAction
	{
		
		[Tooltip("The Shadow")]
		[SerializeField]
		private UI.ShadowVar _shadow;
		
		[Tooltip("Set Shadow Effect Distance")]
		[SerializeField]
		private Vector2Var _setEffectDistance;
		
		public override bool CanExecute()
		{
			return CheckParameters(_shadow, _setEffectDistance);
		}
		
		public override void Execute()
		{
			_shadow.Value.effectDistance = _setEffectDistance.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_shadow} effect distance to {_setEffectDistance}";
		}
	}
}
