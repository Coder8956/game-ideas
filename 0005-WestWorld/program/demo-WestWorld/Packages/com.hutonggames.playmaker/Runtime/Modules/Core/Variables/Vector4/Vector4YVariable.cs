using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(Vector4Variable), typeof(float), "y")]
    public class Vector4YVariable : BaseVariableProperty<Vector4, float>
    {
        public override string PropertyName => "y";
        
#if UNITY_EDITOR
        public override string Description => "The y value of a Vector4 variable.";
#endif

        private Vector4Variable Vector4Variable => TargetAs<Vector4Variable>();
        public override float Value
        {
            get => Vector4Variable?.Value.y ?? 0;
            set
            {
                if (Vector4Variable == null) return;
                var vector4 = Vector4Variable.Value;
                vector4.y = value;
                Vector4Variable.Value = vector4;
            }
        }
    }
}
