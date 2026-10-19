
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Touch)]
	[ActionDescription("An estimated value of the radius of a touch. Add radiusVariance to get the maximu" +
		"m touch size, subtract it to get the minimum touch size.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Touch-radius.html")]
	public sealed class TouchGetRadius : BaseAction
	{
		
		[Tooltip("The Touch")]
		[SerializeField]
		private TouchRef _touch;
		
		[Tooltip("Get Touch Radius")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getRadius;
		
		public override bool CanExecute()
		{
			return CheckParameters(_touch, _getRadius);
		}
		
		public override void Execute()
		{
			_getRadius.Value = _touch.Value.radius;
		}
		
		public override string GetSummary()
		{
			return "Get {_touch} radius -> {_getRadius}";
		}
	}
}
