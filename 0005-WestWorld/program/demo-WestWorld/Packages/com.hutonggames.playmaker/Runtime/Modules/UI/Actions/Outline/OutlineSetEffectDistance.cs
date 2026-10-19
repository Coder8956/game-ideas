
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Outline)]
	[ActionDescription("How far is the outline from the graphic.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Outline.html")]
	public sealed class OutlineSetEffectDistance : BaseAction
	{
		
		[Tooltip("The Outline")]
		[SerializeField]
		private UI.OutlineVar _outline;
		
		[Tooltip("Set Outline Effect Distance")]
		[SerializeField]
		private Vector2Var _setEffectDistance;
		
		public override bool CanExecute()
		{
			return CheckParameters(_outline, _setEffectDistance);
		}
		
		public override void Execute()
		{
			_outline.Value.effectDistance = _setEffectDistance.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_outline} effect distance to {_setEffectDistance}";
		}
	}
}
