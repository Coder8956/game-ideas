
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Touch)]
	[ActionDescription("Value of 0 radians indicates that the stylus is parallel to the surface, pi/2 ind" +
		"icates that it is perpendicular.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Touch-altitudeAngle.html")]
	public sealed class TouchGetAltitudeAngle : BaseAction
	{
		
		[Tooltip("The Touch")]
		[SerializeField]
		private TouchRef _touch;
		
		[Tooltip("Get Touch Altitude Angle")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getAltitudeAngle;
		
		public override bool CanExecute()
		{
			return CheckParameters(_touch, _getAltitudeAngle);
		}
		
		public override void Execute()
		{
			_getAltitudeAngle.Value = _touch.Value.altitudeAngle;
		}
		
		public override string GetSummary()
		{
			return "Get {_touch} altitudeAngle -> {_getAltitudeAngle}";
		}
	}
}
