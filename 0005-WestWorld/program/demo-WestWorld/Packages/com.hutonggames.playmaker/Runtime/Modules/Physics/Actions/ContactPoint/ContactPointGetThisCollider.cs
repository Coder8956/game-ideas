
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactPoint)]
	[ActionDescription("The first collider in contact at the point.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactPoint-thisCollider.html")]
	public sealed class ContactPointGetThisCollider : BaseAction
	{
		
		[Tooltip("The ContactPoint")]
		[SerializeField]
		private ContactPointRef _contactPoint;
		
		[Tooltip("Get ContactPoint This Collider")]
		[SerializeField]
		[WriteOnly]
		private ColliderRef _getThisCollider;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactPoint, _getThisCollider);
		}
		
		public override void Execute()
		{
			_getThisCollider.Value = _contactPoint.Value.thisCollider;
		}
		
		public override string GetSummary()
		{
			return "Get {_contactPoint} thisCollider -> {_getThisCollider}";
		}
	}
}
