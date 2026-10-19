
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_ToggleGroup)]
	[ActionDescription("Are any of the toggles on?")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-ToggleGroup.html")]
	public sealed class ToggleGroupAnyTogglesOn : BaseAction
	{
		
		[Tooltip("The ToggleGroup.")]
		[SerializeField]
		private ToggleGroupVar _toggleGroup;
		
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_toggleGroup, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.UI.ToggleGroup.AnyTogglesOn();
			_result.Value = _toggleGroup.Value.AnyTogglesOn();
		}
		
		public override string GetSummary()
		{
			return "Check {_toggleGroup} any toggles on -> {_result}";
		}
	}
}
