
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactPoint)]
	[ActionDescription("The other collider in contact at the point.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactPoint-otherCollider.html")]
	public sealed class ContactPointGetOtherCollider : BaseAction
	{
		
		[Tooltip("The ContactPoint")]
		[SerializeField]
		private ContactPointRef _contactPoint;
		
		[Tooltip("Get ContactPoint Other Collider")]
		[SerializeField]
		[WriteOnly]
		private ColliderRef _getOtherCollider;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactPoint, _getOtherCollider);
		}
		
		public override void Execute()
		{
			_getOtherCollider.Value = _contactPoint.Value.otherCollider;
		}
		
		public override string GetSummary()
		{
			return "Get {_contactPoint} otherCollider -> {_getOtherCollider}";
		}
	}
}
