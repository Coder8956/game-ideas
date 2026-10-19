
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_ToggleGroup)]
	[ActionDescription("Register a toggle with the group.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-ToggleGroup.html")]
	public sealed class ToggleGroupRegisterToggle : BaseAction
	{
		
		[Tooltip("The ToggleGroup.")]
		[SerializeField]
		private ToggleGroupVar _toggleGroup;
		
		[Tooltip("To register.")]
		[SerializeField]
		private ToggleVar _toggle;
		
		public override bool CanExecute()
		{
			return CheckParameters(_toggleGroup, _toggle);
		}
		
		public override void Execute()
		{
			//UnityEngine.UI.ToggleGroup.RegisterToggle(UnityEngine.UI.Toggle);
			_toggleGroup.Value.RegisterToggle(_toggle.Value);
		}
		
		public override string GetSummary()
		{
			return "Register {_toggle} with {_toggleGroup}";
		}
	}
}
