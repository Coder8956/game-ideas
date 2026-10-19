
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactPoint2D)]
	[ActionDescription("Gets the relative velocity of the two colliders at the contact point (Read Only)." +
		"")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactPoint2D-relativeVelocity.html")]
	public sealed class ContactPoint2DGetRelativeVelocity : BaseAction
	{
		
		[Tooltip("The ContactPoint2D")]
		[SerializeField]
		private ContactPoint2DRef _contactPoint2D;
		
		[Tooltip("Get ContactPoint2D Relative Velocity")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getRelativeVelocity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactPoint2D, _getRelativeVelocity);
		}
		
		public override void Execute()
		{
			_getRelativeVelocity.Value = _contactPoint2D.Value.relativeVelocity;
		}
		
		public override string GetSummary()
		{
			return "Get {_contactPoint2D} relativeVelocity -> {_getRelativeVelocity}";
		}
	}
}
