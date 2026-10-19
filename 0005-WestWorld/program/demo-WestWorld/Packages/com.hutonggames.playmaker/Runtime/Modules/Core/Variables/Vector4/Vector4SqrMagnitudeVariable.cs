using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(Vector4Variable), typeof(float), "sqrMagnitude", false)]
    public class Vector4SqrMagnitudeVariable : BaseVariableProperty<Vector4, float>
    {
        public override string PropertyName => "sqrMagnitude";
        
#if UNITY_EDITOR
        public override string Description => "The squared magnitude of a Vector4 variable.";
#endif

        public override float Value
        {
            get => (TargetAs<Vector4Variable>()?.Value ?? default).sqrMagnitude;
            set { }
        }
    }
}
