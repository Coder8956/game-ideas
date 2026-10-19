
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Angular velocity in degrees per second.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-angularVelocity.html")]
	public sealed class Rigidbody2DSetAngularVelocity : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Set Rigidbody2D Angular Velocity")]
		[SerializeField]
		private FloatVar _setAngularVelocity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _setAngularVelocity);
		}
		
		public override void Execute()
		{
			_rigidbody2D.Value.angularVelocity = _setAngularVelocity.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody2D} angular velocity to {_setAngularVelocity}";
		}
	}
}
