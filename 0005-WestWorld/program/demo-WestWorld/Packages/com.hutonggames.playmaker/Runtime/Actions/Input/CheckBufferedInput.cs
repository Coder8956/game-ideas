using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.BufferedInput)]
    [ConvertibleGroup("CheckBufferedInput")]
    [ActionDescription("Check if a buffered button press is available (unconsumed and within its buffer window).")]
    [HelpURL("actions/input-actions/buffered-input/")]
    public sealed class CheckBufferedInput : BaseTrueFalseAction
    {
        [Tooltip("The BufferedInput value to check.")]
        public BufferedInputRef BufferedInput;

        [Tooltip("Optional override for the buffer window used for this check. " +
                 "0 = keep original buffer window.")]
        [OptionalField]
        public FloatVar OverrideWindow;
        
        [Tooltip("If true, consume buffered presses when used.")]
        [DefaultValue(true)]
        public BoolVar ConsumeBufferedPress;

        protected override string TrueSummary  => "{BufferedInput} pressed";
        protected override string FalseSummary => "{BufferedInput} not pressed";

        public override bool CanExecute() => CheckParameters(BufferedInput);
        
        #if UNITY_EDITOR
        private bool _used;
        private float _age;
        #endif
        
        protected override bool Test()
        {
            if (BufferedInput.IsNone) return false;

            var value = BufferedInput.Value;
  
            if (!OverrideWindow.IsNone && OverrideWindow.Value > 0f)
            {
                value.BufferWindow = OverrideWindow.Value;
            }

            if (value.IsFresh)
            {
                if (ConsumeBufferedPress.Value)
                {
                    value.Consume();
                    BufferedInput.Value = value;
                }

                #if UNITY_EDITOR
                _used = true;
                _age = value.Age;
                #endif
                
                return true;
            }

            #if UNITY_EDITOR
            _used = false;
            _age = 0;
            #endif
            
            return false;
        }
        
#if UNITY_EDITOR

        public override bool HasDebugInfo => true;

        public override string GetDebugInfo() => $"Used Buffered Input: {_used}  (Age: {_age:F3}s)";

#endif
    }
}