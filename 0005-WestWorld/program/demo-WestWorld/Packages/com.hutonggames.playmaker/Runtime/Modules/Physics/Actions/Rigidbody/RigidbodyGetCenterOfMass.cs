
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("The center of mass relative to the transform\'s origin.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-centerOfMass.html")]
	public sealed class RigidbodyGetCenterOfMass : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Get Rigidbody Center Of Mass")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getCenterOfMass;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _getCenterOfMass);
		}
		
		public override void Execute()
		{
			_getCenterOfMass.Value = _rigidbody.Value.centerOfMass;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody} center of mass -> {_getCenterOfMass}";
		}
	}
}
