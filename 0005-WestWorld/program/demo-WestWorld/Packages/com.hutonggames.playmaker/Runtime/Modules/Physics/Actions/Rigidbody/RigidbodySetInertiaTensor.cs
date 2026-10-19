
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("The inertia tensor of this body, defined as a diagonal matrix in a reference fram" +
		"e positioned at this body\'s center of mass and rotated by Rigidbody.inertiaTenso" +
		"rRotation.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-inertiaTensor.html")]
	public sealed class RigidbodySetInertiaTensor : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Set Rigidbody Inertia Tensor")]
		[SerializeField]
		private Vector3Var _setInertiaTensor;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _setInertiaTensor);
		}
		
		public override void Execute()
		{
			_rigidbody.Value.inertiaTensor = _setInertiaTensor.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody} inertia tensor to {_setInertiaTensor}";
		}
	}
}
