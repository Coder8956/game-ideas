using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(Vector3Variable), typeof(float), "magnitude", false)]
    public class Vector3MagnitudeVariable : BaseVariableProperty<Vector3, float>
    {
        public override string PropertyName => "magnitude";
        
#if UNITY_EDITOR
        public override string Description => "The magnitude of a Vector3 variable.";
#endif

        public override float Value
        {
            get => (TargetAs<Vector3Variable>()?.Value ?? default).magnitude;
            set { }
        }
    }
}
