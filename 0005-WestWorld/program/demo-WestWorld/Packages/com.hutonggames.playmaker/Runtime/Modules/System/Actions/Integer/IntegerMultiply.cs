using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Integer)]
    [ConvertibleGroup("IntegerMath")]
    [ActionDescription("Multiply an Integer.")]
    public class IntegerMultiply : BaseAction
    {
        [ActionTarget]
        [Tooltip("The integer to multiply.")]
        [SerializeField, WriteOnly]
        private IntegerRef _integer;

        [Tooltip("Multiply by this number.")]
        [SerializeField]
        private IntegerVar _multiply;

        public override bool CanExecute() => CheckParameters(_integer, _multiply);

        public override void Execute() => _integer.Value *= _multiply.Value;

        public override string GetSummary() => "Multiply {_integer} by {_multiply}";
    }
}