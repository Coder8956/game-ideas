
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.EventSystem)]
	[ActionDescription("The GameObject currently considered active by the EventSystem.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EventSystems.EventSystem-currentSelectedGameObject.html")]
	public sealed class EventSystemGetCurrentSelectedGameObject : BaseAction
	{
		
		[Tooltip("The EventSystem")]
		[SerializeField, DefaultValue("~EventSystemCurrent")]
		private EventSystems.EventSystemVar _eventSystem;
		
		[Tooltip("Get EventSystem Current Selected GameObject")]
		[SerializeField]
		[WriteOnly]
		private GameObjectRef _getCurrentSelectedGameObject;
		
		public override bool CanExecute()
		{
			return CheckParameters(_eventSystem, _getCurrentSelectedGameObject);
		}
		
		public override void Execute()
		{
			_getCurrentSelectedGameObject.Value = _eventSystem.Value.currentSelectedGameObject;
		}
		
		public override string GetSummary()
		{
			return "Get {_eventSystem:hide} current selected GameObject -> {_getCurrentSelectedGameObject}";
		}
	}
}
