
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
	public sealed class SelectableGetAnimationTriggers : BaseAction
	{
		
		[Tooltip("The Selectable")]
		[SerializeField]
		private SelectableVar _selectable;
		
		[Tooltip("Get Selectable Animation Triggers")]
		[SerializeField]
		[WriteOnly]
		private AnimationTriggersRef _getAnimationTriggers;
		
		public override bool CanExecute()
		{
			return CheckParameters(_selectable, _getAnimationTriggers);
		}
		
		public override void Execute()
		{
			_getAnimationTriggers.Value = _selectable.Value.animationTriggers;
		}
		
		public override string GetSummary()
		{
			return "Get {_selectable} animation triggers -> {_getAnimationTriggers}";
		}
	}
}
