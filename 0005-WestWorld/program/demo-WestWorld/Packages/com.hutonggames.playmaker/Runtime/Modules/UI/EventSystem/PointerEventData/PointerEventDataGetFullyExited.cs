
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PointerEventData)]
	[ActionDescription("Specifies in the case of a pointer exit if the pointer has fully exited the area or if it has just entered a child.")]
	[HelpURL("https://docs.unity3d.com/2019.1/Documentation/ScriptReference/EventSystems.PointerEventData.html")]
	public sealed class PointerEventDataGetFullyExited : BaseAction
	{
		
		[Tooltip("The PointerEventData")]
		[SerializeField]
		private PointerEventDataRef _pointerEventData;
		
		[Tooltip("Get PointerEventData Fully Exited")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getFullyExited;
		
		public override bool CanExecute()
		{
			return CheckParameters(_pointerEventData, _getFullyExited);
		}
		
		public override void Execute()
		{
			if (_pointerEventData.Value == null) return;
			_getFullyExited.Value = _pointerEventData.Value.fullyExited;
		}
		
		public override string GetSummary()
		{
			return "Get {_pointerEventData} fully exited -> {_getFullyExited}";
		}
	}
}
