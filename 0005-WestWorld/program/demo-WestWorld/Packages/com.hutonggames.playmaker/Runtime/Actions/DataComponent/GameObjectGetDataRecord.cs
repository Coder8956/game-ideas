using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.GameObjectData)]
    [ConvertibleGroup("GameObjectData")]
    [ActionDescription("Get data from a Data Component on a GameObject and store it in a Data Record variable.")]
    [HelpURL("actions/data-actions/game-object/game-object-get-data-record/")]
    public class GameObjectGetDataRecord : BaseAction, IDataDefinitionSource
    {
        [Tooltip("The GameObject.")]
        public GameObjectVar GameObject;

        [OptionalField]
        [Tooltip("Optional DataDefinition to filter by. Useful if the GameObject has multiple Data Components.")]
        public DataDefinition DataDefinition;

        [ActionHeader("Output")]
        
        [WriteOnly, DefaultName("Data")]
        [Tooltip("Store a copy of the data in a DataRecord variable. " +
                 "Use a DataRecordGetValues action to get all the values in the record.")]
        public DataRecordRef DataRecord;

        [OptionalField, WriteOnly]
        [Tooltip("Was the data found?")]
        public BoolRef Succeeded;

        [ActionHeader("Events")]
        [OptionalField]
        [Tooltip("Event to send if the GameObject, Data Component, or record was not found.")]
        public EventRef NotFoundEvent;

        public override void Execute()
        {
            if (Succeeded.IsAssigned) Succeeded.Value = false;

            var go = GameObject.Value;
            if (go == null)
            {
                SendEvent(NotFoundEvent);
                return;
            }

            var dataComponent = GetDataComponent(go);
            if (dataComponent == null)
            {
                SendEvent(NotFoundEvent);
                return;
            }

            var source = dataComponent.Data;
            if (source == null)
            {
                SendEvent(NotFoundEvent);
                return;
            }

            // If DataDefinition filter is specified, double-check (covers cases where Data changes at runtime).
            if (DataDefinition != null && source.DataDefinition != DataDefinition)
            {
                SendEvent(NotFoundEvent);
                return;
            }

            // If output isn't wired, this can still be used as an "exists" check.
            if (DataRecord != null && DataRecord.IsAssigned)
            {
                var target = DataRecord.Value;
                if (target == null)
                {
                    target = new DataRecord();
                    DataRecord.Value = target;
                }

                var def = source.DataDefinition;
                if (def != null)
                {
                    target.DataDefinition = def;
                    target.ApplySchema(def);
                }

                DataRecordCopyUtility.SetValue(target, source);
            }

            if (Succeeded.IsAssigned) Succeeded.Value = true;
        }

        private DataRecordComponent GetDataComponent(GameObject go)
        {
            if (DataDefinition == null)
                return go.GetComponent<DataRecordComponent>();

            // Multiple data components: pick the first matching definition.
            var comps = go.GetComponents<DataRecordComponent>();
            for (int i = 0; i < comps.Length; i++)
            {
                var c = comps[i];
                var d = c != null ? c.Data : null;
                if (d != null && d.DataDefinition == DataDefinition)
                    return c;
            }

            return null;
        }
        
        public override string GetSummary()
        {
            return "Get {DataDefinition} from {GameObject} {DataRecord:output}";
        }

        public DataDefinition GetEditTimeDataDefinition()
        {
            if (DataDefinition != null)
                return DataDefinition;

            var go = GameObject?.Value;
            if (go == null)
                return null;

            var dataComponent = go.GetComponent<DataRecordComponent>();
            return dataComponent?.Data?.DataDefinition;
        }
    }
}
