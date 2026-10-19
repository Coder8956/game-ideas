
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PointerEventData)]
	[ActionDescription("Current pointer position.")]
	[HelpURL("https://docs.unity3d.com/2019.1/Documentation/ScriptReference/EventSystems.PointerEventData.html")]
	public sealed class PointerEventDataGetPosition : BaseAction
	{
		
		[Tooltip("The PointerEventData")]
		[SerializeField]
		private PointerEventDataRef _pointerEventData;
		
		[Tooltip("Get PointerEventData Position")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_pointerEventData, _getPosition);
		}
		
		public override void Execute()
		{
			if (_pointerEventData.Value == null) return;
			_getPosition.Value = _pointerEventData.Value.position;
		}
		
		public override string GetSummary()
		{
			return "Get {_pointerEventData} position -> {_getPosition}";
		}
	}
}
