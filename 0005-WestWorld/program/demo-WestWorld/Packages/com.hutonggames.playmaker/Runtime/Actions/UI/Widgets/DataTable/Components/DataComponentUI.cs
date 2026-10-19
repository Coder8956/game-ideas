using System.Collections.Generic;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker.UI
{
    [AddComponentMenu("PlayMaker/Widgets/Data Component UI")]
    [Icon(Strings.EditorIconsPath + "DataRowViewIcon.png")]
    public sealed class DataComponentUI : MonoBehaviour
    {
        [Tooltip("Data Component to bind to the UI.")]
        [SerializeField] private DataRecordComponent _dataComponent;
        
        [Tooltip("Fallback Data Definition used to configure bindings when the source component is not known at edit time.")]
        [SerializeField] private DataDefinition _definition;
        
        [Tooltip("UI field bindings that map Data Definition fields to UI targets.")]
        [SerializeField] private DataUIBindings _ui = new();

        [Tooltip("Refresh bindings when this component is enabled.")]
        [SerializeField] private bool _refreshOnEnable = true;
        
        [Tooltip("Refresh bindings automatically when the source data changes.")]
        [SerializeField] private bool _refreshOnChanged = true;

        private readonly Dictionary<SerializableGuid, IVariableVar> _cellByGuid = new();

        public DataRecordComponent Source => _dataComponent;
        public DataDefinition Definition => _definition;
        public DataUIBindings UI => _ui;

        private void Reset()
        {
            AutoAssignSourceIfMissing();
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            AutoAssignSourceIfMissing();
        }
#endif

        private void Awake()
        {
            AutoAssignSourceIfMissing();
        }

        private void OnEnable()
        {
            AutoAssignSourceIfMissing();
            HookSource();

            if (_refreshOnEnable)
                Refresh();
        }

        private void OnDisable()
        {
            UnhookSource();
        }

        private void OnDestroy()
        {
            UnhookSource();
        }

        private void AutoAssignSourceIfMissing()
        {
            if (_dataComponent != null)
                return;

            _dataComponent = GetComponent<DataRecordComponent>();
        }

        private void HookSource()
        {
            if (!_refreshOnChanged) return;
            if (_dataComponent == null) return;

            _dataComponent.Data.Changed -= OnSourceChanged;
            _dataComponent.Data.Changed += OnSourceChanged;
        }

        private void UnhookSource()
        {
            if (_dataComponent == null) return;
            _dataComponent.Data.Changed -= OnSourceChanged;
        }

        private void OnSourceChanged()
        {
            Refresh();
        }

        public void Refresh()
        {
            var record = _dataComponent != null ? _dataComponent.Data : null;
            var def = record?.DataDefinition ?? _definition;

            DataFieldBindingUtility.BuildLookup(record?.Data?.Cells, _cellByGuid);
            DataFieldBindingUtility.ApplyBindings(_ui.Bindings, _cellByGuid, def);
        }
    }
}
