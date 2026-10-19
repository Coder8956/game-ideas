
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("The angular velocity vector of the rigidbody measured in radians per second.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-angularVelocity.html")]
	public sealed class RigidbodySetAngularVelocity : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Set Rigidbody Angular Velocity")]
		[SerializeField]
		private Vector3Var _setAngularVelocity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _setAngularVelocity);
		}
		
		public override void Execute()
		{
			_rigidbody.Value.angularVelocity = _setAngularVelocity.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody} angular velocity to {_setAngularVelocity}";
		}
	}
}
