
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactPoint)]
	[ActionDescription("The point of contact.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactPoint-point.html")]
	public sealed class ContactPointGetPoint : BaseAction
	{
		
		[Tooltip("The ContactPoint")]
		[SerializeField]
		private ContactPointRef _contactPoint;
		
		[Tooltip("Get ContactPoint Point")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getPoint;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactPoint, _getPoint);
		}
		
		public override void Execute()
		{
			_getPoint.Value = _contactPoint.Value.point;
		}
		
		public override string GetSummary()
		{
			return "Get {_contactPoint} point -> {_getPoint}";
		}
	}
}
