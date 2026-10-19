
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Touch)]
	[ActionDescription("Value of 0 radians indicates that the stylus is pointed along the x-axis of the d" +
		"evice.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Touch-azimuthAngle.html")]
	public sealed class TouchGetAzimuthAngle : BaseAction
	{
		
		[Tooltip("The Touch")]
		[SerializeField]
		private TouchRef _touch;
		
		[Tooltip("Get Touch Azimuth Angle")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getAzimuthAngle;
		
		public override bool CanExecute()
		{
			return CheckParameters(_touch, _getAzimuthAngle);
		}
		
		public override void Execute()
		{
			_getAzimuthAngle.Value = _touch.Value.azimuthAngle;
		}
		
		public override string GetSummary()
		{
			return "Get {_touch} azimuthAngle -> {_getAzimuthAngle}";
		}
	}
}
