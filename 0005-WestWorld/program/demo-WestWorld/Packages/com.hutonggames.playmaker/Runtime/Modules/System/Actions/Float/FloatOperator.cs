using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Float)]
    [ConvertibleGroup("FloatOp")]
    [ActionDescription("Performs math operations on 2 Floats: Add, Subtract, Multiply, Divide, Min, Max, or Modulus")]
    public class FloatOperator : BaseAction
    {
        public enum Operation
        {
            Add,
            Subtract,
            Multiply,
            Divide,
            Min,
            Max,
            Modulus
        }
        
        [Tooltip("The first float.")]
        [SerializeField]
        private FloatVar _float1;

        [Tooltip("The second float.")]
        [SerializeField]
        private FloatVar _float2;

        [Tooltip("The math operation to perform on the floats.")]
        [SerializeField]
        private Operation _operation;
        
        [Tooltip("Store the result.")]
        [SerializeField]
        [WriteOnly]
        private FloatRef _result;

        public override bool CanExecute() => CheckParameters(_float1, _float2, _result);

        public override void Execute()
        {
            var v1 = _float1.Value;
            var v2 = _float2.Value;

            _result.Value = _operation switch
            {
                Operation.Add => v1 + v2,
                Operation.Subtract => v1 - v2,
                Operation.Multiply => v1 * v2,
                Operation.Divide => v1 / v2,
                Operation.Min => Mathf.Min(v1, v2),
                Operation.Max => Mathf.Max(v1, v2),
                Operation.Modulus => v1 % v2,
                _ => _result.Value
            };
        }

        public override string GetSummary() =>
            _operation switch
            {
                Operation.Add => "{_result} = {_float1} + {_float2}",
                Operation.Subtract => "{_result} = {_float1} - {_float2}",
                Operation.Multiply => "{_result} = {_float1} * {_float2}",
                Operation.Divide => "{_result} = {_float1} / {_float2}",
                Operation.Min or Operation.Max => "{_result} = {_operation} {_float1} {_float2}",
                _ => "{_result} = {_float1} {_operation} {_float2}"
            };
    }
}