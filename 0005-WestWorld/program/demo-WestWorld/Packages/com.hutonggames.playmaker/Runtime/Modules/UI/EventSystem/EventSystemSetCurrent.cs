
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.EventSystem)]
	[ActionDescription("Set the current EventSystem.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EventSystems.EventSystem-current.html")]
	public sealed class EventSystemSetCurrent : BaseAction
	{
		
		[Tooltip("Set EventSystem Current")]
		[SerializeField]
		private EventSystems.EventSystemVar _setCurrent;
		
		public override bool CanExecute()
		{
			return CheckParameters(_setCurrent);
		}
		
		public override void Execute()
		{
			EventSystem.current = _setCurrent.Value;
		}
		
		public override string GetSummary()
		{
			return "Set current EventSystem to {_setCurrent}";
		}
	}
}
