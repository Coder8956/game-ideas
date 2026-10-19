
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Selectable)]
	[ActionDescription("The type of transition that will be applied to the targetGraphic when the state changes.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.UI.Selectable.html")]
	public sealed class SelectableSetTransition : BaseAction
	{
		
		[Tooltip("The Selectable")]
		[SerializeField]
		private SelectableVar _selectable;
		
		[Tooltip("Set Selectable Transition")]
		[SerializeField]
		private Selectable_TransitionVar _setTransition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_selectable, _setTransition);
		}
		
		public override void Execute()
		{
			_selectable.Value.transition = _setTransition.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_selectable} transition to {_setTransition}";
		}
	}
}
