using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(Vector2Variable), typeof(float), "y")]
    public class Vector2YVariable : BaseVariableProperty<Vector2, float>
    {
        public override string PropertyName => "y";
        
#if UNITY_EDITOR
        public override string Description => "The y value of a Vector2 variable.";
#endif
        
        private Vector2Variable Vector2Variable => TargetAs<Vector2Variable>();
        public override float Value
        {
            get => Vector2Variable?.Value.y ?? 0;
            set
            {
                if (Vector2Variable == null) return;
                var vector2 = Vector2Variable.Value;
                vector2.y = value;
                Vector2Variable.Value = vector2;   
            }
        }
    }
}
