using System;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.UI
{
    [Serializable]
    public sealed class DataUIBindings
    {
        [Tooltip("When enabled, the editor will try to automatically fill missing UI bindings when possible." +
                 "\n\nIt looks for matching components in this prefab (for example Text, Toggle, Slider, Image) " +
                 "whose GameObject names match the Data Definition field names." +
                 "\n\nThis only fills empty bindings and never overwrites anything you set manually. " +
                 "Disable this if you prefer to assign all bindings by hand.")]
        [SerializeField] private bool _autoBind = true;

        [SerializeField] private List<DataFieldBinding> _bindings = new();

        public bool AutoBind => _autoBind;
        public List<DataFieldBinding> Bindings => _bindings;
    }
}