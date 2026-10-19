
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PointerEventData)]
	[ActionDescription("The amount of scroll since the last update.")]
	[HelpURL("https://docs.unity3d.com/2019.1/Documentation/ScriptReference/EventSystems.PointerEventData.html")]
	public sealed class PointerEventDataGetScrollDelta : BaseAction
	{
		
		[Tooltip("The PointerEventData")]
		[SerializeField]
		private PointerEventDataRef _pointerEventData;
		
		[Tooltip("Get PointerEventData Scroll Delta")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getScrollDelta;
		
		public override bool CanExecute()
		{
			return CheckParameters(_pointerEventData, _getScrollDelta);
		}
		
		public override void Execute()
		{
			if (_pointerEventData.Value == null) return;
			_getScrollDelta.Value = _pointerEventData.Value.scrollDelta;
		}
		
		public override string GetSummary()
		{
			return "Get {_pointerEventData} scroll delta -> {_getScrollDelta}";
		}
	}
}
