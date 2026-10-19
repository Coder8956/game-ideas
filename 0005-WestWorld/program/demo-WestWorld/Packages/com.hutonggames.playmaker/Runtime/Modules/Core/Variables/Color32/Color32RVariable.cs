using System;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(Color32Variable), typeof(byte), "r")]
    public class Color32RVariable : BaseVariableProperty<Color32, byte>
    {
        public override string PropertyName => "r";
        
#if UNITY_EDITOR
        public override string Description => "The red value of a Color32 variable.";
#endif

        private Color32Variable Color32Variable => TargetAs<Color32Variable>();
        public override byte Value
        {
            get => Color32Variable?.Value.r ?? 0;
            set
            {
                if (Color32Variable == null) return;
                var color = Color32Variable.Value;
                color.r = value;
                Color32Variable.Value = color;
            }
        }
    }
}
