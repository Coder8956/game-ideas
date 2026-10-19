
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.Quaternion)]
	[ActionDescription("Combines rotations lhs and rhs. " +
	                   "\n\nRotating by the product lhs * rhs is the same as applying the two rotations in sequence: lhs first and then rhs, relative to the reference frame resulting from lhs rotation. " +
	                   "\n\nNote that this means rotations are not commutative, so lhs * rhs does not give the same rotation as rhs * lhs.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Quaternion-operator_multiply.html")]
	public sealed class QuaternionMultiply : BaseAction
	{
		
		[Tooltip("The left hand side of the multiplication.")]
		[SerializeField]
		private QuaternionVar _lhs;
		
		[Tooltip("The right hand side of the multiplication.")]
		[SerializeField]
		private QuaternionVar _rhs;
		
		[Tooltip("Store the combined rotation in a Quaternion variable.")]
		[SerializeField]
		[WriteOnly]
		private QuaternionRef _result;
		
		public override bool CanExecute() => CheckParameters(_lhs, _rhs, _result);

		public override void Execute() => _result.Value = _lhs.Value * _rhs.Value;

		public override string GetSummary() => "{_lhs} * {_rhs} -> {_result}";
	}
}
