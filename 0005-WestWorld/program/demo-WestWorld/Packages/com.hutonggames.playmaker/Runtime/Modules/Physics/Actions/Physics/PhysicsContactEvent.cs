
using JetBrains.Annotations;
using Unity.Collections;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CollisionEvents)]
	[ActionDescription("Read all collisions that occurred during the physics simulation step.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics.ContactEvent.html")]
	public sealed class PhysicsContactEvent : BaseOnEventAction
	{
		[OptionalField]
		[Tooltip("Read all collisions that occurred during the physics simulation step.")]
		[SerializeField]
		private ContactPairHeaderListRef _storeContactInfo;
		
		[OptionalField]
		[Tooltip("Send this event after storing the contact info.")]
		[SerializeField]
		private EventRef _contactEvent;
		
		public override void OnStart()
		{
			Physics.ContactEvent += OnContactEvent;
		}
		
		public override void OnStop()
		{
			Physics.ContactEvent -= OnContactEvent;
		}
		
		private void OnContactEvent(PhysicsScene scene, NativeArray<ContactPairHeader>.ReadOnly headerArray)
		{
			_storeContactInfo.Values = headerArray.ToArray();
			SendEvent(_contactEvent);
		}
	}
}

