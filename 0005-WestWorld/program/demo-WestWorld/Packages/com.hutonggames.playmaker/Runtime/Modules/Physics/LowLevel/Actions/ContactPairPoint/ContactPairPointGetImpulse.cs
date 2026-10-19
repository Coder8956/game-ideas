
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactPairPoint)]
	[ActionDescription("The impulse applied to this contact pair to resolve the collision.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactPairPoint.html")]
	public sealed class ContactPairPointGetImpulse : BaseAction
	{
		
		[Tooltip("The ContactPairPoint")]
		[SerializeField]
		private ContactPairPointRef _contactPairPoint;
		
		[Tooltip("Get ContactPairPoint Impulse")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getImpulse;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactPairPoint, _getImpulse);
		}
		
		public override void Execute()
		{
#if UNITY_6000_0_OR_NEWER
			_getImpulse.Value = _contactPairPoint.Value.impulse;
#else
			_getImpulse.Value = _contactPairPoint.Value.Impulse;
#endif
		}
		
		public override string GetSummary()
		{
			return "Get {_contactPairPoint} Impulse -> {_getImpulse}";
		}
	}
}

