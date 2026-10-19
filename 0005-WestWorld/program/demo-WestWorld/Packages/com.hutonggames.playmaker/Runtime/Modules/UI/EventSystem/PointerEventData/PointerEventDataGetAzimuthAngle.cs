
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PointerEventData)]
	[ActionDescription("The angle of the stylus relative to the x-axis, in radians.")]
	[HelpURL("https://docs.unity3d.com/2019.1/Documentation/ScriptReference/EventSystems.PointerEventData.html")]
	public sealed class PointerEventDataGetAzimuthAngle : BaseAction
	{
		
		[Tooltip("The PointerEventData")]
		[SerializeField]
		private PointerEventDataRef _pointerEventData;
		
		[Tooltip("Get PointerEventData Azimuth Angle. " +
		         "A value of 0 indicates that the stylus is pointed along the x-axis of the device.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getAzimuthAngle;
		
		public override bool CanExecute()
		{
			return CheckParameters(_pointerEventData, _getAzimuthAngle);
		}
		
		public override void Execute()
		{
			if (_pointerEventData.Value == null) return;
			_getAzimuthAngle.Value = _pointerEventData.Value.azimuthAngle;
		}
		
		public override string GetSummary()
		{
			return "Get {_pointerEventData} azimuth angle -> {_getAzimuthAngle}";
		}
	}
}
