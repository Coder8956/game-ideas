using System.Collections.Generic;
using HutongGames.Editor;
using HutongGames.Editor.Extensions;
using HutongGames.Extensions;
using HutongGames.PlayMaker.Actions;
using JetBrains.Annotations;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.Editor
{
    [UsedImplicitly]
    [CustomActionEditor(typeof(DataComponentSetValues))]
    public sealed class DataComponentSetValuesEditor : CustomActionEditor
    {
        private const string OrphanedUssClassName = "hutong-field--orphaned";

        private readonly List<DataSchemaUtility.SchemaField> _schemaFields = new();

        private DataComponentSetValues Action => Target as DataComponentSetValues;

        private VisualElement ContentRoot { get; set; }

        private VisualElement _definitionFieldElement;
        private DataDefinitionWatcher _definitionWatcher;

        public override void BuildGUI()
        {
            AddField(nameof(DataComponentSetValues.DataComponent));

            _definitionFieldElement = TargetProperty.FindPropertyRelative(nameof(DataComponentSetValues.DataDefinition)) != null
                ? AddField(nameof(DataComponentSetValues.DataDefinition))
                : null;

            ContentRoot = new VisualElement();
            Add(ContentRoot);

            AddField(nameof(DataComponentSetValues.NotFoundEvent));
            AddField(nameof(DataComponentSetValues.Succeeded));

            _definitionWatcher = new DataDefinitionWatcher(
                Root,
                getDefinition: ResolveEditTimeDataDefinition,
                onChanged: Rebuild);

            var dataComponentProp = TargetProperty.FindPropertyRelative(nameof(DataComponentSetValues.DataComponent));
            if (dataComponentProp != null)
            {
                Root.TrackPropertyValue(dataComponentProp, _ =>
                {
                    _definitionWatcher.Subscribe();
                    Rebuild();
                    NotifyActionChanged();
                });
            }

            var defProp = TargetProperty.FindPropertyRelative(nameof(DataComponentSetValues.DataDefinition));
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

            var setValuesProp = TargetProperty.FindPropertyRelative(nameof(DataComponentSetValues.SetValues));
            if (setValuesProp == null)
            {
                ContentRoot.Add(new HelpBox("SetValues list not found.", HelpBoxMessageType.Warning));
                return;
            }

            var fieldGuidPropName = nameof(DataFieldValue.FieldGuid);
            var valuePropName = nameof(DataFieldValue.Value);
            var fsm = setValuesProp.TryGetFsmOwner();

            SchemaFieldValueListUtility.SyncToSchema(
                _schemaFields,
                setValuesProp,
                fieldGuidPropName: fieldGuidPropName,
                valuePropName: valuePropName,
                createDefaultValueWhenNull: true);

            so.ApplyModifiedProperties();
            so.Update();

            var header = new Label("Set Field Values");
            header.RegisterTooltip(new TooltipInfo(
                "Values to write into the Data Component's record.\nOne entry per field in the DataDefinition.")
            {
                Hints = "Set to None to leave value unchanged."
            });
            header.AddToClassList("hutong-field__header");
            ContentRoot.Add(header);
            ContentRoot.AddSpacer(6);

            var guidToIndex = SchemaFieldValueListUtility.BuildGuidToIndexMap(setValuesProp, fieldGuidPropName);

            for (int i = 0; i < _schemaFields.Count; i++)
            {
                var sf = _schemaFields[i];
                var guid = new SerializableGuid(sf.GuidA, sf.GuidB);

                if (!guidToIndex.TryGetValue(guid, out var idx))
                    continue;

                var fvProp = setValuesProp.GetArrayElementAtIndex(idx);
                if (fvProp == null) continue;

                var valueProp = fvProp.FindPropertyRelative(valuePropName);
                var valueObj = valueProp?.managedReferenceValue as IVariableVar;

                var meta = new MemberMetaData
                {
                    DataType = valueObj?.DataType ?? sf.DataType,
                    SubType = valueObj?.SubType ?? sf.SubType,
                    DisplayName = sf.Name,
                };
                meta.UpdateTooltipData(sf.Tooltip ?? "");

                ContentRoot.Add(new VariableVarField(valueObj, meta, valueProp));
                if (fsm != null && valueObj != null)
                    DebugValueField.Add(ContentRoot, fsm, valueObj);
            }

            var schemaGuidSet = SchemaFieldValueListUtility.BuildSchemaGuidSet(_schemaFields);
            var orphanIndices = SchemaFieldValueListUtility.CollectOrphanIndices(setValuesProp, schemaGuidSet, fieldGuidPropName);

            if (orphanIndices.Count > 0)
            {
                ContentRoot.AddSpacer(10);

                var orphanHeader = new Label("Orphaned Values")
                {
                    tooltip = "Values for fields that no longer exist in the DataDefinition. Kept to avoid losing data."
                };
                orphanHeader.AddToClassList("hutong-field__header");
                ContentRoot.Add(orphanHeader);

                ContentRoot.AddSpacer(6);

                for (int j = 0; j < orphanIndices.Count; j++)
                {
                    var idx = orphanIndices[j];
                    var fvProp = setValuesProp.GetArrayElementAtIndex(idx);
                    if (fvProp == null) continue;

                    var valueProp = fvProp.FindPropertyRelative(valuePropName);
                    var valueObj = valueProp?.managedReferenceValue as IVariableVar;

                    var meta = new MemberMetaData
                    {
                        DataType = valueObj?.DataType ?? typeof(object),
                        DisplayName = "(Orphaned)"
                    };
                    meta.UpdateTooltipData("");

                    var field = new VariableVarField(valueObj, meta, valueProp);
                    field.AddToClassList(OrphanedUssClassName);
                    ContentRoot.Add(field);
                    if (fsm != null && valueObj != null)
                        DebugValueField.Add(ContentRoot, fsm, valueObj);
                }

                ContentRoot.AddSpacer(6);

                var removeBtn = new Button(() =>
                {
                    so.Update();
                    SchemaFieldValueListUtility.RemoveOrphans(setValuesProp, schemaGuidSet, fieldGuidPropName);
                    so.ApplyModifiedProperties();
                    Rebuild();
                    UpdateErrors();
                })
                {
                    text = "Remove Orphans",
                    tooltip = "Remove values for fields that no longer exist in the DataDefinition.",
                    style = { width = 150, alignSelf = Align.FlexEnd }
                };

                ContentRoot.Add(removeBtn);
            }

            so.ApplyModifiedProperties();

            Rebind(ContentRoot);
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
