
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.EventSystem)]
	[ActionDescription("Is the pointer over an EventSystem object?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EventSystems.EventSystem.IsPointerOverGameObject.html")]
	public sealed class EventSystemIsPointerOverGameObject : BaseAction
	{
		
		[Tooltip("The EventSystem.")]
		[SerializeField, DefaultValue("~EventSystemCurrent")]
		private EventSystems.EventSystemVar _eventSystem;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_eventSystem, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.EventSystems.EventSystem.IsPointerOverGameObject();
			_result.Value = _eventSystem.Value.IsPointerOverGameObject();
		}
		
		public override string GetSummary() => 
			"Check {_eventSystem:hide} pointer over GameObject -> {_result}";
	}
}
