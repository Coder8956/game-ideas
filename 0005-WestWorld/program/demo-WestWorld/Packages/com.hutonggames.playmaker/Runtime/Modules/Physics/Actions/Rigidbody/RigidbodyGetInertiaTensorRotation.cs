
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("The rotation of the inertia tensor.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-inertiaTensorRotation.html")]
	public sealed class RigidbodyGetInertiaTensorRotation : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Get Rigidbody Inertia Tensor Rotation")]
		[SerializeField]
		[WriteOnly]
		private QuaternionRef _getInertiaTensorRotation;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _getInertiaTensorRotation);
		}
		
		public override void Execute()
		{
			_getInertiaTensorRotation.Value = _rigidbody.Value.inertiaTensorRotation;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody} inertia tensor rotation -> {_getInertiaTensorRotation}";
		}
	}
}
