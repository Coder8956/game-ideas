
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.EventSystem)]
	[ActionDescription("The soft area for dragging in pixels.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EventSystems.EventSystem-pixelDragThreshold.html")]
	public sealed class EventSystemGetPixelDragThreshold : BaseAction
	{
		
		[Tooltip("The EventSystem")]
		[SerializeField, DefaultValue("~EventSystemCurrent")]
		private EventSystems.EventSystemVar _eventSystem;
		
		[Tooltip("Get EventSystem Pixel Drag Threshold")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getPixelDragThreshold;
		
		public override bool CanExecute()
		{
			return CheckParameters(_eventSystem, _getPixelDragThreshold);
		}
		
		public override void Execute()
		{
			_getPixelDragThreshold.Value = _eventSystem.Value.pixelDragThreshold;
		}
		
		public override string GetSummary()
		{
			return "Get {_eventSystem:hide} pixel drag threshold -> {_getPixelDragThreshold}";
		}
	}
}
