/* Too specific (LoopSkipCheck instead - check variable value)
using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Loop)]
    [ConvertibleGroup("LoopControl")]
    [ActionDescription("Skips the rest of this loop iteration based on the value of a bool variable " +
                       "and starts the next iteration of the loop. " +
                       "\n\nSame as Continue in traditional programming.")]
    [HelpURL("actions/loop-actions/loop-skip/")]
    public class LoopSkipIfObjectEquals : BaseAction
    {
        public override bool SkipsLoop => true;

        [Tooltip("The Object variable to check.")]
        [SerializeField]
        public ObjectRef Object;
        
        [Tooltip("The Object to compare with.")]
        public ObjectVar ObjectToCompare;

        [BoolVarDropdown]
        [Tooltip("Test to apply.")]
        [SerializeField, DefaultValue(true)]
        private BoolVar _testIf;
        
        public override bool CanExecute() => CheckParameters(Object, ObjectToCompare, _testIf);
        
        public override void Execute()
        {
            var equals = ObjectToCompare.Value == Object.Value;
            if (equals == _testIf.Value)
            {
                CancelAndContinueLoop();
            }
        }
        public override string GetSummary()
        {
            if (_testIf.IsVariable) return "Skip loop if {Object} and {ObjectToCompare} equality matches {_testIf}";
            if (_testIf.Value) return "Skip loop if {Object} equals {ObjectToCompare}";
            return "Skip loop if {Object} does not equal {ObjectToCompare}";
        }
    }
}*/