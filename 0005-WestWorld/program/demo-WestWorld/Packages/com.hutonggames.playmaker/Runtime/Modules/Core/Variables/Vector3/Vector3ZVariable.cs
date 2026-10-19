using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(Vector3Variable), typeof(float), "z")]
    public class Vector3ZVariable : BaseVariableProperty<Vector3, float>
    {
        public override string PropertyName => "z";
        
#if UNITY_EDITOR
        public override string Description => "The z value of a Vector3 variable.";
#endif
        
        private Vector3Variable Vector3Variable => TargetAs<Vector3Variable>();
        public override float Value
        {
            get => Vector3Variable?.Value.z ?? 0;
            set
            {
                if (Vector3Variable == null) return;
                var vector3 = Vector3Variable.Value;
                vector3.z = value;
                Vector3Variable.Value = vector3;   
            }
        }
    }
}
