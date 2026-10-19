
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Shadow)]
	[ActionDescription("Color for the effect.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Shadow.html")]
	public sealed class ShadowSetEffectColor : BaseAction
	{
		
		[Tooltip("The Shadow")]
		[SerializeField]
		private UI.ShadowVar _shadow;
		
		[Tooltip("Set Shadow Effect Color")]
		[SerializeField]
		private ColorVar _setEffectColor;
		
		public override bool CanExecute()
		{
			return CheckParameters(_shadow, _setEffectColor);
		}
		
		public override void Execute()
		{
			_shadow.Value.effectColor = _setEffectColor.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_shadow} effect color to {_setEffectColor}";
		}
	}
}
