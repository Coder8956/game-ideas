using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.ExpressionEvaluator)]
    [ConvertibleGroup("EvaluateExpression")]
    [ActionDescription("Evaluates a boolean expression with numeric sub-expressions.\n" +
                       "Supports > < >= <= == != && || and ! with parentheses.")]
    public class EvaluateBooleanExpression : BaseExpressionEvaluatorEvaluate
    {
        [Tooltip("Result of the boolean expression.")]
        [OptionalField]
        [SerializeField, WriteOnly] 
        private BoolRef _result;

        [Tooltip("Event to send if the expression evaluates to true.")]
        [OptionalField]
        [SerializeField]
        private EventRef _trueEvent;

        [Tooltip("Event to send if the expression evaluates to false.")]
        [OptionalField]
        [SerializeField]
        private EventRef _falseEvent;

        public override bool CanExecute() => Expression.HasValue();

        public override void Execute()
        {
            try
            {
                // Optional: compile once to validate braces early (keeps UX consistent with your numeric actions)
                _ = GetCompiledExpression();

                var isTrue = BoolExpression.EvaluateWithPlaceholders(
                    Expression.Value,
                    ResolveNumeric,                         // numeric resolver from your base
                    ident => {                        // string resolver (StringVariable)
                        var v = Fsm.Variables.FindVariableByName(ident);
                        return v is StringVariable sv ? sv.Value : null;
                    },
                    stringEqualsIgnoreCase: true);
                
                Succeeded.Value = true;
                if (_result.IsAssigned)
                {
                    _result.Value = isTrue;
                }
                SendEvent(isTrue ? _trueEvent : _falseEvent);
            }
            catch (Exception e)
            {
                Debug.LogError($"[EvaluateBooleanExpression] Failed to evaluate: {e.Message}");
                Succeeded.Value = false;
                if (_result.IsAssigned)
                {
                    _result.Value = false;
                }
            }
        }

        public override string ErrorCheck() => !_result.IsAssigned && !_trueEvent.IsSet && !_falseEvent.IsSet
            ? "Action does not send any events or store the result!"
            : null;

        public override string GetSummary() => "Evaluate {Expression} {_result:output} {_trueEvent:True} {_falseEvent:False}";
    }
}
