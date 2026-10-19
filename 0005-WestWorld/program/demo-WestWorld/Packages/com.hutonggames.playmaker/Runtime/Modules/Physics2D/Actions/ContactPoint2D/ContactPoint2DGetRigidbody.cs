
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactPoint2D)]
	[ActionDescription("The incoming Rigidbody2D involved in the collision with the otherRigidbody.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactPoint2D-rigidbody.html")]
	public sealed class ContactPoint2DGetRigidbody : BaseAction
	{
		
		[Tooltip("The ContactPoint2D")]
		[SerializeField]
		private ContactPoint2DRef _contactPoint2D;
		
		[Tooltip("Get ContactPoint2D Rigidbody")]
		[SerializeField]
		[WriteOnly]
		private Rigidbody2DRef _getRigidbody;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactPoint2D, _getRigidbody);
		}
		
		public override void Execute()
		{
			_getRigidbody.Value = _contactPoint2D.Value.rigidbody;
		}
		
		public override string GetSummary()
		{
			return "Get {_contactPoint2D} rigidbody -> {_getRigidbody}";
		}
	}
}
