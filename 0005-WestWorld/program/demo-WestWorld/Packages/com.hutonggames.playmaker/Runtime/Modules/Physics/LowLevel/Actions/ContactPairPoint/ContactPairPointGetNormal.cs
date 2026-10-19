
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactPairPoint)]
	[ActionDescription("Normal of the contact point.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactPairPoint.html")]
	public sealed class ContactPairPointGetNormal : BaseAction
	{
		
		[Tooltip("The ContactPairPoint")]
		[SerializeField]
		private ContactPairPointRef _contactPairPoint;
		
		[Tooltip("Get ContactPairPoint Normal")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getNormal;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactPairPoint, _getNormal);
		}
		
		public override void Execute()
		{
#if UNITY_6000_0_OR_NEWER
			_getNormal.Value = _contactPairPoint.Value.normal;
#else
			_getNormal.Value = _contactPairPoint.Value.Normal;
#endif
		}
		
		public override string GetSummary()
		{
			return "Get {_contactPairPoint} Normal -> {_getNormal}";
		}
	}
}

