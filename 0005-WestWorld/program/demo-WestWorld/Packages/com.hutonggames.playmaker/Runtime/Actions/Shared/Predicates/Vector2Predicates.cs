using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    public abstract class BaseVector2FloatPredicate : BasePredicate<Vector2>
    {
        public FloatVar Parameter;
    }
    
    [Serializable, DisplayName("Equal To")]
    public class Vector2EqualsPredicate : BasePredicate<Vector2>
    {
        public Vector2Var Parameter;
        protected override bool DoEvaluate(Vector2 v2) => v2 == Parameter.Value;

        public override string ToString() => $"{GetName()} {Parameter}";
    }
    
    [Serializable, DisplayName("Magnitude Equal To")]
    public class Vector2MagnitudeEqualsPredicate : BaseVector2FloatPredicate
    {
        protected override bool DoEvaluate(Vector2 v2) => Mathf.Approximately(v2.magnitude, Parameter.Value);
    }
    
    [Serializable, DisplayName("Magnitude Less Than")]
    public class Vector2MagnitudeLessThanPredicate : BaseVector2FloatPredicate
    {
        protected override bool DoEvaluate(Vector2 v2) => v2.magnitude < Parameter.Value;
    }
    
    [Serializable, DisplayName("Magnitude Greater Than")]
    public class Vector2MagnitudeGreaterThanPredicate : BaseVector2FloatPredicate
    {
        protected override bool DoEvaluate(Vector2 v2) => v2.magnitude > Parameter.Value;
    }
    
    [Serializable, DisplayName("X Equal To")]
    public class Vector2XEqualsPredicate : BaseVector2FloatPredicate
    {
        protected override bool DoEvaluate(Vector2 v2) => Mathf.Approximately(v2.x, Parameter.Value);
    }
    
    [Serializable, DisplayName("X Greater Than")]
    public class Vector2XGreaterThanPredicate : BaseVector2FloatPredicate
    {
        protected override bool DoEvaluate(Vector2 v2) => v2.x > Parameter.Value;
    }
    
    [Serializable, DisplayName("X Less Than")]
    public class Vector2XLessThanPredicate : BaseVector2FloatPredicate
    {
        protected override bool DoEvaluate(Vector2 v2) => v2.x < Parameter.Value;
    }
    
    [Serializable, DisplayName("Y Equal To")]
    public class Vector2YEqualsPredicate : BaseVector2FloatPredicate
    {
        protected override bool DoEvaluate(Vector2 v2) => Mathf.Approximately(v2.y, Parameter.Value);
    }
    
    [Serializable, DisplayName("Y Greater Than")]
    public class Vector2YGreaterThanPredicate : BaseVector2FloatPredicate
    {
        protected override bool DoEvaluate(Vector2 v2) => v2.y > Parameter.Value;
    }
    
    [Serializable, DisplayName("Y Less Than")]
    public class Vector2YLessThanPredicate : BaseVector2FloatPredicate
    {
        protected override bool DoEvaluate(Vector2 v2) => v2.y < Parameter.Value;
    }
}