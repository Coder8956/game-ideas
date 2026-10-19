
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("The center of mass relative to the transform\'s origin.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-centerOfMass.html")]
	public sealed class RigidbodySetCenterOfMass : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Set Rigidbody Center Of Mass")]
		[SerializeField]
		private Vector3Var _setCenterOfMass;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _setCenterOfMass);
		}
		
		public override void Execute()
		{
			_rigidbody.Value.centerOfMass = _setCenterOfMass.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody} center of mass to {_setCenterOfMass}";
		}
	}
}
