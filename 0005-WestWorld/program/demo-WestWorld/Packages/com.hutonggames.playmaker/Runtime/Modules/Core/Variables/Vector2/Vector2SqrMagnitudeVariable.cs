using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(Vector2Variable), typeof(float), "sqrMagnitude", false)]
    public class Vector2SqrMagnitudeVariable : BaseVariableProperty<Vector2, float>
    {
        public override string PropertyName => "sqrMagnitude";
        
#if UNITY_EDITOR
        public override string Description => "The squared magnitude of a Vector2 variable.";
#endif

        public override float Value
        {
            get => (TargetAs<Vector2Variable>()?.Value ?? default).sqrMagnitude;
            set { }
        }
    }
}
