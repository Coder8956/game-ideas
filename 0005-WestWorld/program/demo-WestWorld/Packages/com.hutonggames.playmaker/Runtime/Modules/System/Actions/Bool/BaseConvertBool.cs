using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [PublicAPI]
    [ActionCategory(Category.Convert)]
    [ActionDescription("Converts a Bool value into another type, explicitly specifying the true value and the false value.")]
    [System.Serializable]
    public abstract class BaseConvertBool<TVar, TRef> : BaseAction
        where TVar : class, IVariableVar
        where TRef : IVariableRef
    {
        [Tooltip("The bool to convert.")]
        [SerializeField]
        protected BoolRef Bool;
        
        [Tooltip("Value to use if Bool is true.")]
        [SerializeField]
        protected TVar TrueValue;
        
        [SerializeField]
        [Tooltip("Value to use if Bool is false.")]
        protected TVar FalseValue;

        [Tooltip("Store the chosen value.")]
        [SerializeField, WriteOnly]
        protected TRef StoreResult;

        public override bool CanExecute() => CheckParameters(Bool, StoreResult);

        public override void Reset()
        {
            base.Reset();

            // Ensure these exist so derived Reset() can SetValue safely.
            TrueValue ??= VariableFactory.CreateVariableVar(typeof(TVar)) as TVar;
            FalseValue ??= VariableFactory.CreateVariableVar(typeof(TVar)) as TVar;
        }
        
        protected void SetDefaults(object trueValue, object falseValue)
        {
            TrueValue?.SetValue(trueValue);
            FalseValue?.SetValue(falseValue);
        }
        
        public TVar Evaluate => Bool.Value ? TrueValue : FalseValue;

        public override string GetSummary() => "If {Bool} set {StoreResult} to {TrueValue} else {FalseValue}";
    }
}
