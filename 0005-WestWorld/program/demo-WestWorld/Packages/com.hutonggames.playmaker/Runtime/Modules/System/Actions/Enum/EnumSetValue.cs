using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Enum)]
    [ActionDescription("Set an Enum variable's value.")]
    public class EnumSetValue : BaseAction
    {
        [DefaultName("Enum")]
        [WriteOnly, ActionTarget]
        [Tooltip("The Variable to set.")]
        public EnumRef Variable;
        
        [MatchType(nameof(Variable))]
        [Tooltip("Set the Variable to this Value.")]
        [SerializeField]
        public EnumVar Value;
        
        public override bool CanExecute() => CheckParameters(Variable, Value);

        public override void Execute() => Variable.Value = Value.Value;

        public override string GetSummary() => "Set {Variable} to {Value}";
    }
}
