
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PointerEventData)]
	[ActionDescription("The InputButton for this event.")]
	[HelpURL("https://docs.unity3d.com/2019.1/Documentation/ScriptReference/EventSystems.PointerEventData.html")]
	public sealed class PointerEventDataGetButton : BaseAction
	{
		
		[Tooltip("The PointerEventData")]
		[SerializeField]
		private PointerEventDataRef _pointerEventData;
		
		[Tooltip("Get PointerEventData Button")]
		[SerializeField]
		[WriteOnly]
		private PointerEventData_InputButtonRef _getButton;
		
		public override bool CanExecute()
		{
			return CheckParameters(_pointerEventData, _getButton);
		}
		
		public override void Execute()
		{
			if (_pointerEventData.Value == null) return;
			_getButton.Value = _pointerEventData.Value.button;
		}
		
		public override string GetSummary()
		{
			return "Get {_pointerEventData} button -> {_getButton}";
		}
	}
}
