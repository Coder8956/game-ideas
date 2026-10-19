using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(Vector4Variable), typeof(float), "magnitude", false)]
    public class Vector4MagnitudeVariable : BaseVariableProperty<Vector4, float>
    {
        public override string PropertyName => "magnitude";
        
#if UNITY_EDITOR
        public override string Description => "The magnitude of a Vector4 variable.";
#endif

        public override float Value
        {
            get => (TargetAs<Vector4Variable>()?.Value ?? default).magnitude;
            set { }
        }
    }
}
