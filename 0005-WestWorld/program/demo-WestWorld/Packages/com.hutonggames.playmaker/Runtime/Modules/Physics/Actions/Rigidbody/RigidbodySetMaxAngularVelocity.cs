
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("The maximum angular velocity of the rigidbody measured in radians per second. (De" +
		"fault 7) range { 0, infinity }.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-maxAngularVelocity.html")]
	public sealed class RigidbodySetMaxAngularVelocity : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Set Rigidbody Max Angular Velocity")]
		[SerializeField]
		private FloatVar _setMaxAngularVelocity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _setMaxAngularVelocity);
		}
		
		public override void Execute()
		{
			_rigidbody.Value.maxAngularVelocity = _setMaxAngularVelocity.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody} max angular velocity to {_setMaxAngularVelocity}";
		}
	}
}
