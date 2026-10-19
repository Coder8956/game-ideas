
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PointerEventData)]
	[ActionDescription("The object that should receive the 'OnPointerClick' event.")]
	[HelpURL("https://docs.unity3d.com/2019.1/Documentation/ScriptReference/EventSystems.PointerEventData.html")]
	public sealed class PointerEventDataGetPointerClick : BaseAction
	{
		
		[Tooltip("The PointerEventData")]
		[SerializeField]
		private PointerEventDataRef _pointerEventData;
		
		[Tooltip("Get PointerEventData Pointer Click")]
		[SerializeField]
		[WriteOnly]
		private GameObjectRef _getPointerClick;
		
		public override bool CanExecute()
		{
			return CheckParameters(_pointerEventData, _getPointerClick);
		}
		
		public override void Execute()
		{
			if (_pointerEventData.Value == null) return;
			_getPointerClick.Value = _pointerEventData.Value.pointerClick;
		}
		
		public override string GetSummary()
		{
			return "Get {_pointerEventData} pointer click -> {_getPointerClick}";
		}
	}
}
