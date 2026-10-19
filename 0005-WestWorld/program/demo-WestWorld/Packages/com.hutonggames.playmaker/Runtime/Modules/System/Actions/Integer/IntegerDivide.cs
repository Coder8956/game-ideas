using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Integer)]
    [ConvertibleGroup("IntegerMath")]
    [ActionDescription("Divide an Integer.")]
    public class IntegerDivide : BaseAction
    {
        [ActionTarget]
        [Tooltip("The integer to divide.")]
        [SerializeField, WriteOnly]
        private IntegerRef _integer;

        [Tooltip("Divide by this number.")]
        [SerializeField]
        private IntegerVar _divide;

        public override bool CanExecute() => CheckParameters(_integer, _divide);

        public override void Execute() => _integer.Value /= _divide.Value;

        public override string GetSummary() => "Divide {_integer} by {_divide}";
    }
}