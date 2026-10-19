
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Toggle)]
	[ActionDescription("Group the toggle belongs to.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Toggle.html")]
	public sealed class ToggleSetGroup : BaseAction
	{
		
		[Tooltip("The Toggle")]
		[SerializeField]
		private ToggleVar _toggle;
		
		[Tooltip("Set Toggle Group")]
		[SerializeField, CanBeNullOrEmpty]
		private ToggleGroupVar _setGroup;
		
		public override bool CanExecute()
		{
			return CheckParameters(_toggle);
		}
		
		public override void Execute()
		{
			_toggle.Value.group = _setGroup.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_toggle} group to {_setGroup}";
		}
	}
}
