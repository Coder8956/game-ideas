using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Set a Variable's value." +
                       "\n\nNote, this is a little less performant than type specific Set Value actions. " +
                       "Use those instead when available.")]
    public class SetVariableValue : BaseAction
    {
        [SerializeReference, WriteOnly]
        [BaseType(typeof(object))]
        [Tooltip("The Variable to set.")]
        public AnyVariableRef Variable;

        [SerializeReference]
        [MatchType(nameof(Variable)), CanBeNullOrEmpty]
        [Tooltip("Set the Variable to this Value.")]
        public IVariableVar Value;
        
        public override bool CanExecute() => !Variable.IsNone;

        public override void Execute() => Variable.Variable.SetValue(Value.GetValue());

        public override string GetSummary() => "Set {Variable} to {Value}";
    }
}