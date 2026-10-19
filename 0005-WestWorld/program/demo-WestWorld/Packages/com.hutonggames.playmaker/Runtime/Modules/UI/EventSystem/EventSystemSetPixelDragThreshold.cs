
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.EventSystem)]
	[ActionDescription("The soft area for dragging in pixels.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EventSystems.EventSystem-pixelDragThreshold.html")]
	public sealed class EventSystemSetPixelDragThreshold : BaseAction
	{
		
		[Tooltip("The EventSystem")]
		[SerializeField, DefaultValue("~EventSystemCurrent")]
		private EventSystems.EventSystemVar _eventSystem;
		
		[Tooltip("Set EventSystem Pixel Drag Threshold")]
		[SerializeField]
		private IntegerVar _setPixelDragThreshold;
		
		public override bool CanExecute()
		{
			return CheckParameters(_eventSystem, _setPixelDragThreshold);
		}
		
		public override void Execute()
		{
			_eventSystem.Value.pixelDragThreshold = _setPixelDragThreshold.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_eventSystem:hide} pixel drag threshold to {_setPixelDragThreshold}";
		}
	}
}
