using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using HutongGames.PlayMaker.Actions;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.Editor
{
    [UsedImplicitly]
    [CustomActionEditor(typeof(DataTableTrimRandom))]
    public sealed class DataTableTrimRandomEditor : BaseDataTableWithOverrideEditor<DataTableTrimRandom>
    {
        private readonly List<DataSchemaUtility.SchemaField> _numericFields = new();

        protected override void BuildAfterContentGUI()
        {
            AddField(nameof(DataTableTrimRandom.MaxRows));
            AddField(nameof(DataTableTrimRandom.RemovedCount));
            AddField(nameof(DataTableTrimRandom.Trimmed));
        }

        protected override void BuildTableUI(DataDefinition definition)
        {
            BuildNumericFields(definition);

            var choices = new List<string>(_numericFields.Count + 1) { "<None>" };
            for (var i = 0; i < _numericFields.Count; i++)
                choices.Add(_numericFields[i].Name);

            var currentIndex = FindCurrentIndex();
            var dropdown = new PopupField<string>("Weight Field", choices, currentIndex);
            dropdown.AddToClassList("hutong-field");
            dropdown.tooltip = GetTooltip(currentIndex);
            ContentRoot.Add(dropdown);

            if (_numericFields.Count == 0)
            {
                var noFieldsHelp = new HelpBox(
                    "The selected DataDefinition has no int, float, or double fields for weights.",
                    HelpBoxMessageType.Info);
                ContentRoot.Add(noFieldsHelp);
            }

            dropdown.RegisterValueChangedCallback(_ =>
            {
                var selectedIndex = dropdown.index;
                var serializedObject = TargetProperty.serializedObject;
                serializedObject.Update();

                var guidProp = TargetProperty.FindPropertyRelative(nameof(DataTableTrimRandom.WeightFieldGuid));
                if (guidProp == null)
                    return;

                guidProp.boxedValue = selectedIndex <= 0
                    ? SerializableGuid.None
                    : SerializableGuid.FromParts(_numericFields[selectedIndex - 1].GuidA, _numericFields[selectedIndex - 1].GuidB);

                serializedObject.ApplyModifiedProperties();
                dropdown.tooltip = GetTooltip(selectedIndex);
                UpdateErrors();
            });
        }

        private void BuildNumericFields(DataDefinition definition)
        {
            _numericFields.Clear();
            if (definition == null)
                return;

            var fields = new List<DataSchemaUtility.SchemaField>();
            DataSchemaUtility.BuildSchemaFieldsInEditorOrder(definition, fields);

            for (var i = 0; i < fields.Count; i++)
            {
                var field = fields[i];
                if (IsSupportedWeightType(field.DataType))
                    _numericFields.Add(field);
            }
        }

        private int FindCurrentIndex()
        {
            var currentGuid = Action.WeightFieldGuid;
            if (currentGuid == SerializableGuid.None)
                return 0;

            for (var i = 0; i < _numericFields.Count; i++)
            {
                var guid = SerializableGuid.FromParts(_numericFields[i].GuidA, _numericFields[i].GuidB);
                if (guid == currentGuid)
                    return i + 1;
            }

            return 0;
        }

        private string GetTooltip(int index)
        {
            if (index <= 0)
                return "Optional. Leave empty so every row has the same chance to remain after trimming. Select a numeric field to make rows with larger values more likely to remain.";

            var fieldTooltip = _numericFields[index - 1].Tooltip;
            return string.IsNullOrEmpty(fieldTooltip)
                ? "Rows with larger values are more likely to remain after trimming."
                : fieldTooltip + "\n\nRows with larger values are more likely to remain after trimming.";
        }

        private static bool IsSupportedWeightType(Type dataType) =>
            dataType == typeof(int) || dataType == typeof(float) || dataType == typeof(double);
    }
}
