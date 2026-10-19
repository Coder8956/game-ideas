
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.EventSystem)]
	[ActionDescription("Set the object as selected. Will send an OnDeselect to the old selected object and OnSelect to the new selected object.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EventSystems.EventSystem.SetSelectedGameObject.html")]
	public sealed class EventSystemSetSelectedGameObject : BaseAction
	{
		
		[Tooltip("The EventSystem.")]
		[SerializeField, DefaultValue("~EventSystemCurrent")]
		private EventSystems.EventSystemVar _eventSystem;
		
		[Tooltip("Selected.")]
		[SerializeField]
		private GameObjectVar _selected;
		
		public override bool CanExecute()
		{
			return CheckParameters(_eventSystem, _selected);
		}
		
		public override void Execute()
		{
			//UnityEngine.EventSystems.EventSystem.SetSelectedGameObject(UnityEngine.GameObject);
			_eventSystem.Value.SetSelectedGameObject(_selected.Value);
		}
		
		public override string GetSummary()
		{
			return "Set {_eventSystem:hide} selected GameObject to {_selected}";
		}
	}
}
