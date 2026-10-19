using System;
using System.Collections.Generic;
using HutongGames.PlayMaker.Actions;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace HutongGames.PlayMaker.UI
{
    [AddComponentMenu("PlayMaker/Widgets/Data Item UI")]
    [Icon(Strings.EditorIconsPath + "DataRowViewIcon.png")]
    [HelpURL("https://hutonggames.com/playmaker/docs/guides/ui-widgets/data/data-item-ui/")]
    [MovedFrom(true, "HutongGames.PlayMaker.UI", null, "DataTableRowUI")]
    public sealed class DataItemUI : MonoBehaviour, IDataItemContext
    {
        public GameObject ItemGameObject => gameObject;
        
        [SerializeField] private DataDefinition _definition;
        [SerializeField] private DataUIBindings _ui = new();

        // Runtime caches (no allocations during Apply)
        private readonly Dictionary<SerializableGuid, IVariableVar> _cellByGuid = new();

        private DataDefinition _resolvedDefinition;

        // Context (runtime only)
        [NonSerialized] private SerializableGuid _itemId;
        [NonSerialized] private string _itemKey;
        [NonSerialized] private IDataItemActionHost _host;

        public SerializableGuid ItemId => _itemId;
        public string ItemKey => _itemKey;
        public IDataItemActionHost Host => _host;

        public DataDefinition Definition => _definition;
        public DataUIBindings UI => _ui;

        public void SetContext(IDataItemActionHost host, SerializableGuid itemId, string itemKey)
        {
            _host = host;
            _itemId = itemId;
            _itemKey = itemKey;
        }

        public bool Request(DataUICommand command, int intArg = 0, string stringArg = null, object payload = null, object sender = null)
        {
            if (_host == null)
                return false;

            var req = new DataUIActionRequest(
                itemId: _itemId,
                itemKey: _itemKey,
                command: command,
                sourceIndex: -1,
                intArg: intArg,
                stringArg: stringArg,
                payload: payload,
                sender: sender);

            return _host.TryHandleAction(in req);
        }

        public void Bind(DataDefinition definition, DataRow row)
        {
            _resolvedDefinition = definition ?? _definition;
            BuildLookup(row?.Cells);
        }

        public void Bind(DataRecord record)
        {
            _resolvedDefinition = record?.DataDefinition ?? _definition;
            BuildLookup(record?.Data?.Cells);
        }

        public void BindEmpty(DataDefinition definition = null)
        {
            _resolvedDefinition = definition ?? _definition;
            _cellByGuid.Clear();
        }

        private void BuildLookup(IReadOnlyList<DataRow.Cell> cells)
        {
            DataFieldBindingUtility.BuildLookup(cells, _cellByGuid);
        }

        public void Apply()
        {
            DataFieldBindingUtility.ApplyBindings(_ui.Bindings, _cellByGuid, _resolvedDefinition);
        }
    }
}
