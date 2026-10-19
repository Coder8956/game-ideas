using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Loop)]
    [ActionDescription("Loop actions the specified number of times.")]
    public class Loop : BaseForEachAction
    {
        [DefaultValue(3)]
        [Tooltip("How many times to loop.")]
        public IntegerVar Count;

        protected override int ItemCount => Count.Value;
        
        public override void EachAction(int index)
        {
        }

        public override string GetSummary() => "Loop {Count} times";

        /* TODO: Add this to base class?
        public override string ErrorCheck()
        {
            if (Count.IsVariable) return "";
            if (Count.Value > Fsm.LoopCountLimit)
                return "Loop count is greater than the Loop Count Limit for this FSM. " +
                       "\nIncrease the limit in the FSM Inspector";
            return "";
        }*/
    }
}