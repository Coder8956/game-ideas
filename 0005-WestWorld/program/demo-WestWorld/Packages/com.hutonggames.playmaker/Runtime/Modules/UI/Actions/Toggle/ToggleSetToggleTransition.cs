
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Toggle)]
	[ActionDescription("Transition mode for the toggle.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Toggle.html")]
	public sealed class ToggleSetToggleTransition : BaseAction
	{
		
		[Tooltip("The Toggle")]
		[SerializeField]
		private ToggleVar _toggle;
		
		[Tooltip("Set Toggle Toggle Transition")]
		[SerializeField]
		private Toggle_ToggleTransitionVar _setToggleTransition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_toggle, _setToggleTransition);
		}
		
		public override void Execute()
		{
			_toggle.Value.toggleTransition = _setToggleTransition.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_toggle} toggle transition to {_setToggleTransition}";
		}
	}
}
