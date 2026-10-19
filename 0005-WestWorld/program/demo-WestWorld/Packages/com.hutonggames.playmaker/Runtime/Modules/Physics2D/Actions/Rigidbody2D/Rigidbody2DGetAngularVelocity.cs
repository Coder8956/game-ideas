
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
	public sealed class Rigidbody2DGetAngularVelocity : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Get Rigidbody2D Angular Velocity")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getAngularVelocity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _getAngularVelocity);
		}
		
		public override void Execute()
		{
			_getAngularVelocity.Value = _rigidbody2D.Value.angularVelocity;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody2D} angular velocity -> {_getAngularVelocity}";
		}
	}
}
