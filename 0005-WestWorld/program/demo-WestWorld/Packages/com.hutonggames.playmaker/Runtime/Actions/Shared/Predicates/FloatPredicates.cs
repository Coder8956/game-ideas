using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    public abstract class BaseFloatPredicate : BasePredicate<float>
    {
        public FloatVar Parameter;
        
        public override bool Evaluate(object parameter) => DoEvaluate(Convert.ToSingle(parameter));

        public override string ToString() => $"{GetName()} {Parameter}";
    }
    
    [Serializable, DisplayName("Equals")]
    public class FloatEqualPredicate : BaseFloatPredicate
    {
        protected override bool DoEvaluate(float f) => Mathf.Approximately(f, Parameter.Value);
        
        public override string ToString() => "Equals {Parameter}";
    }
    
    [Serializable, DisplayName("Greater Than Or Equal To")]
    public class FloatGreaterThanOrEqualPredicate : BaseFloatPredicate
    {
        protected override bool DoEvaluate(float f) => f >= Parameter.Value;
    }
    
    [Serializable, DisplayName("Greater Than")]
    public class FloatGreaterThanPredicate : BaseFloatPredicate
    {
        protected override bool DoEvaluate(float f) => f > Parameter.Value;
    }
    
    [Serializable, DisplayName("Less Than Or Equal To")]
    public class FloatLessThanOrEqualPredicate : BaseFloatPredicate
    {
        protected override bool DoEvaluate(float f) => f <= Parameter.Value;
    }
    
    [Serializable, DisplayName("Less Than")]
    public class FloatLessThanPredicate : BaseFloatPredicate
    {
        protected override bool DoEvaluate(float f) => f < Parameter.Value;
    }
}