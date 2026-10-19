using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [PublicAPI]
    [ActionDescription("Selects one of two values based on a Bool and stores it in the target variable.")]
    [System.Serializable]
    public abstract class BaseSelectValue<TVar, TRef> : BaseAction
        where TVar : class, IVariableVar
        where TRef : class, IVariableRef
    {
        [DefaultName("Variable")]
        [SerializeField, WriteOnly, ActionTarget]
        [Tooltip("The Variable to set.")]
        protected TRef Variable;

        [Tooltip("Selects which value to use.")]
        [SerializeField]
        protected BoolRef Bool;

        [Tooltip("Value to use if Bool is true.")]
        [SerializeField, CanBeNullOrEmpty]
        protected TVar TrueValue;

        [Tooltip("Value to use if Bool is false.")]
        [SerializeField, CanBeNullOrEmpty]
        protected TVar FalseValue;

        public override bool CanExecute() => CheckParameters(Variable, Bool);

        public override void Reset()
        {
            base.Reset();

            TrueValue ??= VariableFactory.CreateVariableVar(typeof(TVar)) as TVar;
            FalseValue ??= VariableFactory.CreateVariableVar(typeof(TVar)) as TVar;
        }

        protected void SetDefaults(object trueValue, object falseValue)
        {
            TrueValue?.SetValue(trueValue);
            FalseValue?.SetValue(falseValue);
        }

        protected IVariableRef Evaluate => Bool.Value ? TrueValue : FalseValue;

        public override void Execute() => Variable.SetValue(Evaluate.GetValue());

        public override string GetSummary() => "Set {Variable} to {TrueValue} if {Bool} else {FalseValue}";
    }
}
