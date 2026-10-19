using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(Vector3Variable), typeof(Vector3), "normalized", false)]
    public class Vector3NormalizedVariable : BaseVariableProperty<Vector3, Vector3>
    {
        public override string PropertyName => "normalized";

#if UNITY_EDITOR
        public override string Description => "A normalized vector with length of 1.";
#endif

        public override Vector3 Value
        {
            get => (TargetAs<Vector3Variable>()?.Value ?? default).normalized;
            set { }
        }
    }
}
