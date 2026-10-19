
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Touch)]
	[ActionDescription("The current amount of pressure being applied to a touch. 1.0f is considered to be" +
		" the pressure of an average touch. If Input.touchPressureSupported returns false" +
		", the value of this property will always be 1.0f.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Touch-pressure.html")]
	public sealed class TouchGetPressure : BaseAction
	{
		
		[Tooltip("The Touch")]
		[SerializeField]
		private TouchRef _touch;
		
		[Tooltip("Get Touch Pressure")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getPressure;
		
		public override bool CanExecute()
		{
			return CheckParameters(_touch, _getPressure);
		}
		
		public override void Execute()
		{
			_getPressure.Value = _touch.Value.pressure;
		}
		
		public override string GetSummary()
		{
			return "Get {_touch} pressure -> {_getPressure}";
		}
	}
}
