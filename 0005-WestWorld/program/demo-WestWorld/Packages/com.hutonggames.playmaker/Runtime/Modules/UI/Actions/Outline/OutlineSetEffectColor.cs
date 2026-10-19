
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Outline)]
	[ActionDescription("Color for the effect.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Outline.html")]
	public sealed class OutlineSetEffectColor : BaseAction
	{
		
		[Tooltip("The Outline")]
		[SerializeField]
		private UI.OutlineVar _outline;
		
		[Tooltip("Set Outline Effect Color")]
		[SerializeField]
		private ColorVar _setEffectColor;
		
		public override bool CanExecute()
		{
			return CheckParameters(_outline, _setEffectColor);
		}
		
		public override void Execute()
		{
			_outline.Value.effectColor = _setEffectColor.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_outline} effect color to {_setEffectColor}";
		}
	}
}
