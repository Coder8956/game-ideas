using System;
using HutongGames.PlayMaker.UI;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.DataRecord)]
    [ActionDescription("Updates a Data Item UI component with values from a DataRecord.")]
    [HelpURL("actions/data-actions/data-record/data-record-update-ui/")]
    public class DataRecordUpdateUI : BaseAction
    {
        [Tooltip("The DataRecord to read from.")]
        public DataRecordVar Record;

        [Tooltip("The DataItemUI component to update. " +
                 "The component maps data fields to UI controls.")]
        public DataItemUIVar DataItemUI;

        public override bool CanExecute() => CheckParameters(Record, DataItemUI);

        public override void Execute()
        {
            var record = Record.Value;
            if (record == null) return;
            
            var dataItemUI = DataItemUI.Value;
            if (dataItemUI == null) return;
            
            dataItemUI.Bind(record);
            dataItemUI.Apply();
        }

        public override string GetSummary()
        {
            return "Update {DataItemUI} with {Record}";
        }
    }
}