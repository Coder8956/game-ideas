using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.DataRecord)]
    [ConvertibleGroup("CheckDataRecord")]
    [ActionDescription("Check if a DataRecord still has its DataDefinition's default values.")]
    [HelpURL("actions/data-actions/data-record/data-record-check-has-default-values/")]
    public sealed class DataRecordCheckHasDefaultValues : BaseTrueFalseAction
    {
        [Tooltip("The DataRecord to check.")]
        public DataRecordRef Record;

        protected override string TrueSummary => "{Record} has default values";
        protected override string FalseSummary => "{Record} does not have default values";

        public override bool CanExecute() => CheckParameters(Record);

        protected override bool Test()
        {
            var record = Record.Value;
            if (record == null)
                return false;

            var definition = record.DataDefinition;
            var row = record.Data;

            if (definition == null || row == null)
                return false;

            foreach (var definitionVariable in definition.Variables.GetVariables())
            {
                if (definitionVariable is not BaseVariable definitionBase)
                    continue;

                var fieldGuid = definitionBase.Guid;
                if (fieldGuid == SerializableGuid.None)
                    continue;

                var cell = record.FindCell(fieldGuid);
                var value = cell?.Value;

                if (value == null)
                    return false;

                if (value.DataType != definitionVariable.DataType || value.SubType != definitionVariable.SubType)
                    return false;

                if (!Equals(value.GetValue(), definitionVariable.GetValue()))
                    return false;
            }

            return true;
        }
    }
}
