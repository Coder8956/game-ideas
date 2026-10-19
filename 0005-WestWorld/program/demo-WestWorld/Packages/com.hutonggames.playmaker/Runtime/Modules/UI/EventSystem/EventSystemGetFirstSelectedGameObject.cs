
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.EventSystem)]
	[ActionDescription("The GameObject that was selected first.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EventSystems.EventSystem-firstSelectedGameObject.html")]
	public sealed class EventSystemGetFirstSelectedGameObject : BaseAction
	{
		
		[Tooltip("The EventSystem")]
		[SerializeField, DefaultValue("~EventSystemCurrent")]
		private EventSystems.EventSystemVar _eventSystem;
		
		[Tooltip("Get EventSystem First Selected GameObject")]
		[SerializeField]
		[WriteOnly]
		private GameObjectRef _getFirstSelectedGameObject;
		
		public override bool CanExecute()
		{
			return CheckParameters(_eventSystem, _getFirstSelectedGameObject);
		}
		
		public override void Execute()
		{
			_getFirstSelectedGameObject.Value = _eventSystem.Value.firstSelectedGameObject;
		}
		
		public override string GetSummary()
		{
			return "Get {_eventSystem:hide} first selected GameObject -> {_getFirstSelectedGameObject}";
		}
	}
}
