
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_ToggleGroup)]
	[ActionDescription("Gets the toggle that is the first in the list of active toggles. ")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-ToggleGroup.html")]
	public sealed class ToggleGroupGetFirstActiveToggle : BaseAction
	{
		
		[Tooltip("The ToggleGroup.")]
		[SerializeField]
		private ToggleGroupVar _toggleGroup;
		
		[Tooltip("Store the result in Toggle variable.")]
		[SerializeField]
		[WriteOnly]
		private ToggleRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_toggleGroup, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.UI.ToggleGroup.GetFirstActiveToggle();
			_result.Value = _toggleGroup.Value.GetFirstActiveToggle();
		}
		
		public override string GetSummary()
		{
			return "Get {_toggleGroup} first active toggle -> {_result}";
		}
	}
}
