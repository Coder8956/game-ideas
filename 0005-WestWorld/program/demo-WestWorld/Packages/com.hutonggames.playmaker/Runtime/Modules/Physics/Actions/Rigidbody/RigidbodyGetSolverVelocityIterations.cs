
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
	public sealed class RigidbodyGetSolverVelocityIterations : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Get Rigidbody Solver Velocity Iterations")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getSolverVelocityIterations;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _getSolverVelocityIterations);
		}
		
		public override void Execute()
		{
			_getSolverVelocityIterations.Value = _rigidbody.Value.solverVelocityIterations;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody} solver velocity iterations -> {_getSolverVelocityIterations}";
		}
	}
}
