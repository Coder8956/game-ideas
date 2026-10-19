
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("Returns the force that the Rigidbody has accumulated before the simulation step.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody.GetAccumulatedForce.html")]
	public sealed class RigidbodyGetAccumulatedForce__Step : BaseAction
	{
		
		[Tooltip("The Rigidbody.")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("The timestep of the next physics simulation.")]
		[SerializeField]
		private FloatVar _step;
		
		[Tooltip("Store the result in Vector3 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _step, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Rigidbody.GetAccumulatedForce(System.Single);
			_result.Value = _rigidbody.Value.GetAccumulatedForce(_step.Value);
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody} accumulated force {_step} -> {_result}";
		}
	}
}
