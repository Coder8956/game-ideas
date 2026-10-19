
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.EventSystems
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PointerEventData)]
	[ActionDescription("The angle of the stylus relative to the surface, in radians.")]
	[HelpURL("https://docs.unity3d.com/2019.1/Documentation/ScriptReference/EventSystems.PointerEventData.html")]
	public sealed class PointerEventDataGetAltitudeAngle : BaseAction
	{
		
		[Tooltip("The PointerEventData")]
		[SerializeField]
		private PointerEventDataRef _pointerEventData;
		
		[Tooltip("Get PointerEventData Altitude Angle. " +
		         "A value of 0 indicates that the stylus is parallel to the surface. " +
		         "A value of pi/2 indicates that it is perpendicular to the surface.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getAltitudeAngle;
		
		public override bool CanExecute()
		{
			return CheckParameters(_pointerEventData, _getAltitudeAngle);
		}
		
		public override void Execute()
		{
			if (_pointerEventData.Value == null) return;
			_getAltitudeAngle.Value = _pointerEventData.Value.altitudeAngle;
		}
		
		public override string GetSummary()
		{
			return "Get {_pointerEventData} altitude angle -> {_getAltitudeAngle}";
		}
	}
}
