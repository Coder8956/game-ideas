using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(Vector2Variable), typeof(float), "x")]
    public class Vector2XVariable : BaseVariableProperty<Vector2, float>
    {
        public override string PropertyName => "x";
        
#if UNITY_EDITOR
        public override string Description => "The x value of a Vector2 variable.";
#endif
        
        private Vector2Variable Vector2Variable => TargetAs<Vector2Variable>();
        public override float Value
        {
            get => Vector2Variable?.Value.x ?? 0;
            set
            {
                if (Vector2Variable == null) return;
                var vector2 = Vector2Variable.Value;
                vector2.x = value;
                Vector2Variable.Value = vector2;   
            }
        }
    }
}
