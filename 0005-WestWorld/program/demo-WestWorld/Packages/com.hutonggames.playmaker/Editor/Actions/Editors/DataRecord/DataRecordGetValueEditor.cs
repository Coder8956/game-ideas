using System.Collections.Generic;
using HutongGames.Editor;
using HutongGames.Extensions;
using HutongGames.PlayMaker.Actions;
using JetBrains.Annotations;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.Editor
{
    [UsedImplicitly]
    [CustomActionEditor(typeof(DataRecordGetValue))]
    public sealed class DataRecordGetValueEditor : CustomActionEditor
    {
        private readonly List<DataSchemaUtility.SchemaField> _schemaFields = new();

        private DataRecordGetValue Action => Target as DataRecordGetValue;

        private VisualElement ContentRoot { get; set; }

        private VisualElement _definitionFieldElement;
        private DataDefinitionWatcher _definitionWatcher;

        public override void BuildGUI()
        {
            AddField(nameof(DataRecordGetValue.Record));

            _definitionFieldElement = TargetProperty.FindPropertyRelative(nameof(DataRecordGetValue.DataDefinition)) != null
                ? AddField(nameof(DataRecordGetValue.DataDefinition))
                : null;

            AddField(nameof(DataRecordGetValue.NotFoundEvent));
            AddField(nameof(DataRecordGetValue.Found));

            ContentRoot = new VisualElement();
            Add(ContentRoot);

            _definitionWatcher = new DataDefinitionWatcher(
                Root,
                getDefinition: ResolveEditTimeDataDefinition,
                onChanged: Rebuild);

            var recordProp = TargetProperty.FindPropertyRelative(nameof(DataRecordGetValue.Record));
            if (recordProp != null)
            {
                Root.TrackPropertyValue(recordProp, _ =>
                {
                    _definitionWatcher.Subscribe();
                    Rebuild();
                    NotifyActionChanged();
                });
            }

            var defProp = TargetProperty.FindPropertyRelative(nameof(DataRecordGetValue.DataDefinition));
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

            var showOverride = action.Record?.Value?.DataDefinition == null;

            if (_definitionFieldElement != null)
            {
                if (showOverride) _definitionFieldElement.Show();
                else _definitionFieldElement.Hide();
            }

            var def = action.Record?.Value?.DataDefinition;
            if (def == null && showOverride)
                def = action.DataDefinition;

            if (showOverride && def == null)
            {
                ContentRoot.Add(new HelpBox(
                    "DataRecord definition is unavailable at edit time. Assign a Data Definition to edit the action.",
                    HelpBoxMessageType.Info));
                return;
            }

            if (def == null)
                return;

            BuildRecordUI(def);
            Rebind(ContentRoot);
        }

        private void BuildRecordUI(DataDefinition def)
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

            var storeValueProp = TargetProperty.FindPropertyRelative(nameof(DataRecordGetValue.StoreValue));
            if (storeValueProp == null)
                return;

            var header = new Label("Store Field Value");
            header.RegisterTooltip(new TooltipInfo(
                "Store value from the selected field in the DataRecord. If the field is missing, the field's DataDefinition default is stored instead."));
            header.AddToClassList("hutong-field__header");
            ContentRoot.Add(header);
            ContentRoot.AddSpacer(6);

            var cellValue = new DataFieldStoreEditor(Target.Fsm, def, storeValueProp);
            ContentRoot.Add(cellValue);

            so.ApplyModifiedProperties();
        }

        private DataDefinition ResolveEditTimeDataDefinition()
        {
            var action = Action;
            if (action == null)
                return null;

            var showOverride = action.Record?.Value?.DataDefinition == null;
            var def = action.Record?.Value?.DataDefinition;
            if (def == null && showOverride)
                def = action.DataDefinition;
            return def;
        }
    }
}
