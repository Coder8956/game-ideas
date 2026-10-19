using System.Collections.Generic;
using HutongGames.PlayMaker.Actions;
using JetBrains.Annotations;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.Editor
{
    [UsedImplicitly]
    [CustomActionEditor(typeof(DataTableSort))]
    public sealed class DataTableSortEditor : BaseDataTableWithOverrideEditor<DataTableSort>
    {
        private readonly List<DataSchemaUtility.SchemaField> _schemaFields = new();

        protected override void BuildAfterContentGUI()
        {
            AddField(nameof(DataTableSort.ThenByDirection));
            AddField(nameof(DataTableSort.Sorted));
        }

        protected override void BuildTableUI(DataDefinition def)
        {
            DataSchemaUtility.BuildSchemaFieldsInEditorOrder(def, _schemaFields);

            if (_schemaFields.Count == 0)
            {
                ContentRoot.Add(new HelpBox("The selected DataDefinition has no fields.", HelpBoxMessageType.Info));
                return;
            }

            var choices = new List<string>(_schemaFields.Count + 1) { "Row Key" };
            for (int i = 0; i < _schemaFields.Count; i++)
                choices.Add(_schemaFields[i].Name);

            BuildSortFieldDropdown(
                label: "Sort By",
                choices: choices,
                guidPropertyName: nameof(DataTableSort.SortFieldGuid),
                currentGuid: Action.SortFieldGuid,
                allowNone: false,
                isSecondary: false);

            var directionProp = TargetProperty.FindPropertyRelative(nameof(DataTableSort.Direction));
            if (directionProp != null)
            {
                var directionField = new PropertyField(directionProp, "Direction");
                directionField.AddToClassList("hutong-field");
                ContentRoot.Add(directionField);
            }

            var secondaryChoices = new List<string>(_schemaFields.Count + 2) { "None", "Row Key" };
            for (int i = 0; i < _schemaFields.Count; i++)
                secondaryChoices.Add(_schemaFields[i].Name);

            BuildSortFieldDropdown(
                label: "Then By",
                choices: secondaryChoices,
                guidPropertyName: nameof(DataTableSort.ThenByFieldGuid),
                currentGuid: Action.ThenByFieldGuid,
                allowNone: true,
                isSecondary: true);
        }

        private void BuildSortFieldDropdown(
            string label,
            List<string> choices,
            string guidPropertyName,
            SerializableGuid currentGuid,
            bool allowNone,
            bool isSecondary)
        {
            var currentIndex = GetCurrentIndex(currentGuid, allowNone);

            var dropdown = new PopupField<string>(label, choices, currentIndex);
            dropdown.AddToClassList("hutong-field");
            dropdown.tooltip = GetTooltip(currentIndex, allowNone, isSecondary);

            ContentRoot.Add(dropdown);

            dropdown.RegisterValueChangedCallback(_ =>
            {
                var idx = dropdown.index;

                var so = TargetProperty.serializedObject;
                so.Update();

                var guidProp = TargetProperty.FindPropertyRelative(guidPropertyName);
                if (guidProp == null) return;

                if (allowNone && idx == 0)
                {
                    guidProp.boxedValue = SerializableGuid.None;
                    so.ApplyModifiedProperties();
                    dropdown.tooltip = GetTooltip(idx, allowNone, isSecondary);
                    UpdateErrors();
                    return;
                }

                var rowKeyIndex = allowNone ? 1 : 0;
                if (idx == rowKeyIndex)
                {
                    guidProp.boxedValue = DataTableUtility.RowKeyGuid;
                    so.ApplyModifiedProperties();
                    dropdown.tooltip = GetTooltip(idx, allowNone, isSecondary);
                    UpdateErrors();
                    return;
                }

                var schemaStartIndex = allowNone ? 2 : 1;
                var schemaIndex = idx - schemaStartIndex;
                if (schemaIndex < 0 || schemaIndex >= _schemaFields.Count)
                    return;

                var sf = _schemaFields[schemaIndex];
                guidProp.boxedValue = SerializableGuid.FromParts(sf.GuidA, sf.GuidB);
                so.ApplyModifiedProperties();

                dropdown.tooltip = GetTooltip(idx, allowNone, isSecondary);
                UpdateErrors();
            });
        }

        private int GetCurrentIndex(SerializableGuid currentGuid, bool allowNone)
        {
            if (allowNone && currentGuid == SerializableGuid.None)
                return 0;

            var rowKeyIndex = allowNone ? 1 : 0;
            var schemaStartIndex = allowNone ? 2 : 1;

            if (currentGuid == DataTableUtility.RowKeyGuid)
                return rowKeyIndex;

            for (int i = 0; i < _schemaFields.Count; i++)
            {
                var sf = _schemaFields[i];
                var guid = SerializableGuid.FromParts(sf.GuidA, sf.GuidB);
                if (guid == currentGuid)
                    return schemaStartIndex + i;
            }

            return rowKeyIndex;
        }

        private string GetTooltip(int index, bool allowNone, bool isSecondary)
        {
            var usage = isSecondary
                ? "Secondary sort key. Used only when two rows are equal on Sort By."
                : "Primary sort key. Rows are sorted by this field first.";

            if (allowNone && index == 0)
                return $"{usage} Leave set to None when you do not need a tie-breaker.";

            var rowKeyIndex = allowNone ? 1 : 0;
            if (index == rowKeyIndex)
                return $"{usage} Sort by the row Key value (not a DataDefinition field).";

            var schemaStartIndex = allowNone ? 2 : 1;
            var schemaIndex = index - schemaStartIndex;
            if (schemaIndex >= 0 && schemaIndex < _schemaFields.Count)
            {
                var fieldTip = _schemaFields[schemaIndex].Tooltip;
                return string.IsNullOrWhiteSpace(fieldTip)
                    ? usage
                    : $"{usage} {fieldTip}";
            }

            return usage;
        }
    }
}
