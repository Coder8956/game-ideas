using System.Collections.Generic;
using HutongGames.Extensions;
using HutongGames.PlayMaker.Actions;
using JetBrains.Annotations;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.Editor
{
    [UsedImplicitly]
    [CustomActionEditor(typeof(DataComponentGetValues))]
    public sealed class DataComponentGetValuesEditor : CustomActionEditor
    {
        private const string OrphanedUssClassName = "hutong-field--orphaned";

        private readonly List<DataSchemaUtility.SchemaField> _schemaFields = new();

        private DataComponentGetValues Action => Target as DataComponentGetValues;

        private VisualElement ContentRoot { get; set; }

        private VisualElement _definitionFieldElement;
        private DataDefinitionWatcher _definitionWatcher;

        public override void BuildGUI()
        {
            AddField(nameof(DataComponentGetValues.DataComponent));

            _definitionFieldElement = TargetProperty.FindPropertyRelative(nameof(DataComponentGetValues.DataDefinition)) != null
                ? AddField(nameof(DataComponentGetValues.DataDefinition))
                : null;

            ContentRoot = new VisualElement();
            Add(ContentRoot);

            AddField(nameof(DataComponentGetValues.NotFoundEvent));
            AddField(nameof(DataComponentGetValues.Succeeded));

            _definitionWatcher = new DataDefinitionWatcher(
                Root,
                getDefinition: ResolveEditTimeDataDefinition,
                onChanged: Rebuild);

            var dataComponentProp = TargetProperty.FindPropertyRelative(nameof(DataComponentGetValues.DataComponent));
            if (dataComponentProp != null)
            {
                Root.TrackPropertyValue(dataComponentProp, _ =>
                {
                    _definitionWatcher.Subscribe();
                    Rebuild();
                    NotifyActionChanged();
                });
            }

            var defProp = TargetProperty.FindPropertyRelative(nameof(DataComponentGetValues.DataDefinition));
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

            var getValuesProp = TargetProperty.FindPropertyRelative(nameof(DataComponentGetValues.GetValues));
            if (getValuesProp == null)
                return;

            var fieldGuidPropName = nameof(DataFieldStore.FieldGuid);
            var storePropName = nameof(DataFieldStore.Store);

            SchemaFieldOutputListUtility.SyncToSchema(
                _schemaFields,
                getValuesProp,
                fieldGuidPropName: fieldGuidPropName,
                storePropName: storePropName,
                createDefaultStoreWhenNull: true);

            so.ApplyModifiedProperties();
            so.Update();

            var header = new Label("Store Data Values")
            {
                tooltip = "Variables to store values from the Data Component's record.\n" +
                          "One output per field in the DataDefinition."
            };
            header.AddToClassList("hutong-field__header");
            ContentRoot.Add(header);
            ContentRoot.Add(Spacer(6));

            var guidToIndex = SchemaFieldOutputListUtility.BuildGuidToIndexMap(getValuesProp, fieldGuidPropName);

            for (int i = 0; i < _schemaFields.Count; i++)
            {
                var sf = _schemaFields[i];
                var guid = new SerializableGuid(sf.GuidA, sf.GuidB);

                if (!guidToIndex.TryGetValue(guid, out var idx))
                    continue;

                var fieldProp = getValuesProp.GetArrayElementAtIndex(idx);
                if (fieldProp == null)
                    continue;

                var storeProp = fieldProp.FindPropertyRelative(storePropName);
                var storeObj = storeProp?.managedReferenceValue as IVariableRef;

                var metaData = new MemberMetaData
                {
                    DataType = storeObj?.DataType ?? sf.DataType,
                    DisplayName = sf.Name,
                    IsWriteOnly = true,
                    IsOptional = true,
                };
                metaData.UpdateTooltipData(sf.Tooltip ?? "");

                var field = new VariableRefField(storeObj, metaData, storeProp);
                ContentRoot.Add(field);

                DebugValueField.Add(ContentRoot, Action?.Fsm, storeObj);
            }

            var schemaGuidSet = SchemaFieldOutputListUtility.BuildSchemaGuidSet(_schemaFields);
            var orphanIndices = SchemaFieldOutputListUtility.CollectOrphanIndices(getValuesProp, schemaGuidSet, fieldGuidPropName);

            if (orphanIndices.Count > 0)
            {
                ContentRoot.Add(Spacer(10));

                var orphanHeader = new Label("Orphaned Outputs")
                {
                    tooltip = "Outputs that no longer exist in the DataDefinition. These are kept to avoid losing connections."
                };
                orphanHeader.AddToClassList("hutong-field__header");
                ContentRoot.Add(orphanHeader);

                ContentRoot.Add(Spacer(6));

                for (int j = 0; j < orphanIndices.Count; j++)
                {
                    var idx = orphanIndices[j];

                    var fieldProp = getValuesProp.GetArrayElementAtIndex(idx);
                    if (fieldProp == null)
                        continue;

                    var storeProp = fieldProp.FindPropertyRelative(storePropName);
                    var storeObj = storeProp?.managedReferenceValue as IVariableRef;

                    var metaData = new MemberMetaData
                    {
                        DataType = storeObj?.DataType ?? typeof(object),
                        DisplayName = "(Orphaned)",
                        IsWriteOnly = true,
                        IsOptional = true
                    };
                    metaData.UpdateTooltipData("");

                    var field = new VariableRefField(storeObj, metaData, storeProp);
                    field.AddToClassList(OrphanedUssClassName);
                    ContentRoot.Add(field);
                }

                ContentRoot.Add(Spacer(6));

                var removeBtn = new Button(() =>
                {
                    so.Update();
                    SchemaFieldOutputListUtility.RemoveOrphans(getValuesProp, schemaGuidSet, fieldGuidPropName);
                    so.ApplyModifiedProperties();
                    Rebuild();
                })
                {
                    text = "Remove Orphans",
                    tooltip = "Remove outputs for fields that no longer exist in the DataDefinition.",
                    style = { width = 150, alignSelf = Align.FlexEnd }
                };

                ContentRoot.Add(removeBtn);
            }

            so.ApplyModifiedProperties();

            ContentRoot.schedule.Execute(() =>
            {
                ContentRoot.Unbind();
                ContentRoot.Bind(so);
            });
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

        private static VisualElement Spacer(int height)
        {
            var ve = new VisualElement();
            ve.style.height = height;
            return ve;
        }
    }
}
