
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactPoint2D)]
	[ActionDescription("The other Rigidbody2D involved in the collision with the rigidbody.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactPoint2D-otherRigidbody.html")]
	public sealed class ContactPoint2DGetOtherRigidbody : BaseAction
	{
		
		[Tooltip("The ContactPoint2D")]
		[SerializeField]
		private ContactPoint2DRef _contactPoint2D;
		
		[Tooltip("Get ContactPoint2D Other Rigidbody")]
		[SerializeField]
		[WriteOnly]
		private Rigidbody2DRef _getOtherRigidbody;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactPoint2D, _getOtherRigidbody);
		}
		
		public override void Execute()
		{
			_getOtherRigidbody.Value = _contactPoint2D.Value.otherRigidbody;
		}
		
		public override string GetSummary()
		{
			return "Get {_contactPoint2D} otherRigidbody -> {_getOtherRigidbody}";
		}
	}
}
