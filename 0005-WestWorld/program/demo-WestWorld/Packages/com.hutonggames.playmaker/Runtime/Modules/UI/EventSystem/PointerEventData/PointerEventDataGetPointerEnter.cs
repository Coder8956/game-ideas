
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PointerEventData)]
	[ActionDescription("The object that received \'OnPointerEnter\'.")]
	[HelpURL("https://docs.unity3d.com/2019.1/Documentation/ScriptReference/EventSystems.PointerEventData.html")]
	public sealed class PointerEventDataGetPointerEnter : BaseAction
	{
		
		[Tooltip("The PointerEventData")]
		[SerializeField]
		private PointerEventDataRef _pointerEventData;
		
		[Tooltip("Get PointerEventData Pointer Enter")]
		[SerializeField]
		[WriteOnly]
		private GameObjectRef _getPointerEnter;
		
		public override bool CanExecute()
		{
			return CheckParameters(_pointerEventData, _getPointerEnter);
		}
		
		public override void Execute()
		{
			if (_pointerEventData.Value == null) return;
			_getPointerEnter.Value = _pointerEventData.Value.pointerEnter;
		}
		
		public override string GetSummary()
		{
			return "Get {_pointerEventData} pointer enter -> {_getPointerEnter}";
		}
	}
}
