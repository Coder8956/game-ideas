
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PointerEventData)]
	[ActionDescription("Position of the press.")]
	[HelpURL("https://docs.unity3d.com/2019.1/Documentation/ScriptReference/EventSystems.PointerEventData.html")]
	public sealed class PointerEventDataGetPressPosition : BaseAction
	{
		
		[Tooltip("The PointerEventData")]
		[SerializeField]
		private PointerEventDataRef _pointerEventData;
		
		[Tooltip("Get PointerEventData Press Position")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getPressPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_pointerEventData, _getPressPosition);
		}
		
		public override void Execute()
		{
			if (_pointerEventData.Value == null) return;
			_getPressPosition.Value = _pointerEventData.Value.pressPosition;
		}
		
		public override string GetSummary()
		{
			return "Get {_pointerEventData} press position -> {_getPressPosition}";
		}
	}
}
