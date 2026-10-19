using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.ExpressionEvaluator)]
    [ConvertibleGroup("EvaluateExpression")]
    [ActionDescription("Evaluates a mathematical expression and returns an integer result.")]
    public class ExpressionEvaluatorEvaluate__int : BaseExpressionEvaluatorEvaluate
    {
        [Tooltip("Store the result in an integer variable.")]
        [SerializeField, WriteOnly]
        private IntegerRef _result;

        public override bool CanExecute() => _result.IsAssigned && Expression.HasValue();

        public override void Execute()
        {
            try
            {
                // Compile once and validate expression (braces, identifiers, etc.)
                _ = GetCompiledExpression();

                // Evaluate using the cached placeholder resolver + math evaluator.
                _result.Value = TryEvaluate(out double value) ? Mathf.RoundToInt((float)value) : 0;
            }
            catch (Exception e)
            {
                Debug.LogError($"[ExpressionEvaluatorEvaluate__int] Failed to evaluate expression: {e.Message}");
                Succeeded.Value = false;
                _result.Value = 0;
            }
        }

        public override string GetSummary() => "Evaluate {Expression} {_result:output}";
    }
}
