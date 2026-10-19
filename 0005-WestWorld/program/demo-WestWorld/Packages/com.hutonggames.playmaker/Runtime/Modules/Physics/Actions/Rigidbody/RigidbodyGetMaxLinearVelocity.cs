
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("The maximum linear velocity of the rigidbody measured in meters per second.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-maxLinearVelocity.html")]
	public sealed class RigidbodyGetMaxLinearVelocity : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Get Rigidbody Max Linear Velocity")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getMaxLinearVelocity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _getMaxLinearVelocity);
		}
		
		public override void Execute()
		{
			_getMaxLinearVelocity.Value = _rigidbody.Value.maxLinearVelocity;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody} max linear velocity -> {_getMaxLinearVelocity}";
		}
	}
}
