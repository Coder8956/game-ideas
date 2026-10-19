
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactPoint2D)]
	[ActionDescription("The other Collider2D involved in the collision with the collider.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactPoint2D-otherCollider.html")]
	public sealed class ContactPoint2DGetOtherCollider : BaseAction
	{
		
		[Tooltip("The ContactPoint2D")]
		[SerializeField]
		private ContactPoint2DRef _contactPoint2D;
		
		[Tooltip("Get ContactPoint2D Other Collider")]
		[SerializeField]
		[WriteOnly]
		private Collider2DRef _getOtherCollider;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactPoint2D, _getOtherCollider);
		}
		
		public override void Execute()
		{
			_getOtherCollider.Value = _contactPoint2D.Value.otherCollider;
		}
		
		public override string GetSummary()
		{
			return "Get {_contactPoint2D} otherCollider -> {_getOtherCollider}";
		}
	}
}
