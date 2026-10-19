
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PointerEventData)]
	[ActionDescription("The object that is receiving \'OnDrag\'.")]
	[HelpURL("https://docs.unity3d.com/2019.1/Documentation/ScriptReference/EventSystems.PointerEventData.html")]
	public sealed class PointerEventDataGetPointerDrag : BaseAction
	{
		
		[Tooltip("The PointerEventData")]
		[SerializeField]
		private PointerEventDataRef _pointerEventData;
		
		[Tooltip("Get PointerEventData Pointer Drag")]
		[SerializeField]
		[WriteOnly]
		private GameObjectRef _getPointerDrag;
		
		public override bool CanExecute()
		{
			return CheckParameters(_pointerEventData, _getPointerDrag);
		}
		
		public override void Execute()
		{
			if (_pointerEventData.Value == null) return;
			_getPointerDrag.Value = _pointerEventData.Value.pointerDrag;
		}
		
		public override string GetSummary()
		{
			return "Get {_pointerEventData} pointer drag -> {_getPointerDrag}";
		}
	}
}
