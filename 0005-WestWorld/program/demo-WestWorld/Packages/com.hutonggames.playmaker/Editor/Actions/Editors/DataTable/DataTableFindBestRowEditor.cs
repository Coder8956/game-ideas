using System.Collections.Generic;
using HutongGames.PlayMaker.Actions;
using JetBrains.Annotations;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.Editor
{
    [UsedImplicitly]
    [CustomActionEditor(typeof(DataTableFindBestRow))]
    public sealed class DataTableFindBestRowEditor : BaseDataTableWithOverrideEditor<DataTableFindBestRow>
    {
        private readonly List<DataSchemaUtility.SchemaField> _schemaFields = new();

        protected override void BuildAfterContentGUI()
        {
            AddField(nameof(DataTableFindBestRow.Mode));
            AddField(nameof(DataTableFindBestRow.Index));
            AddField(nameof(DataTableFindBestRow.Key));
            AddField(nameof(DataTableFindBestRow.Record));
            AddField(nameof(DataTableFindBestRow.Found));
            AddField(nameof(DataTableFindBestRow.NotFoundEvent));
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

            var currentGuid = Action.FieldGuid;
            var currentIndex = 0;

            if (currentGuid != DataTableUtility.RowKeyGuid)
            {
                currentIndex = 1;
                for (int i = 0; i < _schemaFields.Count; i++)
                {
                    var sf = _schemaFields[i];
                    var guid = SerializableGuid.FromParts(sf.GuidA, sf.GuidB);
                    if (guid == currentGuid)
                    {
                        currentIndex = 1 + i;
                        break;
                    }
                }
            }

            var dropdown = new PopupField<string>("Field", choices, currentIndex);
            dropdown.AddToClassList("hutong-field");
            dropdown.tooltip = currentIndex == 0
                ? "Use the row Key value (not a DataDefinition field)."
                : _schemaFields[currentIndex - 1].Tooltip ?? "";

            ContentRoot.Add(dropdown);

            dropdown.RegisterValueChangedCallback(_ =>
            {
                var idx = dropdown.index;

                var so = TargetProperty.serializedObject;
                so.Update();

                var guidProp = TargetProperty.FindPropertyRelative(nameof(DataTableFindBestRow.FieldGuid));
                if (guidProp == null) return;

                if (idx == 0)
                {
                    guidProp.boxedValue = DataTableUtility.RowKeyGuid;
                    so.ApplyModifiedProperties();
                    dropdown.tooltip = "Use the row Key value (not a DataDefinition field).";
                    UpdateErrors();
                    return;
                }

                var schemaIndex = idx - 1;
                if (schemaIndex < 0 || schemaIndex >= _schemaFields.Count)
                    return;

                var sf = _schemaFields[schemaIndex];
                guidProp.boxedValue = SerializableGuid.FromParts(sf.GuidA, sf.GuidB);
                so.ApplyModifiedProperties();

                dropdown.tooltip = sf.Tooltip ?? "";
                UpdateErrors();
            });
        }
    }
}
