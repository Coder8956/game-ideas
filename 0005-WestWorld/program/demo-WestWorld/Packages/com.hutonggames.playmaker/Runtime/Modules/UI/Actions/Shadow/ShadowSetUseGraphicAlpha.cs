
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Shadow)]
	[ActionDescription("Should the shadow inherit the alpha from the graphic?")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Shadow.html")]
	public sealed class ShadowSetUseGraphicAlpha : BaseAction
	{
		
		[Tooltip("The Shadow")]
		[SerializeField]
		private UI.ShadowVar _shadow;
		
		[Tooltip("Set Shadow Use Graphic Alpha")]
		[SerializeField]
		private BoolVar _setUseGraphicAlpha;
		
		public override bool CanExecute()
		{
			return CheckParameters(_shadow, _setUseGraphicAlpha);
		}
		
		public override void Execute()
		{
			_shadow.Value.useGraphicAlpha = _setUseGraphicAlpha.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_shadow} use graphic alpha to {_setUseGraphicAlpha}";
		}
	}
}
