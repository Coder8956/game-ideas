
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Touch)]
	[ActionDescription("This value determines the accuracy of the touch radius. Add this value to the rad" +
		"ius to get the maximum touch size, subtract it to get the minimum touch size.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Touch-radiusVariance.html")]
	public sealed class TouchGetRadiusVariance : BaseAction
	{
		
		[Tooltip("The Touch")]
		[SerializeField]
		private TouchRef _touch;
		
		[Tooltip("Get Touch Radius Variance")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getRadiusVariance;
		
		public override bool CanExecute()
		{
			return CheckParameters(_touch, _getRadiusVariance);
		}
		
		public override void Execute()
		{
			_getRadiusVariance.Value = _touch.Value.radiusVariance;
		}
		
		public override string GetSummary()
		{
			return "Get {_touch} radiusVariance -> {_getRadiusVariance}";
		}
	}
}
