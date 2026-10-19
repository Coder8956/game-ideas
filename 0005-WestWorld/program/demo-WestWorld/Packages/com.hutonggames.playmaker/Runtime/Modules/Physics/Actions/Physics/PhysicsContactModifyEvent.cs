/* Too advanced?
 
using JetBrains.Annotations;
using System;
using Unity.Collections;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.CollisionEvents)]
	[ActionDescription("Subscribe to this event to be able to customize the collision response for contac" +
		"t pairs.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics-ContactModifyEvent.html")]
	public sealed class PhysicsContactModifyEvent : BaseOnEventAction
	{
		
		[Tooltip("Subscribe to this event to be able to customize the collision response for contact pairs.")]
		[SerializeField]
		private EventRef _contactModifyEvent;
		
		public override void OnStart()
		{
			Physics.ContactModifyEvent += OnContactModifyEvent;
		}
		
		public override void OnStop()
		{
			Physics.ContactModifyEvent -= OnContactModifyEvent;
		}
		
		private void OnContactModifyEvent(PhysicsScene arg1, NativeArray<ModifiableContactPair> arg2)
		{
			SendEvent(_contactModifyEvent);
		}
	}
}
*/
