/* Too advanced?
 
using JetBrains.Annotations;
using System;
using Unity.Collections;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.CollisionEvents)]
	[ActionDescription("Subscribe to this event to be able to customize the collision response of CCD gen" +
		"erated contact pairs.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics-ContactModifyEventCCD.html")]
	public sealed class PhysicsContactModifyEventCCD : BaseOnEventAction
	{
		
		[Tooltip("Subscribe to this event to be able to customize the collision response of CCD gen" +
			"erated contact pairs.")]
		[SerializeField]
		private EventRef _contactModifyEventCCD;
		
		public override void OnStart()
		{
			Physics.ContactModifyEventCCD += OnContactModifyEventCCD;
		}
		
		public override void OnStop()
		{
			Physics.ContactModifyEventCCD -= OnContactModifyEventCCD;
		}
		
		private void OnContactModifyEventCCD(PhysicsScene arg1, NativeArray<ModifiableContactPair> arg2)
		{
			SendEvent(_contactModifyEventCCD);
		}
	}
}
*/
