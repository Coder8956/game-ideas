
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactPoint2D)]
	[ActionDescription("Surface normal at the contact point.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactPoint2D-normal.html")]
	public sealed class ContactPoint2DGetNormal : BaseAction
	{
		
		[Tooltip("The ContactPoint2D")]
		[SerializeField]
		private ContactPoint2DRef _contactPoint2D;
		
		[Tooltip("Get ContactPoint2D Normal")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getNormal;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactPoint2D, _getNormal);
		}
		
		public override void Execute()
		{
			_getNormal.Value = _contactPoint2D.Value.normal;
		}
		
		public override string GetSummary()
		{
			return "Get {_contactPoint2D} normal -> {_getNormal}";
		}
	}
}
