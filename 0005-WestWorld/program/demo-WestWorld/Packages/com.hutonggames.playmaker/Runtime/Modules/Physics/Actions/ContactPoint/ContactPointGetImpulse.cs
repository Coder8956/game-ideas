
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactPoint)]
	[ActionDescription("The impulse applied to this contact pair to resolve the collision.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactPoint-impulse.html")]
	public sealed class ContactPointGetImpulse : BaseAction
	{
		
		[Tooltip("The ContactPoint")]
		[SerializeField]
		private ContactPointRef _contactPoint;
		
		[Tooltip("Get ContactPoint Impulse")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getImpulse;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactPoint, _getImpulse);
		}
		
		public override void Execute()
		{
			_getImpulse.Value = _contactPoint.Value.impulse;
		}
		
		public override string GetSummary()
		{
			return "Get {_contactPoint} impulse -> {_getImpulse}";
		}
	}
}
