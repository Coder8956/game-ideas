using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.ExpressionEvaluator)]
    [ConvertibleGroup("EvaluateExpression")]
    [ActionDescription("Evaluates a mathematical expression and returns a double result.")]
    public class ExpressionEvaluatorEvaluate__double : BaseExpressionEvaluatorEvaluate
    {
        [Tooltip("Store the result in a double variable.")]
        [SerializeField, WriteOnly]
        private DoubleRef _result;

        public override bool CanExecute() => _result.IsAssigned && Expression.HasValue();

        public override void Execute()
        {
            try
            {
                // Compile (validates braces, caches identifiers)
                var _ = GetCompiledExpression();

                // Evaluate using the cached placeholder resolver + math evaluator.
                _result.Value = TryEvaluate(out double value) ? value : 0.0;
            }
            catch (Exception e)
            {
                Debug.LogError($"[ExpressionEvaluatorEvaluate__double] Failed to evaluate expression: {e.Message}");
                Succeeded.Value = false;
                _result.Value = 0.0;
            }
        }

        public override string GetSummary() => "Evaluate {Expression} {_result:output}";
    }
}
