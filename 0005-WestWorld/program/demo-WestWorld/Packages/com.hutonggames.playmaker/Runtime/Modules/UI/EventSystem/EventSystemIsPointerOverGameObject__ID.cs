
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.EventSystem)]
	[ActionDescription("Is the pointer with the given ID over an EventSystem object?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EventSystems.EventSystem.IsPointerOverGameObject.html")]
	public sealed class EventSystemIsPointerOverGameObject__ID : BaseAction
	{
		
		[Tooltip("The EventSystem.")]
		[SerializeField, DefaultValue("~EventSystemCurrent")]
		private EventSystems.EventSystemVar _eventSystem;
		
		[Tooltip("Pointer (touch / mouse) ID.")]
		[SerializeField]
		private IntegerVar _pointerId;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_eventSystem, _pointerId, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.EventSystems.EventSystem.IsPointerOverGameObject(System.Int32);
			_result.Value = _eventSystem.Value.IsPointerOverGameObject(_pointerId.Value);
		}
		
		public override string GetSummary()
		{
			return "Check {_eventSystem:hide} pointer {_pointerId} over GameObject -> {_result}";
		}
	}
}
