using System;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(RectTransformVariable), typeof(Vector3), "anchoredPosition3D")]
    public class RectTransformAnchoredPosition3DVariable : BaseVariableProperty<RectTransform, Vector3>
    {
        public override string PropertyName => "anchoredPosition3D";
        
#if UNITY_EDITOR
        public override string Description => "The RectTransform's anchored position 3D.";
#endif

        private RectTransformVariable RectTransformVariable => TargetAs<RectTransformVariable>();
        public override Vector3 Value
        {
            get => RectTransformVariable?.Value ? RectTransformVariable.Value.anchoredPosition3D : Vector3.zero;
            set
            {
                if (RectTransformVariable?.Value) RectTransformVariable.Value.anchoredPosition3D = value;
            }
        }
    }
}
