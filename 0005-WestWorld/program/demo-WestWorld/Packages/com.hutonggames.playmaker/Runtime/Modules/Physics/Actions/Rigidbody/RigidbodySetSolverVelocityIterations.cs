
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("The solverVelocityIterations affects how how accurately Rigidbody joints and coll" +
		"ision contacts are resolved. Overrides Physics.defaultSolverVelocityIterations. " +
		"Must be positive.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-solverVelocityIterations.html")]
	public sealed class RigidbodySetSolverVelocityIterations : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Set Rigidbody Solver Velocity Iterations")]
		[SerializeField]
		private IntegerVar _setSolverVelocityIterations;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _setSolverVelocityIterations);
		}
		
		public override void Execute()
		{
			_rigidbody.Value.solverVelocityIterations = _setSolverVelocityIterations.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody} solver velocity iterations to {_setSolverVelocityIterations}";
		}
	}
}
