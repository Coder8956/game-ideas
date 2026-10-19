
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Float)]
    [ActionDescription("Set a Float variable's value.")]
    [MovedFrom(false,null,null, "SetFloatValue")]
    public class FloatSetValue : BaseAction
    {
        [DefaultName("Float")]
        [WriteOnly, ActionTarget]
        [Tooltip("The Variable to set.")]
        public FloatRef Variable;
        
        [Tooltip("Set the Variable to this Value.")]
        public FloatVar Value;
        
        public override bool CanExecute() => CheckParameters(Variable, Value);

        public override void Execute() => Variable.Value = Value.Value;

        public override string GetSummary() => "Set {Variable} to {Value}";
    }
}
