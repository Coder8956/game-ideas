
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_ToggleGroup)]
	[ActionDescription("Toggle to unregister.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-ToggleGroup.html")]
	public sealed class ToggleGroupUnregisterToggle : BaseAction
	{
		
		[Tooltip("The ToggleGroup.")]
		[SerializeField]
		private ToggleGroupVar _toggleGroup;
		
		[Tooltip("Unregister toggle.")]
		[SerializeField]
		private ToggleVar _toggle;
		
		public override bool CanExecute()
		{
			return CheckParameters(_toggleGroup, _toggle);
		}
		
		public override void Execute()
		{
			//UnityEngine.UI.ToggleGroup.UnregisterToggle(UnityEngine.UI.Toggle);
			_toggleGroup.Value.UnregisterToggle(_toggle.Value);
		}
		
		public override string GetSummary()
		{
			return "Unregister {_toggle} from {_toggleGroup}";
		}
	}
}
