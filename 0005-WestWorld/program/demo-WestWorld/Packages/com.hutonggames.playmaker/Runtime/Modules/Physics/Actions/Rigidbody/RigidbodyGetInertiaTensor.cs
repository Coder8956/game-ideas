
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
	public sealed class RigidbodyGetInertiaTensor : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Get Rigidbody Inertia Tensor")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getInertiaTensor;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _getInertiaTensor);
		}
		
		public override void Execute()
		{
			_getInertiaTensor.Value = _rigidbody.Value.inertiaTensor;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody} inertia tensor -> {_getInertiaTensor}";
		}
	}
}
