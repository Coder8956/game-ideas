
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("The solverIterations determines how accurately Rigidbody joints and collision con" +
		"tacts are resolved. Overrides Physics.defaultSolverIterations. Must be positive." +
		"")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-solverIterations.html")]
	public sealed class RigidbodyGetSolverIterations : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Get Rigidbody Solver Iterations")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getSolverIterations;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _getSolverIterations);
		}
		
		public override void Execute()
		{
			_getSolverIterations.Value = _rigidbody.Value.solverIterations;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody} solver iterations -> {_getSolverIterations}";
		}
	}
}
