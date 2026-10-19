
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Outline)]
	[ActionDescription("Should the outline inherit the alpha from the graphic?")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Outline.html")]
	public sealed class OutlineSetUseGraphicAlpha : BaseAction
	{
		
		[Tooltip("The Outline")]
		[SerializeField]
		private UI.OutlineVar _outline;
		
		[Tooltip("Set Outline Use Graphic Alpha")]
		[SerializeField]
		private BoolVar _setUseGraphicAlpha;
		
		public override bool CanExecute()
		{
			return CheckParameters(_outline, _setUseGraphicAlpha);
		}
		
		public override void Execute()
		{
			_outline.Value.useGraphicAlpha = _setUseGraphicAlpha.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_outline} use graphic alpha to {_setUseGraphicAlpha}";
		}
	}
}
