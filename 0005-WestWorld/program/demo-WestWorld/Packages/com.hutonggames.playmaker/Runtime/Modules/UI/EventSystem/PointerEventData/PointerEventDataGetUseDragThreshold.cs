
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PointerEventData)]
	[ActionDescription("Should a drag threshold be used?")]
	[HelpURL("https://docs.unity3d.com/2019.1/Documentation/ScriptReference/EventSystems.PointerEventData.html")]
	public sealed class PointerEventDataGetUseDragThreshold : BaseAction
	{
		
		[Tooltip("The PointerEventData")]
		[SerializeField]
		private PointerEventDataRef _pointerEventData;
		
		[Tooltip("Get PointerEventData Use Drag Threshold")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getUseDragThreshold;
		
		public override bool CanExecute()
		{
			return CheckParameters(_pointerEventData, _getUseDragThreshold);
		}
		
		public override void Execute()
		{
			if (_pointerEventData.Value == null) return;
			_getUseDragThreshold.Value = _pointerEventData.Value.useDragThreshold;
		}
		
		public override string GetSummary()
		{
			return "Get {_pointerEventData} use drag threshold -> {_getUseDragThreshold}";
		}
	}
}
