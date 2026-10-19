
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("The rotation of the inertia tensor.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-inertiaTensorRotation.html")]
	public sealed class RigidbodySetInertiaTensorRotation : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Set Rigidbody Inertia Tensor Rotation")]
		[SerializeField]
		private QuaternionRef _setInertiaTensorRotation;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _setInertiaTensorRotation);
		}
		
		public override void Execute()
		{
			_rigidbody.Value.inertiaTensorRotation = _setInertiaTensorRotation.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody} inertia tensor rotation to {_setInertiaTensorRotation}";
		}
	}
}
