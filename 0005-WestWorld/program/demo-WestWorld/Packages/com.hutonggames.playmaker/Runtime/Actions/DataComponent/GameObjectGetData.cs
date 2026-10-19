using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.GameObjectData)]
    [ConvertibleGroup("GameObjectData")]
    [ActionDescription("Get data values from a Data Component on a GameObject.")]
    [HelpURL("actions/data-actions/game-object/game-object-get-data/")]
    public sealed class GameObjectGetData : BaseAction
    {
        [Tooltip("The GameObject to read the Data Component from.")]
        public GameObjectVar GameObject;

        [RequiredField]
        [Tooltip("The DataDefinition to look for.\n" +
                 "Used to find a matching Data Component.")]
        public DataDefinition DataDefinition;

        [Tooltip("If no matching Data Component is found, " +
                 "store the DataDefinition's default values into outputs instead.")]
        public BoolVar StoreDefaultsIfMissing;
        
        [Tooltip("Get values from the Data Component. " +
                 "These fields are built to match the DataDefinition.")]
        public List<DataFieldStore> GetValues = new();

        [ActionHeader("Events")]

        [OptionalField]
        [Tooltip("Event to send if the GameObject, DataDefinition, or matching Data Component was not found.")]
        public EventRef NotFoundEvent;

        [ActionHeader("Output")]

        [OptionalField, WriteOnly]
        [Tooltip("True if defaults were used because a matching Data Component was missing.")]
        public BoolRef UsedDefaults;

        [OptionalField, WriteOnly]
        [Tooltip("True if values were read (from component or defaults) and outputs were applied.")]
        public BoolRef Succeeded;

        public override void Execute()
        {
            if (Succeeded.IsAssigned) Succeeded.Value = false;
            if (UsedDefaults.IsAssigned) UsedDefaults.Value = false;

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

            DataRow row = null;

            if (component != null)
            {
                var record = component.Data;
                if (record == null)
                {
                    SendEvent(NotFoundEvent);
                    return;
                }

                // Runtime safety: ensure it still matches
                if (record.DataDefinition != def)
                {
                    SendEvent(NotFoundEvent);
                    return;
                }

                row = record.Data;
                if (row == null)
                {
                    SendEvent(NotFoundEvent);
                    return;
                }
            }
            else
            {
                // Missing component: optionally use defaults
                if (!StoreDefaultsIfMissing.Value)
                {
                    SendEvent(NotFoundEvent);
                    return;
                }

                // Build a temp record row shaped to schema + defaults
                row = BuildDefaultsRow(def);
                if (row == null)
                {
                    SendEvent(NotFoundEvent);
                    return;
                }

                if (UsedDefaults.IsAssigned) UsedDefaults.Value = true;
            }

            if (GetValues is { Count: > 0 })
                DataRowUtility.ApplyStores(row, GetValues);
            
            if (Succeeded.IsAssigned) Succeeded.Value = true;
        }
        
        private static DataRow BuildDefaultsRow(DataDefinition def)
        {
            // Uses your existing runtime APIs (ApplySchema + defaults)
            var record = new DataRecord { DataDefinition = def };
            record.ApplySchema(def);

            // If you have defaults separate from ApplySchema, keep this call.
            // Otherwise you can delete this line if ApplySchema already creates default cell values.
            record.ResetToDefaults(def);

            return record.Data;
        }
        
        public override string GetSummary()
        {
            var summary = "Get {GameObject} data {DataDefinition} ";

            if (GetValues != null)
            {
                foreach (var getValue in GetValues)
                    summary += getValue.GetSummary();
            }

            summary += " {UsedDefaults:output} {Succeeded:output}";

            return summary;
        }
    }
}
