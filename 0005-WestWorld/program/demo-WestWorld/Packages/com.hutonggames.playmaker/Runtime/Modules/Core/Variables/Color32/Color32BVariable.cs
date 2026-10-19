using System;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(Color32Variable), typeof(byte), "b")]
    public class Color32BVariable : BaseVariableProperty<Color32, byte>
    {
        public override string PropertyName => "b";
        
#if UNITY_EDITOR
        public override string Description => "The blue value of a Color32 variable.";
#endif

        private Color32Variable Color32Variable => TargetAs<Color32Variable>();
        public override byte Value
        {
            get => Color32Variable?.Value.b ?? 0;
            set
            {
                if (Color32Variable == null) return;
                var color = Color32Variable.Value;
                color.b = value;
                Color32Variable.Value = color;
            }
        }
    }
}
