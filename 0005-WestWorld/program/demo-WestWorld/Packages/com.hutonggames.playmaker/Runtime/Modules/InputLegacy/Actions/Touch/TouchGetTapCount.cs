
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Touch)]
	[ActionDescription("Number of taps.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Touch-tapCount.html")]
	public sealed class TouchGetTapCount : BaseAction
	{
		
		[Tooltip("The Touch")]
		[SerializeField]
		private TouchRef _touch;
		
		[Tooltip("Get Touch Tap Count")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getTapCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_touch, _getTapCount);
		}
		
		public override void Execute()
		{
			_getTapCount.Value = _touch.Value.tapCount;
		}
		
		public override string GetSummary()
		{
			return "Get {_touch} tapCount -> {_getTapCount}";
		}
	}
}
