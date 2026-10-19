using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Integer)]
    [ActionDescription("Get the sum total of a list of integers.")]
    public class IntegerListSum : BaseAction
    {
        [ActionTarget, WriteOnly]
        [Tooltip("The integer list")]
        public IntegerListRef IntegerList;

        [Tooltip("Store the sum in an integer variable.")]
        public IntegerRef Sum;
        
        public override bool CanExecute() => CheckParameters(IntegerList, Sum);

        public override void Execute() => Sum.Value = IntegerList.Value.Sum();

        public override string GetSummary() => "Sum {IntegerList} -> {Sum}";
    }
}