using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [DisplayName("Stop Loop")]
    [ActionCategory(Category.Loop)]
    [ConvertibleGroup("LoopControl")]
    [ActionDescription("Stops the loop if a bool value is true. " +
                       "\n\nSame as Break in traditional programming.")]
    public class LoopStop : BaseAction
    {
        public override bool StopsLoop => true;

        [Tooltip("The bool variable to check.")]
        [SerializeField]
        private BoolRef _variable;

        [BoolVarDropdown]
        [Tooltip("Test to apply.")]
        [SerializeField, DefaultValue(true)]
        private BoolVar _testIf;

        public override bool CanExecute() => CheckParameters(_variable, _testIf);

        public override void Execute()
        {
            if (_variable.Value == _testIf.Value)
            {
                BreakLoop();
            }
        }
        public override string GetSummary() => "Stop loop if {_variable} is {_testIf}";
    }
}