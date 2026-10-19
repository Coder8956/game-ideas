using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(Vector2Variable), typeof(Vector2), "normalized", false)]
    public class Vector2NormalizedVariable : BaseVariableProperty<Vector2, Vector2>
    {
        public override string PropertyName => "normalized";

#if UNITY_EDITOR
        public override string Description => "A normalized vector with length of 1.";
#endif

        public override Vector2 Value
        {
            get => (TargetAs<Vector2Variable>()?.Value ?? default).normalized;
            set { }
        }
    }
}
