
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.EventSystem)]
	[ActionDescription("Recalculate the internal list of BaseInputModules.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EventSystems.EventSystem.UpdateModules.html")]
	public sealed class EventSystemUpdateModules : BaseAction
	{
		
		[Tooltip("The EventSystem.")]
		[SerializeField, DefaultValue("~EventSystemCurrent")]
		private EventSystems.EventSystemVar _eventSystem;
		
		public override bool CanExecute()
		{
			return CheckParameters(_eventSystem);
		}
		
		public override void Execute()
		{
			//UnityEngine.EventSystems.EventSystem.UpdateModules();
			_eventSystem.Value.UpdateModules();
		}
		
		public override string GetSummary()
		{
			return "Update {_eventSystem:hide} modules";
		}
	}
}
