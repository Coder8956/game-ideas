
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactFilter2D)]
	[ActionDescription("Checks if the collider is a trigger and should be filtered by the useTriggers to " +
		"be filtered.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactFilter2D.IsFilteringTrigger.html")]
	public sealed class ContactFilter2DIsFilteringTrigger : BaseAction
	{
		
		[Tooltip("The ContactFilter2D.")]
		[SerializeField]
		private ContactFilter2DRef _contactFilter2D;
		
		[Tooltip("The Collider2D used to check for a trigger.")]
		[SerializeField]
		private Collider2DVar _collider;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactFilter2D, _collider, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.ContactFilter2D.IsFilteringTrigger(UnityEngine.Collider2D);
			_result.Value = _contactFilter2D.Value.IsFilteringTrigger(_collider.Value);
		}
		
		public override string GetSummary()
		{
			return "Is Filtering Trigger {_contactFilter2D} {_collider} -> {_result}";
		}
	}
}
