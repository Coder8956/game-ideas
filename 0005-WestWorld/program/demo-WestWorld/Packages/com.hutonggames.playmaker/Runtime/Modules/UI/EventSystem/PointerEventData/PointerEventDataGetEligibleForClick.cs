
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PointerEventData)]
	[ActionDescription("Is it possible to click this frame")]
	[HelpURL("https://docs.unity3d.com/2019.1/Documentation/ScriptReference/EventSystems.PointerEventData.html")]
	public sealed class PointerEventDataGetEligibleForClick : BaseAction
	{
		
		[Tooltip("The PointerEventData")]
		[SerializeField]
		private PointerEventDataRef _pointerEventData;
		
		[Tooltip("Get PointerEventData Eligible For Click")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getEligibleForClick;
		
		public override bool CanExecute()
		{
			return CheckParameters(_pointerEventData, _getEligibleForClick);
		}
		
		public override void Execute()
		{
			if (_pointerEventData.Value == null) return;
			_getEligibleForClick.Value = _pointerEventData.Value.eligibleForClick;
		}
		
		public override string GetSummary()
		{
			return "Get {_pointerEventData} eligible for click -> {_getEligibleForClick}";
		}
	}
}
