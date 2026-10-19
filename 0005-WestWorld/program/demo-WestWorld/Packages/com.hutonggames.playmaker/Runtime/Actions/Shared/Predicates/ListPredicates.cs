
using System;
using System.Collections;

namespace HutongGames.PlayMaker
{
    [Serializable]
    public abstract class BaseListPredicate : BasePredicate<IList>
    {
        public override bool Evaluate(object parameter) => DoEvaluate(parameter as IList);
    }
    
    [Serializable]
    public abstract class BaseListIntegerPredicate : BaseListPredicate
    {
        public IntegerVar Parameter;
        
        public override string ToString() => $"{GetName()} {Parameter}";
    }
    
    [Serializable, DisplayName("Count Equals")]
    public class ListCountEqualsPredicate : BaseListIntegerPredicate
    {
        protected override bool DoEvaluate(IList list) => list.Count > Parameter.Value;
    }
    
    [Serializable, DisplayName("Count Greater Than")]
    public class ListCountGreaterThanPredicate : BaseListIntegerPredicate
    {
        protected override bool DoEvaluate(IList list) => list.Count > Parameter.Value;
    }
    
    [Serializable, DisplayName("Count Less Than")]
    public class ListCountLessThanPredicate : BaseListIntegerPredicate
    {
        protected override bool DoEvaluate(IList list) => list.Count < Parameter.Value;
    }
}
