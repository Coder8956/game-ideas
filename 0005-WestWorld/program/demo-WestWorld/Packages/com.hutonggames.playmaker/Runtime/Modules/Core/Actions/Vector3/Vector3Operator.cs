
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ConvertibleGroup("Vector3Operator")]
	[ActionDescription("Vector3 operations:\n\n" +
	                   "CrossProduct, DotProduct, Angle, Project, Reflect, Add, Subtract, Distance, Min, Max, Divide, and Multiply")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3.html")]
	public sealed class Vector3Operator : BaseAction
	{
		public enum Operation
		{
			CrossProduct,
			Project,
			Reflect,
			Add,
			Subtract,
			Min,
			Max,
			DotProduct,
			Angle,
			Scale,
			Distance,
			Divide,
			Multiply
		}
		
		[Tooltip("The first Vector3")]
		[SerializeField]
		private Vector3Var _vectorA;
		
		[HideIf("IsFloatOperand")]
		[Tooltip("The second Vector3")]
		[SerializeField]
		private Vector3Var _vectorB;

		[HideIf("IsVector3Operand")]
		[Tooltip("The float operand")]
		[SerializeField, DefaultValue(1f)]
		private FloatVar _float;
		
		[Tooltip("The operation to perform.")]
		[SerializeField]
		private Operation _operation;

		[HideIf("IsFloatResult")]
		[Tooltip("Store the result of the operation.")]
		[SerializeField, WriteOnly]
		private Vector3Ref _result;

		[HideIf("IsVector3Result")]
		[Tooltip("Store the result of the operation.")]
		[SerializeField, WriteOnly]
		private FloatRef _floatResult;
			
		private bool IsFloatOperand => _operation is Operation.Divide or Operation.Multiply;
		
		private bool IsVector3Operand => !IsFloatOperand;
		
		private bool IsFloatResult => _operation is Operation.DotProduct or Operation.Distance or Operation.Angle;
		
		private bool IsVector3Result => !IsFloatResult;
		
		public override bool CanExecute() => CheckParameters(_vectorA, _vectorB);

		public override void Execute()
		{
			var v1 = _vectorA.Value;
			var v2 = _vectorB.Value;
			var f = _float.Value;

			if (IsVector3Result)
			{
				CalculateVector3Result(v1, v2, f);
			}
			else
			{
				CalculateFloatResult(v1, v2);
			}
		}
		
		private void CalculateVector3Result(Vector3 v1, Vector3 v2, float f)
		{
			_result.Value = _operation switch
			{
				Operation.CrossProduct => Vector3.Cross(v1, v2),
				Operation.Project => Vector3.Project(v1, v2),
				Operation.Reflect => Vector3.Reflect(v1, v2),
				Operation.Add => v1 + v2,
				Operation.Subtract => v1 - v2,
				Operation.Scale => Vector3.Scale(v1, v2),
				Operation.Min => Vector3.Min(v1, v2),
				Operation.Max => Vector3.Max(v1, v2),
				Operation.Divide => v1/f,
				Operation.Multiply => v1*f,
				_ => _result.Value
			};
		}
		
		private void CalculateFloatResult(Vector3 v1, Vector3 v2)
		{
			_floatResult.Value = _operation switch
			{
				Operation.DotProduct => Vector3.Dot(v1, v2),
				Operation.Distance => Vector3.Distance(v1, v2),
				Operation.Angle => Vector3.Angle(v1, v2),
				_ => _floatResult.Value
			};
		}

		public override string GetSummary() => IsVector3Result ? GetVector3ResultSummary() : GetFloatResultSummary();
		
		private string GetVector3ResultSummary() =>
			_operation switch
			{
				Operation.Add or Operation.Subtract => "{_vectorA} {_operation} {_vectorB} -> {_result}",
				Operation.Multiply or Operation.Divide => "{_vectorA} {_operation} {_float} -> {_result}",
				_ => "{_operation} {_vectorA} {_vectorB} -> {_result}"
			};

		private string GetFloatResultSummary() => "{_operation} {_vectorA} {_vectorB} -> {_floatResult}";
	}
}
