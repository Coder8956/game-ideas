
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.EventSystem)]
	[ActionDescription("The GameObject that was selected first.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EventSystems.EventSystem-firstSelectedGameObject.html")]
	public sealed class EventSystemSetFirstSelectedGameObject : BaseAction
	{
		
		[Tooltip("The EventSystem")]
		[SerializeField, DefaultValue("~EventSystemCurrent")]
		private EventSystems.EventSystemVar _eventSystem;
		
		[Tooltip("Set EventSystem First Selected GameObject")]
		[SerializeField, CanBeNullOrEmpty]
		private GameObjectVar _setFirstSelectedGameObject;
		
		public override bool CanExecute()
		{
			return CheckParameters(_eventSystem);
		}
		
		public override void Execute()
		{
			_eventSystem.Value.firstSelectedGameObject = _setFirstSelectedGameObject.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_eventSystem:hide} first selected GameObject to {_setFirstSelectedGameObject}";
		}
	}
}
