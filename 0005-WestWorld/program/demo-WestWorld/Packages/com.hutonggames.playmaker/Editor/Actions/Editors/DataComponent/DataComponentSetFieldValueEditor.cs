using System;
using System.Collections.Generic;
using HutongGames.Editor;
using HutongGames.Extensions;
using HutongGames.PlayMaker.Actions;
using JetBrains.Annotations;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.Editor
{
    [UsedImplicitly]
    [CustomActionEditor(typeof(DataComponentSetFieldValue))]
    public sealed class DataComponentSetFieldValueEditor : CustomActionEditor
    {
        private readonly List<DataSchemaUtility.SchemaField> _schemaFields = new();

        private DataComponentSetFieldValue Action => Target as DataComponentSetFieldValue;

        private VisualElement ContentRoot { get; set; }

        private VisualElement _definitionFieldElement;
        private DataDefinitionWatcher _definitionWatcher;

        public override void BuildGUI()
        {
            AddField(nameof(DataComponentSetFieldValue.DataComponent));

            _definitionFieldElement = TargetProperty.FindPropertyRelative(nameof(DataComponentSetFieldValue.DataDefinition)) != null
                ? AddField(nameof(DataComponentSetFieldValue.DataDefinition))
                : null;

            ContentRoot = new VisualElement();
            Add(ContentRoot);

            AddField(nameof(DataComponentSetFieldValue.NotFoundEvent));
            AddField(nameof(DataComponentSetFieldValue.Succeeded));

            _definitionWatcher = new DataDefinitionWatcher(
                Root,
                getDefinition: ResolveEditTimeDataDefinition,
                onChanged: Rebuild);

            var dataComponentProp = TargetProperty.FindPropertyRelative(nameof(DataComponentSetFieldValue.DataComponent));
            if (dataComponentProp != null)
            {
                Root.TrackPropertyValue(dataComponentProp, _ =>
                {
                    _definitionWatcher.Subscribe();
                    Rebuild();
                    NotifyActionChanged();
                });
            }

            var defProp = TargetProperty.FindPropertyRelative(nameof(DataComponentSetFieldValue.DataDefinition));
            if (defProp != null)
            {
                Root.TrackPropertyValue(defProp, _ =>
                {
                    _definitionWatcher.Subscribe();
                    Rebuild();
                    NotifyActionChanged();
                });
            }

            _definitionWatcher.Subscribe();
            Rebuild();
        }

        private void Rebuild()
        {
            ContentRoot.Clear();

            var action = Action;
            if (action == null)
                return;

            var showOverride = action.DataComponent != null && action.DataComponent.IsVariable;

            if (_definitionFieldElement != null)
            {
                if (showOverride) _definitionFieldElement.Show();
                else _definitionFieldElement.Hide();
            }

            var def = action.DataComponent?.Value?.Data?.DataDefinition;
            if (def == null && showOverride)
                def = action.DataDefinition;

            if (showOverride && def == null)
            {
                ContentRoot.Add(new HelpBox(
                    "Data Component is variable or unavailable at edit time. Assign a Data Definition to edit the action.",
                    HelpBoxMessageType.Info));
                return;
            }

            if (def == null)
                return;

            BuildComponentUI(def);
            Rebind(ContentRoot);
        }

        private void BuildComponentUI(DataDefinition def)
        {
            ContentRoot.Clear();

            DataSchemaUtility.BuildSchemaFieldsInEditorOrder(def, _schemaFields);
            if (_schemaFields.Count == 0)
            {
                ContentRoot.Add(new HelpBox("The selected DataDefinition has no fields.", HelpBoxMessageType.Info));
                return;
            }

            var so = TargetProperty.serializedObject;
            so.Update();

            var setValueProp = TargetProperty.FindPropertyRelative(nameof(DataComponentSetFieldValue.SetValue));
            if (setValueProp == null)
                return;

            var header = new Label("Set Field Value");
            header.AddToClassList("hutong-field__header");
            ContentRoot.Add(header);
            ContentRoot.AddSpacer(6);

            var cellValue = new DataFieldValueEditor(def, setValueProp, guid => ResolveSelectedValueType(guid));
            ContentRoot.Add(cellValue);

            so.ApplyModifiedProperties();
        }

        private Type ResolveSelectedValueType(SerializableGuid fieldGuid)
        {
            var typeFromCell = GetTypeFromSelectedComponentCell(fieldGuid);
            if (typeFromCell != null)
                return typeFromCell;

            for (var i = 0; i < _schemaFields.Count; i++)
            {
                var field = _schemaFields[i];
                if (fieldGuid != new SerializableGuid(field.GuidA, field.GuidB))
                    continue;

                return field.SubType ?? field.DataType;
            }

            return null;
        }

        private Type GetTypeFromSelectedComponentCell(SerializableGuid fieldGuid)
        {
            var component = Action?.DataComponent?.Value;
            if (component == null)
                return null;

            var cells = component.Data?.Data?.Cells;
            if (cells == null)
                return null;

            for (var i = 0; i < cells.Count; i++)
            {
                var cell = cells[i];
                if (cell == null || cell.FieldGuid != fieldGuid)
                    continue;

                return cell.Value?.SubType ?? cell.Value?.DataType;
            }

            return null;
        }

        private DataDefinition ResolveEditTimeDataDefinition()
        {
            var action = Action;
            if (action == null)
                return null;

            var showOverride = action.DataComponent != null && action.DataComponent.IsVariable;
            var def = action.DataComponent?.Value?.Data?.DataDefinition;
            if (def == null && showOverride)
                def = action.DataDefinition;
            return def;
        }
    }
}
