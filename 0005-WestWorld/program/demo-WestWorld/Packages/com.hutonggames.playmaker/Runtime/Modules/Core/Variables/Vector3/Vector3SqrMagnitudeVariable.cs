using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(Vector3Variable), typeof(float), "sqrMagnitude", false)]
    public class Vector3SqrMagnitudeVariable : BaseVariableProperty<Vector3, float>
    {
        public override string PropertyName => "sqrMagnitude";
        
#if UNITY_EDITOR
        public override string Description => "The squared magnitude of a Vector3 variable.";
#endif

        public override float Value
        {
            get => (TargetAs<Vector3Variable>()?.Value ?? default).sqrMagnitude;
            set { }
        }
    }
}
