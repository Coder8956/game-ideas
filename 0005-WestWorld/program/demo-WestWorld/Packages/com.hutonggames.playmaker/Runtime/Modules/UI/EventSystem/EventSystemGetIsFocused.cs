
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.EventSystem)]
	[ActionDescription("Flag to say whether the EventSystem thinks it should be paused or not based upon focused state.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EventSystems.EventSystem-isFocused.html")]
	public sealed class EventSystemGetIsFocused : BaseAction
	{
		
		[Tooltip("The EventSystem")]
		[SerializeField, DefaultValue("~EventSystemCurrent")]
		private EventSystems.EventSystemVar _eventSystem;
		
		[Tooltip("Get EventSystem Is Focused")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getIsFocused;
		
		public override bool CanExecute()
		{
			return CheckParameters(_eventSystem, _getIsFocused);
		}
		
		public override void Execute()
		{
			_getIsFocused.Value = _eventSystem.Value.isFocused;
		}
		
		public override string GetSummary()
		{
			return "Get {_eventSystem:hide} is focused -> {_getIsFocused}";
		}
	}
}
