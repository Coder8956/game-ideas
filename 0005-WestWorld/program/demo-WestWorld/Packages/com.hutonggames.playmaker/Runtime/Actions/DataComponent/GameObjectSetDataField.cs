using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.GameObjectData)]
    [ConvertibleGroup("GameObjectData")]
    [ActionDescription("Sets a field values in a Data Component on a GameObject. Optionally adds the component if missing.")]
    [HelpURL("actions/data-actions/game-object/game-object-set-data-field/")]
    public sealed class GameObjectSetDataField : BaseAction
    {
        [Tooltip("The GameObject that holds the Data Component.")]
        public GameObjectVar GameObject;
        
        [Tooltip("The DataDefinition (schema) for the Data Component. " +
                 "By convention there is only one Data Component with a given DataDefinition on a GameObject.")]
        public DataDefinition DataDefinition;

        [DefaultValue(true)]
        [Tooltip("Add a Data Component if one doesn't already exist for this DataDefinition.")]
        public BoolVar AddIfMissing;
        
        [Tooltip("Set the field's values in the Data Component. ")]
        public DataFieldValue SetValue = new();

        [ActionHeader("Events")]

        [OptionalField]
        [Tooltip("Event to send if the GameObject, DataDefinition, or matching Data Component was not found.")]
        public EventRef NotFoundEvent;

        [ActionHeader("Output")]

        [OptionalField, WriteOnly]
        [Tooltip("True if a new component was added.")]
        public BoolRef Added;

        [OptionalField, WriteOnly]
        [Tooltip("True if the record was found/added and values were applied.")]
        public BoolRef Succeeded;

        public override void Execute()
        {
            if (Succeeded.IsAssigned) Succeeded.Value = false;
            if (Added.IsAssigned) Added.Value = false;

            var go = GameObject.Value;
            if (go == null)
            {
                SendEvent(NotFoundEvent);
                return;
            }

            var def = DataDefinition;
            if (def == null)
            {
                SendEvent(NotFoundEvent);
                return;
            }

            var component = DataRecordComponent.FindMatching(go, def);

            var added = false;
            if (component == null)
            {
                if (!AddIfMissing.Value)
                {
                    SendEvent(NotFoundEvent);
                    return;
                }

                component = go.AddComponent<DataRecordComponent>();
                component.Data = new DataRecord { DataDefinition = def };
                component.Data.ApplySchema(def);
                added = true;
            }

            var record = component.Data;
            if (record == null)
            {
                record = new DataRecord { DataDefinition = def };
                component.Data = record;
            }

            // Ensure schema (creates missing cells, fixes drift)
            record.DataDefinition = def;
            record.ApplySchema(def);

            // Apply values
            var ok = DataRowUtility.ApplyValue(record, SetValue);
            
            if (Added.IsAssigned) Added.Value = added;
            if (Succeeded.IsAssigned) Succeeded.Value = ok;
        }

        public override string GetSummary() =>
            "Set {GameObject} <b>" +
            SetValue.GetFieldName(DataDefinition) + 
            "</b> to {SetValue.Value}";
    }
}
