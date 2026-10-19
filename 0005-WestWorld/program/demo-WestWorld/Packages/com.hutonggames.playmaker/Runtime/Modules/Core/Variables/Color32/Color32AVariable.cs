using System;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(Color32Variable), typeof(byte), "a")]
    public class Color32AVariable : BaseVariableProperty<Color32, byte>
    {
        public override string PropertyName => "a";
        
#if UNITY_EDITOR
        public override string Description => "The alpha value of a Color32 variable.";
#endif

        private Color32Variable Color32Variable => TargetAs<Color32Variable>();
        public override byte Value
        {
            get => Color32Variable?.Value.a ?? 0;
            set
            {
                if (Color32Variable == null) return;
                var color = Color32Variable.Value;
                color.a = value;
                Color32Variable.Value = color;
            }
        }
    }
}
