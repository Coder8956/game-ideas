using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [PublicAPI, Serializable]
    [ActionCategory(Category.Bool)]
    [ActionDescription("Performs boolean operations on 2 bool values: AND, NAND, OR, XOR.")]
    public class BoolOperator : BaseAction
    {
        public enum Operation
        {
            // ReSharper disable InconsistentNaming
            AND,
            NAND,
            OR,
            XOR
            // ReSharper restore InconsistentNaming
        }
        
        [Tooltip("The first bool.")]
        [SerializeField]
        private BoolVar _bool1;

        [Tooltip("The second bool.")]
        [SerializeField]
        private BoolVar _bool2;

        [Tooltip("The boolean operation.")]
        [SerializeField]
        private Operation _operation;
        
        [Tooltip("Store the result.")]
        [SerializeField]
        [WriteOnly]
        private BoolRef _result;

        public override bool CanExecute() => CheckParameters(_bool1, _bool2, _result);

        public override void Execute()
        {
            var v1 = _bool1.Value;
            var v2 = _bool2.Value;

            _result.Value = _operation switch
            {
                Operation.AND => v1 && v2,
                Operation.NAND => !(v1 && v2),
                Operation.OR => v1 || v2,
                Operation.XOR => v1 ^ v2,
                _ => _result.Value
            };
        }

        public override string GetSummary() => "{_result} = {_bool1} {_operation} {_bool2}";
    }
}