
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactPoint2D)]
	[ActionDescription("The point of contact between the two colliders in world space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactPoint2D-point.html")]
	public sealed class ContactPoint2DGetPoint : BaseAction
	{
		
		[Tooltip("The ContactPoint2D")]
		[SerializeField]
		private ContactPoint2DRef _contactPoint2D;
		
		[Tooltip("Get ContactPoint2D Point")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getPoint;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactPoint2D, _getPoint);
		}
		
		public override void Execute()
		{
			_getPoint.Value = _contactPoint2D.Value.point;
		}
		
		public override string GetSummary()
		{
			return "Get {_contactPoint2D} point -> {_getPoint}";
		}
	}
}
