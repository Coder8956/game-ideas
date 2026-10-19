using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(Vector4Variable), typeof(Vector4), "normalized", false)]
    public class Vector4NormalizedVariable : BaseVariableProperty<Vector4, Vector4>
    {
        public override string PropertyName => "normalized";
        
#if UNITY_EDITOR
        public override string Description => "A normalized vector with length of 1.";
#endif

        public override Vector4 Value
        {
            get => (TargetAs<Vector4Variable>()?.Value ?? default).normalized;
            set { }
        }
    }
}
