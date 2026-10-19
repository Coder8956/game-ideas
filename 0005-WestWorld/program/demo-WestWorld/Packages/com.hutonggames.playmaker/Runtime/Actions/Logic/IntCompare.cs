using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.LogicValue)]
    [ActionDescription("Compare an integer variable with another integer.")]
    public class IntCompare : BaseAction
    {
        [ActionTarget]
        [Tooltip("The integer to compare.")]
        public IntegerRef Integer1;

        [Tooltip("The value to compare to.")]
        public IntegerVar Integer2;

        [OptionalField]
        [Tooltip("Event to send if Integer is less than Integer2")]
        public EventRef LessThan;
        
        [OptionalField]
        [Tooltip("Event to send if Integer is equal to Integer2")]
        public EventRef Equal;
        
        [OptionalField]
        [Tooltip("Event to send if Integer is greater than Integer2")]
        public EventRef GreaterThan;
        
        public override bool CanExecute()
        {
            return !Integer1.IsNone && !Integer2.IsNone;
        }

        public override void Execute()
        {
            if (Integer1.Value < Integer2.Value)
            {
                SendEvent(LessThan);
            }
            else if (Integer1.Value == Integer2.Value)
            {
                SendEvent(Equal);
            }
            else
            {
                SendEvent(GreaterThan);
            }
        }
        
#if UNITY_EDITOR
        
        public override string ErrorCheck()
        {
            if (LessThan.IsNone && GreaterThan.IsNone && Equal.IsNone)
                return "Action sends no events!";
            return "";
        }
        
        public override string GetSummary()
        {
            return "Compare {Integer1} to {Integer2}";
        }
        
#endif // UNITY_EDITOR
    }
}