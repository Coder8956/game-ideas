using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Integer)]
    [ConvertibleGroup("IntegerMath")]
    [ActionDescription("Add multiple integer values to an integer variable.")]
    public class IntegerAddMultiple : BaseAction
    {
        [ActionTarget, WriteOnly]
        [Tooltip("The integer variable to add to.")]
        public IntegerRef Integer;
        
        [Tooltip("The values to add.")]
        public List<IntegerVar> Add;
        
        public override bool CanExecute()
        {
            return Integer.IsAssigned && Add.Count > 0;
        }

        public override void Execute()
        {
            foreach (var intVar in Add)
            {
                Integer.Value += intVar.Value;
            }
        }
    }
}