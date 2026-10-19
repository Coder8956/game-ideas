using System;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.UI
{
    [Serializable]
    public sealed class SliderTarget : IDataFieldTarget
    {
        [SerializeField] private Slider _slider;

        public void Apply(IVariableVar value, DataDefinition def, SerializableGuid guid)
        {
            if (_slider == null) return;
            if (value == null || value.IsNone) return;

            var raw = value.GetValue();
            if (raw is float f) _slider.value = f;
            else if (raw is int i) _slider.value = i;
        }
    }
}