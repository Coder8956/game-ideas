
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
	public sealed class RigidbodySetMaxLinearVelocity : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Set Rigidbody Max Linear Velocity")]
		[SerializeField]
		private FloatVar _setMaxLinearVelocity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _setMaxLinearVelocity);
		}
		
		public override void Execute()
		{
			_rigidbody.Value.maxLinearVelocity = _setMaxLinearVelocity.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody} max linear velocity to {_setMaxLinearVelocity}";
		}
	}
}
