using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Convert)]
    [ActionDescription("Convert an Integer to a Bool. 0 = false, any non-zero value = true.")]
    public sealed class ConvertIntegerToBool : BaseAction
    {
        [ActionTarget]
        [Tooltip("The Integer to convert.")]
        [SerializeField]
        private IntegerRef _integer;

        [Tooltip("Store the converted Bool value.")]
        [SerializeField, WriteOnly]
        private BoolRef _bool;

        public override bool CanExecute() => CheckParameters(_integer, _bool);

        public override void Execute()
        {
            _bool.Value = _integer.Value != 0;
        }

        public override string GetSummary() => "Convert {_integer} to bool -> {_bool}";
    }
}