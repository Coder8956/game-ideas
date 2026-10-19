
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
	public sealed class RigidbodyGetMaxAngularVelocity : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Get Rigidbody Max Angular Velocity")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getMaxAngularVelocity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _getMaxAngularVelocity);
		}
		
		public override void Execute()
		{
			_getMaxAngularVelocity.Value = _rigidbody.Value.maxAngularVelocity;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody} max angular velocity -> {_getMaxAngularVelocity}";
		}
	}
}
