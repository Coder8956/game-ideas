
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PointerEventData)]
	[ActionDescription("The GameObject that received the OnPointerDown.")]
	[HelpURL("https://docs.unity3d.com/2019.1/Documentation/ScriptReference/EventSystems.PointerEventData.html")]
	public sealed class PointerEventDataGetPointerPress : BaseAction
	{
		
		[Tooltip("The PointerEventData")]
		[SerializeField]
		private PointerEventDataRef _pointerEventData;
		
		[Tooltip("Get PointerEventData Pointer Press")]
		[SerializeField]
		[WriteOnly]
		private GameObjectRef _getPointerPress;
		
		public override bool CanExecute()
		{
			return CheckParameters(_pointerEventData, _getPointerPress);
		}
		
		public override void Execute()
		{
			if (_pointerEventData.Value == null) return;
			_getPointerPress.Value = _pointerEventData.Value.pointerPress;
		}
		
		public override string GetSummary()
		{
			return "Get {_pointerEventData} pointer press -> {_getPointerPress}";
		}
	}
}
