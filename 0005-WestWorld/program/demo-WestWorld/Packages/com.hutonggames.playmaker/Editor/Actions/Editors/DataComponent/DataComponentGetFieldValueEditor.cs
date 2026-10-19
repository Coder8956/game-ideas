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
    [CustomActionEditor(typeof(DataComponentGetFieldValue))]
    public sealed class DataComponentGetFieldValueEditor : CustomActionEditor
    {
        private readonly List<DataSchemaUtility.SchemaField> _schemaFields = new();

        private DataComponentGetFieldValue Action => Target as DataComponentGetFieldValue;

        private VisualElement ContentRoot { get; set; }

        private VisualElement _definitionFieldElement;
        private DataDefinitionWatcher _definitionWatcher;

        public override void BuildGUI()
        {
            AddField(nameof(DataComponentGetFieldValue.DataComponent));

            _definitionFieldElement = TargetProperty.FindPropertyRelative(nameof(DataComponentGetFieldValue.DataDefinition)) != null
                ? AddField(nameof(DataComponentGetFieldValue.DataDefinition))
                : null;

            AddField(nameof(DataComponentGetFieldValue.NotFoundEvent));
            AddField(nameof(DataComponentGetFieldValue.Found));

            ContentRoot = new VisualElement();
            Add(ContentRoot);

            _definitionWatcher = new DataDefinitionWatcher(
                Root,
                getDefinition: ResolveEditTimeDataDefinition,
                onChanged: Rebuild);

            var dataComponentProp = TargetProperty.FindPropertyRelative(nameof(DataComponentGetFieldValue.DataComponent));
            if (dataComponentProp != null)
            {
                Root.TrackPropertyValue(dataComponentProp, _ =>
                {
                    _definitionWatcher.Subscribe();
                    Rebuild();
                    NotifyActionChanged();
                });
            }

            var defProp = TargetProperty.FindPropertyRelative(nameof(DataComponentGetFieldValue.DataDefinition));
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

            var storeValueProp = TargetProperty.FindPropertyRelative(nameof(DataComponentGetFieldValue.StoreValue));
            if (storeValueProp == null)
                return;

            var header = new Label("Store Field Value");
            header.RegisterTooltip(new TooltipInfo(
                "Store value from the selected field in the Data Component. If the field is missing, the field's DataDefinition default is stored instead."));
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

            var showOverride = action.DataComponent != null && action.DataComponent.IsVariable;
            var def = action.DataComponent?.Value?.Data?.DataDefinition;
            if (def == null && showOverride)
                def = action.DataDefinition;
            return def;
        }
    }
}
