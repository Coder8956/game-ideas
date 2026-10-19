
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.EventSystem)]
	[ActionDescription("Should the EventSystem allow navigation events (move submit cancel).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EventSystems.EventSystem-sendNavigationEvents.html")]
	public sealed class EventSystemGetSendNavigationEvents : BaseAction
	{
		
		[Tooltip("The EventSystem")]
		[SerializeField, DefaultValue("~EventSystemCurrent")]
		private EventSystems.EventSystemVar _eventSystem;
		
		[Tooltip("Get EventSystem Send Navigation Events")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getSendNavigationEvents;
		
		public override bool CanExecute()
		{
			return CheckParameters(_eventSystem, _getSendNavigationEvents);
		}
		
		public override void Execute()
		{
			_getSendNavigationEvents.Value = _eventSystem.Value.sendNavigationEvents;
		}
		
		public override string GetSummary()
		{
			return "Get {_eventSystem:hide} send navigation events -> {_getSendNavigationEvents}";
		}
	}
}
