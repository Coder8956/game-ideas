
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.EventSystem)]
	[ActionDescription("Return the current EventSystem.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EventSystems.EventSystem-current.html")]
	public sealed class EventSystemGetCurrent : BaseAction
	{
		
		[Tooltip("Get EventSystem Current")]
		[SerializeField]
		[WriteOnly]
		private EventSystems.EventSystemRef _getCurrent;
		
		public override bool CanExecute() => CheckParameters(_getCurrent);

		public override void Execute() => _getCurrent.Value = EventSystem.current;

		public override string GetSummary() => "Get current EventSystem -> {_getCurrent}";
	}
}
