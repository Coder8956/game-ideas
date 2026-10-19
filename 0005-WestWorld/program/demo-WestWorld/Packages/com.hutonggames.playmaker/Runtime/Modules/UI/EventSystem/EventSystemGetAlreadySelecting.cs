
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.EventSystem)]
	[ActionDescription("Returns true if the EventSystem is already in a SetSelectedGameObject.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EventSystems.EventSystem-alreadySelecting.html")]
	public sealed class EventSystemGetAlreadySelecting : BaseAction
	{
		
		[Tooltip("The EventSystem")]
		[SerializeField, DefaultValue("~EventSystemCurrent")]
		private EventSystems.EventSystemVar _eventSystem;
		
		[Tooltip("Get EventSystem Already Selecting")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getAlreadySelecting;
		
		public override bool CanExecute()
		{
			return CheckParameters(_eventSystem, _getAlreadySelecting);
		}
		
		public override void Execute()
		{
			_getAlreadySelecting.Value = _eventSystem.Value.alreadySelecting;
		}
		
		public override string GetSummary() => 
			"Get {_eventSystem:hide} already selecting -> {_getAlreadySelecting}";
	}
}
