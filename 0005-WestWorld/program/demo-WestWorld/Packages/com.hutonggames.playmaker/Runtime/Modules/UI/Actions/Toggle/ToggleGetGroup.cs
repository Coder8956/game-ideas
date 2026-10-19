
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Toggle)]
	[ActionDescription("Group the toggle belongs to.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Toggle.html")]
	public sealed class ToggleGetGroup : BaseAction
	{
		
		[Tooltip("The Toggle")]
		[SerializeField]
		private ToggleVar _toggle;
		
		[Tooltip("Get Toggle Group")]
		[SerializeField]
		[WriteOnly]
		private ToggleGroupRef _getGroup;
		
		public override bool CanExecute()
		{
			return CheckParameters(_toggle, _getGroup);
		}
		
		public override void Execute()
		{
			_getGroup.Value = _toggle.Value.group;
		}
		
		public override string GetSummary()
		{
			return "Get {_toggle} group -> {_getGroup}";
		}
	}
}
