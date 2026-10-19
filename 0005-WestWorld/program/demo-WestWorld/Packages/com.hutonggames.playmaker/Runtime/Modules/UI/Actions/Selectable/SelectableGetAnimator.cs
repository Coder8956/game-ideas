
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Selectable)]
	[ActionDescription("Convenience function to get the Animator component on the GameObject.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.UI.Selectable.html")]
	public sealed class SelectableGetAnimator : BaseAction
	{
		
		[Tooltip("The Selectable")]
		[SerializeField]
		private SelectableVar _selectable;
		
		[Tooltip("Get Selectable Animator")]
		[SerializeField]
		[WriteOnly]
		private AnimatorVar _getAnimator;
		
		public override bool CanExecute()
		{
			return CheckParameters(_selectable, _getAnimator);
		}
		
		public override void Execute()
		{
			_getAnimator.Value = _selectable.Value.animator;
		}
		
		public override string GetSummary()
		{
			return "Get {_selectable} animator -> {_getAnimator}";
		}
	}
}
