
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PointerEventData)]
	[ActionDescription("The camera associated with the last OnPointerPress event.")]
	[HelpURL("https://docs.unity3d.com/2019.1/Documentation/ScriptReference/EventSystems.PointerEventData.html")]
	public sealed class PointerEventDataGetPressEventCamera : BaseAction
	{
		
		[Tooltip("The PointerEventData")]
		[SerializeField]
		private PointerEventDataRef _pointerEventData;
		
		[Tooltip("Get PointerEventData Press Event Camera")]
		[SerializeField]
		[WriteOnly]
		private CameraVar _getPressEventCamera;
		
		public override bool CanExecute()
		{
			return CheckParameters(_pointerEventData, _getPressEventCamera);
		}
		
		public override void Execute()
		{
			if (_pointerEventData.Value == null) return;
			_getPressEventCamera.Value = _pointerEventData.Value.pressEventCamera;
		}
		
		public override string GetSummary()
		{
			return "Get {_pointerEventData} press event camera -> {_getPressEventCamera}";
		}
	}
}
