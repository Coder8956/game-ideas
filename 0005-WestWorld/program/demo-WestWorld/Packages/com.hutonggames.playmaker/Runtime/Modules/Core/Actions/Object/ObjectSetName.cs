using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Object)]
    [ActionDescription("Set the name of an Object.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Object-name.html")]
    public class ObjectSetName : BaseAction
    {
        [Tooltip("The Object.")]
        [BaseType(typeof(Object))]
        public ObjectVar Object;
        
        [Tooltip("Set the name." +
                 "\n<b>Tip</b>: Enable Use Variable Tokens to insert values with {VariableName}.")]
        public StringVar Name;

        [Tooltip("Resolve {VariableName} and {VariableName.Property} tokens in the name.")]
        [DefaultValue(false)]
        public BoolVar UseVariableTokens;
        
        public override void Execute()
        {
            if (!RuntimeCheck(Object)) return;
            Object.Value.name = UseVariableTokens.Value
                ? DebugLogTextFormatter.Format(Name.Value, Fsm?.Variables)
                : Name.Value;
        }
        
        public override string GetSummary() => "Set {Object} name to {Name}";
    }
}
