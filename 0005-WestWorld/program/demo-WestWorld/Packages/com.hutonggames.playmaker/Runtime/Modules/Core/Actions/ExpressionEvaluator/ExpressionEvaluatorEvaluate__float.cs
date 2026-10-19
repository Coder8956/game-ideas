using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.ExpressionEvaluator)]
    [ConvertibleGroup("EvaluateExpression")]
    [ActionDescription("Evaluates a mathematical expression and returns a float result.")]
    public class ExpressionEvaluatorEvaluate__float : BaseExpressionEvaluatorEvaluate
    {
        [Tooltip("Store the result in a float variable.")]
        [SerializeField, WriteOnly]
        private FloatRef _result;

        public override bool CanExecute() => _result.IsAssigned && Expression.HasValue();

        public override void Execute()
        {
            try
            {
                // Compile once and validate braces / identifiers
                _ = GetCompiledExpression();

                // Evaluate using the cached placeholder resolver + math evaluator.
                _result.Value = TryEvaluate(out double value) ? (float)value : 0f;
            }
            catch (Exception e)
            {
                Debug.LogError($"[ExpressionEvaluatorEvaluate__float] Failed to evaluate expression: {e.Message}");
                Succeeded.Value = false;
                _result.Value = 0f;
            }
        }

        public override string GetSummary() => "Evaluate {Expression} {_result:output}";
    }
}
