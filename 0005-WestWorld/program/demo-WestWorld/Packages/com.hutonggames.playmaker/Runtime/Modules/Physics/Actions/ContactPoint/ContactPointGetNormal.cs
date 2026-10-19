
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactPoint)]
	[ActionDescription("Normal of the contact point.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactPoint-normal.html")]
	public sealed class ContactPointGetNormal : BaseAction
	{
		
		[Tooltip("The ContactPoint")]
		[SerializeField]
		private ContactPointRef _contactPoint;
		
		[Tooltip("Get ContactPoint Normal")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getNormal;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactPoint, _getNormal);
		}
		
		public override void Execute()
		{
			_getNormal.Value = _contactPoint.Value.normal;
		}
		
		public override string GetSummary()
		{
			return "Get {_contactPoint} normal -> {_getNormal}";
		}
	}
}
