
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactPairPoint)]
	[ActionDescription("The position of the contact point between the Colliders, in world space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactPairPoint.html")]
	public sealed class ContactPairPointGetPosition : BaseAction
	{
		
		[Tooltip("The ContactPairPoint")]
		[SerializeField]
		private ContactPairPointRef _contactPairPoint;
		
		[Tooltip("Get ContactPairPoint Position")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactPairPoint, _getPosition);
		}
		
		public override void Execute()
		{
#if UNITY_6000_0_OR_NEWER
			_getPosition.Value = _contactPairPoint.Value.position;
#else
			_getPosition.Value = _contactPairPoint.Value.Position;
#endif
		}
		
		public override string GetSummary()
		{
			return "Get {_contactPairPoint} Position -> {_getPosition}";
		}
	}
}

