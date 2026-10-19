
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
	public sealed class RigidbodySetSolverIterations : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Set Rigidbody Solver Iterations")]
		[SerializeField]
		private IntegerVar _setSolverIterations;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _setSolverIterations);
		}
		
		public override void Execute()
		{
			_rigidbody.Value.solverIterations = _setSolverIterations.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody} solver iterations to {_setSolverIterations}";
		}
	}
}
