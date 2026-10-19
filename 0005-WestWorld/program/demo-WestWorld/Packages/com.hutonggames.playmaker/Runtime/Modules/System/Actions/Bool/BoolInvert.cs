using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Bool)]
    [ActionDescription("Invert a Bool variable's value.")]
    public class BoolInvert : BaseAction
    {
        [WriteOnly, ActionTarget]
        [Tooltip("The Variable to set.")]
        public BoolRef Variable;
        
        public override bool CanExecute() => CheckParameters(Variable);

        public override void Execute() => Variable.Value = !Variable.Value;

        public override string GetSummary() => "Invert {Variable}";
    }
}