using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.GameObjectData)]
    [ConvertibleGroup("GameObjectData")]
    [ActionDescription("Add a Data Component for a DataDefinition to a GameObject or get an existing one if it already exists. " +
                       "If you need to set data at the same time, use <b>GameObject Set Data</b> and check 'Add If Missing'")]
    [HelpURL("actions/data-actions/game-object/game-object-add-data/")]
    public sealed class GameObjectAddData : BaseAction
    {
        [Tooltip("The GameObject to add the Data Component to.")]
        public GameObjectVar GameObject;

        [RequiredField]
        [Tooltip("The DataDefinition (schema) for the Data Component. " +
                 "By convention there is only one Data Component with a given DataDefinition on a GameObject.")]
        public DataDefinition DataDefinition;

        [ActionHeader("Output")]
        [OptionalField, WriteOnly]
        [Tooltip("Store the DataRecordComponent that was found or added.")]
        public DataRecordComponentRef Component;

        [OptionalField, WriteOnly]
        [Tooltip("True if a new component was added. False if an existing matching component was used.")]
        public BoolRef Added;

        [OptionalField, WriteOnly]
        [Tooltip("True if the record component exists (found or added).")]
        public BoolRef Succeeded;

        public override void Execute()
        {
            if (Succeeded.IsAssigned) Succeeded.Value = false;
            if (Added.IsAssigned) Added.Value = false;

            var go = GameObject.Value;
            if (go == null) return;

            var def = DataDefinition;
            if (def == null) return;

            var component = DataRecordComponent.FindMatching(go, def);
            var added = false;

            if (component == null)
            {
                component = go.AddComponent<DataRecordComponent>();
                added = true;
            }

            // Ensure record exists + matches schema
            component.Data ??= new DataRecord();
            component.Data.DataDefinition = def;

            // This should apply defaults for missing cells (per your DataTableSchema.CreateCellValue usage).
            component.Data.ApplySchema(def);

            if (Component.IsAssigned) Component.Value = component;
            if (Added.IsAssigned) Added.Value = added;
            if (Succeeded.IsAssigned) Succeeded.Value = true;

            // Optional: comp.NotifyChanged();
        }

        public override string GetSummary()
        {
            return "Add {DataDefinition} to {GameObject}";
        }
    }
}