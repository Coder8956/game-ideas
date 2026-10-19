using System.Collections.Generic;
using HutongGames.Editor;
using HutongGames.Editor.Extensions;
using HutongGames.PlayMaker.Actions;
using JetBrains.Annotations;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.Editor
{
    [UsedImplicitly]
    [CustomActionEditor(typeof(GameObjectSetData))]
    public sealed class GameObjectSetDataEditor : CustomActionEditor
    {
        private const string OrphanedUssClassName = "hutong-field--orphaned";

        private GameObjectSetData _action;
        private VisualElement _panel;

        private readonly List<DataSchemaUtility.SchemaField> _schemaFields = new();

        public override void BuildGUI()
        {
            _action = (GameObjectSetData)Target;

            AddField(nameof(GameObjectSetData.GameObject));
            AddField(nameof(GameObjectSetData.DataDefinition));
            AddField(nameof(GameObjectSetData.AddIfMissing));

            _panel = new VisualElement();
            Add(_panel);
            
            AddField(nameof(GameObjectSetData.NotFoundEvent));
            AddField(nameof(GameObjectSetData.Added));
            AddField(nameof(GameObjectSetData.Succeeded));

            var defProp = TargetProperty.FindPropertyRelative(nameof(GameObjectSetData.DataDefinition));
            if (defProp != null)
            {
                Root.TrackPropertyValue(defProp, _ =>
                {
                    UpdateUI();
                    NotifyActionChanged();
                });
            }

            UpdateUI();
        }

        private void UpdateUI()
        {
            // Important when rebuilding dynamic UI
            _panel.Unbind();
            _panel.Clear();

            if (_action == null)
                return;

            var def = _action.DataDefinition;
            if (def == null)
            {
                _panel.Add(new HelpBox("Assign a DataDefinition to set values.", HelpBoxMessageType.Info));
                return;
            }

            DataSchemaUtility.BuildSchemaFieldsInEditorOrder(def, _schemaFields);

            if (_schemaFields.Count == 0)
            {
                _panel.Add(new HelpBox("The selected DataDefinition has no fields.", HelpBoxMessageType.Info));
                return;
            }

            var so = TargetProperty.serializedObject;
            so.Update();

            var setValuesProp = TargetProperty.FindPropertyRelative(nameof(GameObjectSetData.SetValues));
            if (setValuesProp == null)
            {
                _panel.Add(new HelpBox("SetValues list not found.", HelpBoxMessageType.Warning));
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
            header.RegisterTooltip( new TooltipInfo(
                "Values to write into the Data Component's record.\nOne entry per field in the DataDefinition.")
            {
                Hints = "Set to None to leave value unchanged."
            });
            header.AddToClassList("hutong-field__header");
            _panel.Add(header);
            _panel.AddSpacer(6);

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
                    SubType  = valueObj?.SubType  ?? sf.SubType,
                    DisplayName = sf.Name,
                };
                meta.UpdateTooltipData(sf.Tooltip ?? "");

                _panel.Add(new VariableVarField(valueObj, meta, valueProp));
                if (fsm != null && valueObj != null)
                    DebugValueField.Add(_panel, fsm, valueObj);
            }

            // Orphans section
            var schemaGuidSet = SchemaFieldValueListUtility.BuildSchemaGuidSet(_schemaFields);
            var orphanIndices = SchemaFieldValueListUtility.CollectOrphanIndices(setValuesProp, schemaGuidSet, fieldGuidPropName);

            if (orphanIndices.Count > 0)
            {
                _panel.AddSpacer(10);

                var orphanHeader = new Label("Orphaned Values")
                {
                    tooltip = "Values for fields that no longer exist in the DataDefinition. Kept to avoid losing data."
                };
                orphanHeader.AddToClassList("hutong-field__header");
                _panel.Add(orphanHeader);

                _panel.AddSpacer(6);

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
                    _panel.Add(field);
                    if (fsm != null && valueObj != null)
                        DebugValueField.Add(_panel, fsm, valueObj);
                }

                _panel.AddSpacer(6);

                var removeBtn = new Button(() =>
                {
                    so.Update();
                    SchemaFieldValueListUtility.RemoveOrphans(setValuesProp, schemaGuidSet, fieldGuidPropName);
                    so.ApplyModifiedProperties();
                    UpdateUI();
                    UpdateErrors();
                })
                {
                    text = "Remove Orphans",
                    tooltip = "Remove values for fields that no longer exist in the DataDefinition.",
                    style = { width = 150, alignSelf = Align.FlexEnd }
                };

                _panel.Add(removeBtn);
            }

            so.ApplyModifiedProperties();
            
            Rebind(_panel);
        }
    }
}
