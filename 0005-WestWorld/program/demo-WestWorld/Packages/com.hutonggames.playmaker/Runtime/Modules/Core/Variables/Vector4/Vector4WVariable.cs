using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(Vector4Variable), typeof(float), "w")]
    public class Vector4WVariable : BaseVariableProperty<Vector4, float>
    {
        public override string PropertyName => "w";
        
#if UNITY_EDITOR
        public override string Description => "The w value of a Vector4 variable.";
#endif

        private Vector4Variable Vector4Variable => TargetAs<Vector4Variable>();
        public override float Value
        {
            get => Vector4Variable?.Value.w ?? 0;
            set
            {
                if (Vector4Variable == null) return;
                var vector4 = Vector4Variable.Value;
                vector4.w = value;
                Vector4Variable.Value = vector4;
            }
        }
    }
}
