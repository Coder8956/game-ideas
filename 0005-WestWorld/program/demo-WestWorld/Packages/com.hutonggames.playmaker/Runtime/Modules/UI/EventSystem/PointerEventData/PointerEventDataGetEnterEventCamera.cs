
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PointerEventData)]
	[ActionDescription("The camera associated with the last OnPointerEnter event.")]
	[HelpURL("https://docs.unity3d.com/2019.1/Documentation/ScriptReference/EventSystems.PointerEventData.html")]
	public sealed class PointerEventDataGetEnterEventCamera : BaseAction
	{
		
		[Tooltip("The PointerEventData")]
		[SerializeField]
		private PointerEventDataRef _pointerEventData;
		
		[Tooltip("Get PointerEventData Enter Event Camera")]
		[SerializeField]
		[WriteOnly]
		private CameraVar _getEnterEventCamera;
		
		public override bool CanExecute()
		{
			return CheckParameters(_pointerEventData, _getEnterEventCamera);
		}
		
		public override void Execute()
		{
			if (_pointerEventData.Value == null) return;
			_getEnterEventCamera.Value = _pointerEventData.Value.enterEventCamera;
		}
		
		public override string GetSummary()
		{
			return "Get {_pointerEventData} enter event camera -> {_getEnterEventCamera}";
		}
	}
}
