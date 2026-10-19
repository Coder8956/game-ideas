
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Touch)]
	[ActionDescription("The position delta since last change in pixel coordinates.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Touch-deltaPosition.html")]
	public sealed class TouchGetDeltaPosition : BaseAction
	{
		
		[Tooltip("The Touch")]
		[SerializeField]
		private TouchRef _touch;
		
		[Tooltip("Get Touch Delta Position")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getDeltaPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_touch, _getDeltaPosition);
		}
		
		public override void Execute()
		{
			_getDeltaPosition.Value = _touch.Value.deltaPosition;
		}
		
		public override string GetSummary()
		{
			return "Get {_touch} deltaPosition -> {_getDeltaPosition}";
		}
	}
}
