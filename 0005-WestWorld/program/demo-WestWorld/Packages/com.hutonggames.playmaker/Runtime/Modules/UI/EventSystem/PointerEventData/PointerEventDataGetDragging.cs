
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PointerEventData)]
	[ActionDescription("Is a drag operation currently occuring.")]
	[HelpURL("https://docs.unity3d.com/2019.1/Documentation/ScriptReference/EventSystems.PointerEventData.html")]
	public sealed class PointerEventDataGetDragging : BaseAction
	{
		
		[Tooltip("The PointerEventData")]
		[SerializeField]
		private PointerEventDataRef _pointerEventData;
		
		[Tooltip("Get PointerEventData Dragging")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getDragging;
		
		public override bool CanExecute()
		{
			return CheckParameters(_pointerEventData, _getDragging);
		}
		
		public override void Execute()
		{
			if (_pointerEventData.Value == null) return;
			_getDragging.Value = _pointerEventData.Value.dragging;
		}
		
		public override string GetSummary()
		{
			return "Get {_pointerEventData} dragging -> {_getDragging}";
		}
	}
}
