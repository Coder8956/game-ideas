using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    public abstract class BaseVector3FloatPredicate : BasePredicate<Vector3>
    {
        public FloatVar Parameter;
        
        public override string ToString() => $"{GetName()} {Parameter}";
    }
    
    [Serializable, DisplayName("Equal To")]
    public class Vector3EqualsPredicate : BasePredicate<Vector3>
    {
        public Vector3Var Parameter;
        protected override bool DoEvaluate(Vector3 v3) => v3 == Parameter.Value;
        
        public override string ToString() => $"Equals {Parameter}";
    }
    
    [Serializable, DisplayName("Magnitude Equal To")]
    public class Vector3MagnitudeEqualsPredicate : BaseVector3FloatPredicate
    {
        protected override bool DoEvaluate(Vector3 v3) => Mathf.Approximately(v3.magnitude, Parameter.Value);
    }
    
    [Serializable, DisplayName("Magnitude Less Than")]
    public class Vector3MagnitudeLessThanPredicate : BaseVector3FloatPredicate
    {
        protected override bool DoEvaluate(Vector3 v3) => v3.magnitude < Parameter.Value;
    }
    
    [Serializable, DisplayName("Magnitude Greater Than")]
    public class Vector3MagnitudeGreaterThanPredicate : BaseVector3FloatPredicate
    {
        protected override bool DoEvaluate(Vector3 v3) => v3.magnitude > Parameter.Value;
    }
    
    [Serializable, DisplayName("X Equal To")]
    public class Vector3XEqualsPredicate : BaseVector3FloatPredicate
    {
        protected override bool DoEvaluate(Vector3 v3) => Mathf.Approximately(v3.x, Parameter.Value);
    }
    
    [Serializable, DisplayName("X Greater Than")]
    public class Vector3XGreaterThanPredicate : BaseVector3FloatPredicate
    {
        protected override bool DoEvaluate(Vector3 v3) => v3.x > Parameter.Value;
    }
    
    [Serializable, DisplayName("X Less Than")]
    public class Vector3XLessThanPredicate : BaseVector3FloatPredicate
    {
        protected override bool DoEvaluate(Vector3 v3) => v3.x < Parameter.Value;
    }
    
    [Serializable, DisplayName("Y Equal To")]
    public class Vector3YEqualsPredicate : BaseVector3FloatPredicate
    {
        protected override bool DoEvaluate(Vector3 v3) => Mathf.Approximately(v3.y, Parameter.Value);
    }
    
    [Serializable, DisplayName("Y Greater Than")]
    public class Vector3YGreaterThanPredicate : BaseVector3FloatPredicate
    {
        protected override bool DoEvaluate(Vector3 v3) => v3.y > Parameter.Value;
    }
    
    [Serializable, DisplayName("Y Less Than")]
    public class Vector3YLessThanPredicate : BaseVector3FloatPredicate
    {
        protected override bool DoEvaluate(Vector3 v3) => v3.y < Parameter.Value;
    }
    
    [Serializable, DisplayName("Z Equal To")]
    public class Vector3ZEqualsPredicate : BaseVector3FloatPredicate
    {
        protected override bool DoEvaluate(Vector3 v3) => Mathf.Approximately(v3.z, Parameter.Value);
    }
    
    [Serializable, DisplayName("Z Greater Than")]
    public class Vector3ZGreaterThanPredicate : BaseVector3FloatPredicate
    {
        protected override bool DoEvaluate(Vector3 v3) => v3.z > Parameter.Value;
    }
    
    [Serializable, DisplayName("Z Less Than")]
    public class Vector3ZLessThanPredicate : BaseVector3FloatPredicate
    {
        protected override bool DoEvaluate(Vector3 v3) => v3.z < Parameter.Value;
    }
}