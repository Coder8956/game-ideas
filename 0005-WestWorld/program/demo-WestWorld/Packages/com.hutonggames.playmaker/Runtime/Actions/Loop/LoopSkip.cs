using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [DisplayName("Skip Loop")]
    [ActionCategory(Category.Loop)]
    [ConvertibleGroup("LoopControl")]
    [ActionDescription("Skips the rest of this loop iteration based on the value of a bool variable " +
                       "and starts the next iteration of the loop. " +
                       "\n\nSame as Continue in traditional programming.")]
    public class LoopSkip : BaseAction
    {
        public override bool SkipsLoop => true;

        [Tooltip("The bool variable to check.")]
        [SerializeField]
        private BoolRef _variable;

        [FormerlySerializedAs("_testIf")]
        [BoolVarDropdown]
        [Tooltip("Test to apply.")]
        [SerializeField, DefaultValue(true)]
        private BoolVar _skipIf;
        
        public override bool CanExecute() => CheckParameters(_variable, _skipIf);
        
        public override void Execute()
        {
            if (_variable.Value == _skipIf.Value)
            {
                CancelAndContinueLoop();
            }
        }
        public override string GetSummary() => "Skip loop if {_variable} is {_skipIf}";
    }
}