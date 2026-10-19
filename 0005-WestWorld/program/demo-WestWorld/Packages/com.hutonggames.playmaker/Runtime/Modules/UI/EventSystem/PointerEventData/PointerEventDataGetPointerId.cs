
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PointerEventData)]
	[ActionDescription("Id of the pointer (touch id).")]
	[HelpURL("https://docs.unity3d.com/2019.1/Documentation/ScriptReference/EventSystems.PointerEventData.html")]
	public sealed class PointerEventDataGetPointerId : BaseAction
	{
		
		[Tooltip("The PointerEventData")]
		[SerializeField]
		private PointerEventDataRef _pointerEventData;
		
		[Tooltip("Get PointerEventData Pointer Id")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getPointerId;
		
		public override bool CanExecute()
		{
			return CheckParameters(_pointerEventData, _getPointerId);
		}
		
		public override void Execute()
		{
			if (_pointerEventData.Value == null) return;
			_getPointerId.Value = _pointerEventData.Value.pointerId;
		}
		
		public override string GetSummary()
		{
			return "Get {_pointerEventData} pointer ID -> {_getPointerId}";
		}
	}
}
