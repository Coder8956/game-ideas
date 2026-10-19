
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ConvertibleGroup("Vector2Operator")]
	[ActionDescription("Vector2 operations: Add, Subtract, Multiply, Divide, Min, Max")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector2.html")]
	public sealed class Vector2Operator : BaseAction
	{
		public enum Operation
		{
			Add,
			Subtract,
			Multiply,
			Divide,
			Min,
			Max,
			DotProduct,
			Distance,
			Angle,
		}
		
		[Tooltip("The first Vector2")]
		[SerializeField]
		private Vector2Var _vectorA;
		
		[Tooltip("The second Vector2")]
		[SerializeField]
		private Vector2Var _vectorB;
		
		[Tooltip("The operation to perform.")]
		[SerializeField]
		private Operation _operation;

		[HideIf("IsFloatResult")]
		[Tooltip("Store the result of the operation.")]
		[SerializeField, WriteOnly]
		private Vector2Ref _result;
		
		[HideIf("IsVector2Result")]
		[Tooltip("Store the result of the operation.")]
		[SerializeField, WriteOnly]
		private FloatRef _floatResult;
			
		private bool IsFloatResult => _operation is Operation.DotProduct or Operation.Distance or Operation.Angle;
		
		private bool IsVector2Result => !IsFloatResult;
		
		public override bool CanExecute() => CheckParameters(_vectorA, _vectorB);

		public override void Execute()
		{
			var v1 = _vectorA.Value;
			var v2 = _vectorB.Value;

			if (IsVector2Result)
			{
				CalculateVector2Result(v1, v2);
			}
			else
			{
				CalculateFloatResult(v1, v2);
			}
		}

		private void CalculateVector2Result(Vector2 v1, Vector2 v2)
		{
			_result.Value = _operation switch
			{
				Operation.Add => v1 + v2,
				Operation.Subtract => v1 - v2,
				Operation.Multiply => v1 * v2,
				Operation.Divide => v1 / v2,
				Operation.Min => Vector2.Min(v1, v2),
				Operation.Max => Vector2.Max(v1, v2),
				_ => _result.Value
			};
		}
		
		private void CalculateFloatResult(Vector2 v1, Vector2 v2)
		{
			_floatResult.Value = _operation switch
			{
				Operation.DotProduct => Vector2.Dot(v1, v2),
				Operation.Distance => Vector2.Distance(v1, v2),
				Operation.Angle => Vector2.Angle(v1, v2),
				_ => _floatResult.Value
			};
		}

		public override string GetSummary() => IsVector2Result ? GetVector2ResultSummary() : GetFloatResultSummary();

		private string GetFloatResultSummary() => " {_operation} {_vectorA} {_vectorB} -> {_floatResult}";
		
		private string GetVector2ResultSummary() =>
			_operation is Operation.Min or Operation.Max 
				? "{_operation} {_vectorA} {_vectorB} -> {_result}" 
				: "{_vectorA} {_operation} {_vectorB} -> {_result}";
	}
}
