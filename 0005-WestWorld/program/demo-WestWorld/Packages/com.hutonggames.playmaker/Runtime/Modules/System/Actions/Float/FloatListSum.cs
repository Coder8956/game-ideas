using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Float)]
    [ActionDescription("Get the sum total of a list of floats.")]
    public class FloatListSum : BaseAction
    {
        [ActionTarget, WriteOnly]
        [Tooltip("The float list")]
        public FloatListRef FloatList;

        [Tooltip("Store the sum in a float variable.")]
        public FloatRef Sum;
        
        public override bool CanExecute() => CheckParameters(FloatList, Sum);

        public override void Execute() => Sum.Value = FloatList.Value.Sum();

        public override string GetSummary() => "Sum {FloatList} -> {Sum}";
    }
}