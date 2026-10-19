using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.ExpressionEvaluator)]
    [ConvertibleGroup("EvaluateExpression")]
    [ActionDescription("Evaluates a mathematical expression and returns a long result.")]
    public class ExpressionEvaluatorEvaluate__long : BaseExpressionEvaluatorEvaluate
    {
        [Tooltip("Store the result in a long variable.")]
        [SerializeField, WriteOnly]
        private LongRef _result;

        public override bool CanExecute() => _result.IsAssigned && Expression.HasValue();

        public override void Execute()
        {
            try
            {
                // Compile once and validate braces / identifiers.
                _ = GetCompiledExpression();

                // Evaluate using the cached placeholder resolver + math evaluator.
                _result.Value = TryEvaluate(out double value) ? Convert.ToInt64(Math.Round(value)) : 0L;
            }
            catch (Exception e)
            {
                Debug.LogError($"[ExpressionEvaluatorEvaluate__long] Failed to evaluate expression: {e.Message}");
                Succeeded.Value = false;
                _result.Value = 0L;
            }
        }

        public override string GetSummary() => $"Evaluate {Expression} → {_result:output}";
    }
}
