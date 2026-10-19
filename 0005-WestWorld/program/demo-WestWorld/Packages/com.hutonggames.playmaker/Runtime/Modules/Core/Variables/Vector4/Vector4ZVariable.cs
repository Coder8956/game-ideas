using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(Vector4Variable), typeof(float), "z")]
    public class Vector4ZVariable : BaseVariableProperty<Vector4, float>
    {
        public override string PropertyName => "z";
        
#if UNITY_EDITOR
        public override string Description => "The z value of a Vector4 variable.";
#endif

        private Vector4Variable Vector4Variable => TargetAs<Vector4Variable>();
        public override float Value
        {
            get => Vector4Variable?.Value.z ?? 0;
            set
            {
                if (Vector4Variable == null) return;
                var vector4 = Vector4Variable.Value;
                vector4.z = value;
                Vector4Variable.Value = vector4;
            }
        }
    }
}
