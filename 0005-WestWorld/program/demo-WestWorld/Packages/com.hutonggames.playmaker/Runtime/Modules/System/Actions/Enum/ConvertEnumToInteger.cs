using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Convert)]
    [ActionDescription("Convert an enum value to an integer.")]
    public class ConvertEnumToInteger : BaseAction
    {
        [ActionTarget]
        [Tooltip("The Enum Variable.")]
        [SerializeField]
        private EnumRef _enum;
        
        [Tooltip("Store the integer value of the enum.")]
        [SerializeField, WriteOnly]
        private IntegerRef _integer;
        
        public override bool CanExecute() => CheckParameters(_enum, _integer);

        public override void Execute() => _integer.Value = Convert.ToInt32((Enum) _enum.GetValue());

        public override string GetSummary() => "Convert {_enum} to int -> {_integer}";
    }
}