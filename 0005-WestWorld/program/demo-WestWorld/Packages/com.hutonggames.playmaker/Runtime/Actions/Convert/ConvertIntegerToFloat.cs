using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Convert)]
    [ActionDescription("Convert an Integer to a Float.")]
    public sealed class ConvertIntegerToFloat : BaseAction
    {
        [ActionTarget]
        [Tooltip("The Integer to convert.")]
        [SerializeField]
        private IntegerRef _integer;

        [Tooltip("Store the converted Float value.")]
        [SerializeField, WriteOnly]
        private FloatRef _float;

        public override bool CanExecute() => CheckParameters(_integer, _float);

        public override void Execute()
        {
            _float.Value = _integer.Value;
        }

        public override string GetSummary() => "Convert {_integer} to float -> {_float}";
    }
}
