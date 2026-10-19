
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("The angular velocity vector of the rigidbody measured in radians per second.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-angularVelocity.html")]
	public sealed class RigidbodyGetAngularVelocity : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Get Rigidbody Angular Velocity")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getAngularVelocity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _getAngularVelocity);
		}
		
		public override void Execute()
		{
			_getAngularVelocity.Value = _rigidbody.Value.angularVelocity;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody} angular velocity -> {_getAngularVelocity}";
		}
	}
}
