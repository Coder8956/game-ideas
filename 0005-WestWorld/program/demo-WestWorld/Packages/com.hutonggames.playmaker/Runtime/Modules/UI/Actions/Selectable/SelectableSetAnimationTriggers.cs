
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Selectable)]
	[ActionDescription("The AnimationTriggers for this selectable object.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.UI.Selectable.html")]
	public sealed class SelectableSetAnimationTriggers : BaseAction
	{
		
		[Tooltip("The Selectable")]
		[SerializeField]
		private SelectableVar _selectable;
		
		[Tooltip("Set Selectable Animation Triggers")]
		[SerializeField]
		private AnimationTriggersVar _setAnimationTriggers;
		
		public override bool CanExecute()
		{
			return CheckParameters(_selectable, _setAnimationTriggers);
		}
		
		public override void Execute()
		{
			_selectable.Value.animationTriggers = _setAnimationTriggers.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_selectable} animation triggers to {_setAnimationTriggers}";
		}
	}
}
