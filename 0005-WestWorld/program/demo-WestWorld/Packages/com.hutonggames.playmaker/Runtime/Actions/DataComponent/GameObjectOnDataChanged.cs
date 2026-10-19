using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.GameObjectData)]
    [ConvertibleGroup("GameObjectData")]
    [ActionDescription("Sends an event when a Data Component on a GameObject changes.")]
    [HelpURL("actions/data-actions/game-object/game-object-on-data-changed/")]
    public sealed class GameObjectOnDataChanged : BaseAction
    {
        [Tooltip("The GameObject that owns the DataRecordComponent.")]
        public GameObjectVar GameObject;
        
        [Tooltip("The DataDefinition used to find a matching DataRecordComponent.")]
        public DataDefinition DataDefinition;

        [ActionHeader("Event")]
        
        [Tooltip("The event to send when the data changes.")]
        public EventRef _SendEvent;

        [ActionHeader("Output")]

        [OptionalField, WriteOnly]
        [Tooltip("True if a matching Data Component was found and hooked.")]
        public BoolRef Found;

        [OptionalField, WriteOnly]
        [Tooltip("The GameObject that changed (the GameObject that was hooked).")]
        public GameObjectRef ChangedGameObject;

        [OptionalField, WriteOnly]
        [Tooltip("The Data Component that changed.")]
        public DataRecordComponentRef ChangedComponent;

        private DataRecordComponent _hookedComponent;
        private DataRecord _hookedRecord;
        private GameObject _hookedGameObject;
        private DataDefinition _hookedDefinition;

        private GameObject _lastGo;
        private DataDefinition _lastDef;

        // Needs per-frame Execute to support variable-driven GameObject/DataDefinition rebinding.
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
        public override UpdateMode RequiredUpdateModes => UpdateMode.UpdateEveryFrame;

        public override void OnStart()
        {
            Rebind(force: true);
        }

        public override void OnStop()
        {
            Unhook();
        }

        public override void Execute()
        {
            Rebind(force: false);
        }

        private void Rebind(bool force)
        {
            var go = GameObject.Value;
            var def = DataDefinition;

            // If inputs haven't changed and we aren't forcing a refresh, do nothing.
            if (!force && go == _lastGo && def == _lastDef)
            {
                if (Found.IsAssigned) Found.Value = (_hookedRecord != null);
                return;
            }

            _lastGo = go;
            _lastDef = def;

            if (Found.IsAssigned) Found.Value = false;

            if (go == null || def == null)
            {
                Unhook();
                return;
            }

            var next = DataRecordComponent.FindMatching(go, def);

            // If the resolved component hasn't changed, we can keep the existing hook.
            if (!force && ReferenceEquals(next, _hookedComponent))
            {
                if (Found.IsAssigned) Found.Value = (_hookedRecord != null);
                return;
            }

            // Swap hook.
            Unhook();

            _hookedComponent = next;
            _hookedGameObject = go;
            _hookedDefinition = def;

            if (_hookedComponent == null)
                return;

            var record = _hookedComponent.Data;

            // Runtime safety: ensure it still matches
            if (record == null || record.DataDefinition != def)
            {
                _hookedComponent = null;
                _hookedRecord = null;
                _hookedGameObject = null;
                _hookedDefinition = null;
                return;
            }

            _hookedRecord = record;
            _hookedRecord.Changed -= OnSourceChanged;
            _hookedRecord.Changed += OnSourceChanged;

            if (Found.IsAssigned) Found.Value = true;

            // Optional: populate outputs immediately on successful hook
            if (ChangedGameObject.IsAssigned) ChangedGameObject.Value = _hookedGameObject;
            if (ChangedComponent.IsAssigned) ChangedComponent.Value = _hookedComponent;
        }

        private void Unhook()
        {
            if (_hookedRecord != null)
                _hookedRecord.Changed -= OnSourceChanged;

            _hookedComponent = null;
            _hookedRecord = null;
            _hookedGameObject = null;
            _hookedDefinition = null;

            if (Found.IsAssigned) Found.Value = false;
        }

        private void OnSourceChanged()
        {
            // Use captured references so outputs are stable even if input vars change later.
            if (ChangedGameObject.IsAssigned) ChangedGameObject.Value = _hookedGameObject;
            if (ChangedComponent.IsAssigned) ChangedComponent.Value = _hookedComponent;

            SendEvent(_SendEvent);
        }

        public override string GetSummary()
        {
            return "On {GameObject} {DataDefinition} changed {_SendEvent}";
        }
    }
}
