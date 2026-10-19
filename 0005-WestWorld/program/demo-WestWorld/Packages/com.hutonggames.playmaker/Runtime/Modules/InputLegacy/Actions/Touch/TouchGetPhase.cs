
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Touch)]
	[ActionDescription("Describes the phase of the touch.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Touch-phase.html")]
	public sealed class TouchGetPhase : BaseAction
	{
		
		[Tooltip("The Touch")]
		[SerializeField]
		private TouchRef _touch;
		
		[Tooltip("Get Touch Phase")]
		[SerializeField]
		[WriteOnly]
		private TouchPhaseRef _getPhase;
		
		public override bool CanExecute()
		{
			return CheckParameters(_touch, _getPhase);
		}
		
		public override void Execute()
		{
			_getPhase.Value = _touch.Value.phase;
		}
		
		public override string GetSummary()
		{
			return "Get {_touch} phase -> {_getPhase}";
		}
	}
}
