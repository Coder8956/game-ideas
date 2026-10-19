
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactPoint2D)]
	[ActionDescription("The incoming Collider2D involved in the collision with the otherCollider.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactPoint2D-collider.html")]
	public sealed class ContactPoint2DGetCollider : BaseAction
	{
		
		[Tooltip("The ContactPoint2D")]
		[SerializeField]
		private ContactPoint2DRef _contactPoint2D;
		
		[Tooltip("Get ContactPoint2D Collider")]
		[SerializeField]
		[WriteOnly]
		private Collider2DRef _getCollider;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactPoint2D, _getCollider);
		}
		
		public override void Execute()
		{
			_getCollider.Value = _contactPoint2D.Value.collider;
		}
		
		public override string GetSummary()
		{
			return "Get {_contactPoint2D} collider -> {_getCollider}";
		}
	}
}
