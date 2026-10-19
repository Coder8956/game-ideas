using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Integer)]
    [ConvertibleGroup("IntegerMath")]
    [ActionDescription("Performs math operations on 2 Integers: Add, Subtract, Multiply, Divide, Min, Max.")]
    public class IntegerOperator : BaseAction
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
        private IntegerVar _integer1;

        [Tooltip("The second float.")]
        [SerializeField]
        private IntegerVar _integer2;

        [Tooltip("The math operation to perform on the floats.")]
        [SerializeField]
        private Operation _operation;
        
        [Tooltip("Store the result.")]
        [SerializeField]
        [WriteOnly]
        private IntegerRef _result;

        public override bool CanExecute() => CheckParameters(_integer1, _integer2, _result);

        public override void Execute()
        {
            var v1 = _integer1.Value;
            var v2 = _integer2.Value;

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
                Operation.Add => "{_result} = {_integer1} + {_integer2}",
                Operation.Subtract => "{_result} = {_integer1} - {_integer2}",
                Operation.Multiply => "{_result} = {_integer1} * {_integer2}",
                Operation.Divide => "{_result} = {_integer1} / {_integer2}",
                Operation.Modulus => "{_result} = {_integer1} % {_integer2}",
                Operation.Min or Operation.Max => "{_result} = {_operation} ({_integer1}, {_integer2})",
                _ => "{_result} = {_integer1} {_operation} {_integer2}"
            };
    }
}
