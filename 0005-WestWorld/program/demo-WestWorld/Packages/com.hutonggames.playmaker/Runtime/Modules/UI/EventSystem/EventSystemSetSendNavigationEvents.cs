
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.EventSystem)]
	[ActionDescription("Should the EventSystem allow navigation events (move submit cancel).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EventSystems.EventSystem-sendNavigationEvents.html")]
	public sealed class EventSystemSetSendNavigationEvents : BaseAction
	{
		
		[Tooltip("The EventSystem")]
		[SerializeField, DefaultValue("~EventSystemCurrent")]
		private EventSystems.EventSystemVar _eventSystem;
		
		[Tooltip("Set EventSystem Send Navigation Events")]
		[SerializeField]
		private BoolVar _setSendNavigationEvents;
		
		public override bool CanExecute()
		{
			return CheckParameters(_eventSystem, _setSendNavigationEvents);
		}
		
		public override void Execute()
		{
			_eventSystem.Value.sendNavigationEvents = _setSendNavigationEvents.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_eventSystem:hide} send navigation events to {_setSendNavigationEvents}";
		}
	}
}
