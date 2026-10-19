using System;
using Object = UnityEngine.Object;

namespace HutongGames.PlayMaker
{
    [Serializable, DisplayName("Equal To")]
    public class ObjectEqualsPredicate : BasePredicate<Object>
    {
        public ObjectVar Parameter;
        
        protected override bool DoEvaluate(Object obj) => obj == Parameter.Value;

        public override string ToString() => $"Equals {Parameter}";
    }
    
    [Serializable, DisplayName("Not Equal To")]
    public class ObjectNotEqualsPredicate : BasePredicate<Object>
    {
        public ObjectVar Parameter;
        
        protected override bool DoEvaluate(Object obj) => obj != Parameter.Value;
        
        public override string ToString() => $"Not Equal To {Parameter}";
    }
    
    [Serializable, DisplayName("Is Not Null")]
    public class ObjectIsNotNullPredicate : BasePredicate<Object>
    {
        protected override bool DoEvaluate(Object obj) => obj != null;
    }
    
    [Serializable, DisplayName("Is Null")]
    public class ObjectIsNullPredicate : BasePredicate<Object>
    {
        protected override bool DoEvaluate(Object obj) => obj == null;
    }
    
    [Serializable]
    public abstract class ObjectStringPredicate : BasePredicate<Object>
    {
        public StringVar Parameter;

        public override string ToString()
        {
            return GetName() + " " + Parameter;
        }
    }
    
    [Serializable, DisplayName("Name Contains")]
    public class ObjectNameContainsPredicate : ObjectStringPredicate
    {
        protected override bool DoEvaluate(Object obj) => obj != null && obj.name.Contains(Parameter.Value, StringComparison.Ordinal);
    }
    
    [Serializable, DisplayName("Name Ends With")]
    public class ObjectNameEndsWithPredicate : ObjectStringPredicate
    {
        protected override bool DoEvaluate(Object obj) => obj != null && obj.name.EndsWith(Parameter.Value);
    }
    
    [Serializable, DisplayName("Name Is")]
    public class ObjectNameEqualsPredicate : ObjectStringPredicate
    {
        protected override bool DoEvaluate(Object obj) => obj != null && obj.name == Parameter.Value;
    }
    
    [Serializable, DisplayName("Name Is Not")]
    public class ObjectNameNotEqualsPredicate : ObjectStringPredicate
    {
        protected override bool DoEvaluate(Object obj) => obj != null && obj.name != Parameter.Value;
    }
    
    [Serializable, DisplayName("Name Starts With")]
    public class ObjectNameStartsWithPredicate : ObjectStringPredicate
    {
        protected override bool DoEvaluate(Object obj) => obj != null && obj.name.StartsWith(Parameter.Value);
    }
}