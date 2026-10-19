using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Float)]
    [ConvertibleGroup("FloatOp")]
    [ActionDescription("Add multiple float values to a float variable.")]
    public class FloatAddMultiple : BaseAction
    {
        [ActionTarget, WriteOnly]
        [Tooltip("The float to add to.")]
        public FloatRef Float;
        
        [ArrayElementLabel("Float")]
        [ArrayElementTooltip("A float value to add." + Strings.PerSecondNote)]
        [Tooltip("The values to add.")]
        public List<FloatVar> Add;

        public override bool CanUsePerSecond => true;
        
        public override bool CanExecute() => Float.IsAssigned && Add.Count > 0;

        public override void Execute()
        {
            foreach (var floatVar in Add)
            {
                Float.Value += floatVar.Value * PerSecond;
            }
        }
        
        public override string GetSummary() => "Add {Add} to {Float} {PerSecond}";
    }
}