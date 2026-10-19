using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(Vector2Variable), typeof(float), "magnitude", false)]
    public class Vector2MagnitudeVariable : BaseVariableProperty<Vector2, float>
    {
        public override string PropertyName => "magnitude";
        
#if UNITY_EDITOR
        public override string Description => "The magnitude of a Vector2 variable.";
#endif

        public override float Value
        {
            get => (TargetAs<Vector2Variable>()?.Value ?? default).magnitude;
            set { }
        }
    }
}
