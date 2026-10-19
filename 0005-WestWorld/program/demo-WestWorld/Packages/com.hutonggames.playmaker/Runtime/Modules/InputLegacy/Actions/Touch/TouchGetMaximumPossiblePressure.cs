
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Touch)]
	[ActionDescription("The maximum possible pressure value for a platform. If Input.touchPressureSupport" +
		"ed returns false, the value of this property will always be 1.0f.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Touch-maximumPossiblePressure.html")]
	public sealed class TouchGetMaximumPossiblePressure : BaseAction
	{
		
		[Tooltip("The Touch")]
		[SerializeField]
		private TouchRef _touch;
		
		[Tooltip("Get Touch Maximum Possible Pressure")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getMaximumPossiblePressure;
		
		public override bool CanExecute()
		{
			return CheckParameters(_touch, _getMaximumPossiblePressure);
		}
		
		public override void Execute()
		{
			_getMaximumPossiblePressure.Value = _touch.Value.maximumPossiblePressure;
		}
		
		public override string GetSummary()
		{
			return "Get {_touch} maximumPossiblePressure -> {_getMaximumPossiblePressure}";
		}
	}
}
