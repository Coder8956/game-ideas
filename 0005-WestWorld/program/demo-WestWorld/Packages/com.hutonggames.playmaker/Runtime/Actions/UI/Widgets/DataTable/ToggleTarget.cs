using System;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.UI
{
    [Serializable]
    public sealed class ToggleTarget : IDataFieldTarget
    {
        [SerializeField] private Toggle _toggle;

        public void Apply(IVariableVar value, DataDefinition def, SerializableGuid guid)
        {
            if (_toggle == null) return;
            if (value == null || value.IsNone) return;

            if (value.GetValue() is bool b)
                _toggle.isOn = b;
        }
    }
}