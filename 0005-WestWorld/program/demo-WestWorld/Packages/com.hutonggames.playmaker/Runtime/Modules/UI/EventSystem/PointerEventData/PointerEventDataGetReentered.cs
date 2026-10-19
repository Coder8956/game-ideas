
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PointerEventData)]
	[ActionDescription("Specifies in the case of a pointer enter if the pointer has entered a new area or if it has just reentered a parent after leaving a child")]
	[HelpURL("https://docs.unity3d.com/2019.1/Documentation/ScriptReference/EventSystems.PointerEventData.html")]
	public sealed class PointerEventDataGetReentered : BaseAction
	{
		
		[Tooltip("The PointerEventData")]
		[SerializeField]
		private PointerEventDataRef _pointerEventData;
		
		[Tooltip("Get PointerEventData Reentered")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getReentered;
		
		public override bool CanExecute()
		{
			return CheckParameters(_pointerEventData, _getReentered);
		}
		
		public override void Execute()
		{
			if (_pointerEventData.Value == null) return;
			_getReentered.Value = _pointerEventData.Value.reentered;
		}
		
		public override string GetSummary()
		{
			return "Get {_pointerEventData} reentered -> {_getReentered}";
		}
	}
}
