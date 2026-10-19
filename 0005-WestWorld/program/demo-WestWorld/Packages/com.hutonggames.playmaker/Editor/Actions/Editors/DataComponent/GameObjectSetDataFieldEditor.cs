using HutongGames.Editor;
using HutongGames.PlayMaker.Actions;
using JetBrains.Annotations;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.Editor
{
    [UsedImplicitly]
    [CustomActionEditor(typeof(GameObjectSetDataField))]
    public sealed class GameObjectSetDataFieldEditor : CustomActionEditor
    {
        private VisualElement _panel;
        private GameObjectSetDataField _action;

        public override void BuildGUI()
        {
            //BuildDefaultGUI();
            AddField(nameof(GameObjectSetDataField.GameObject));
            AddField(nameof(GameObjectSetDataField.DataDefinition));
            AddField(nameof(GameObjectSetDataField.AddIfMissing));
            
            _action = (GameObjectSetDataField)Target;

            _panel = new VisualElement();
            Add(_panel);

            // Rebuild on DataDefinition changes.
            var defProp = TargetProperty.FindPropertyRelative(nameof(GameObjectSetDataField.DataDefinition));
            if (defProp != null)
            {
                Root.TrackPropertyValue(defProp, _ =>
                {
                    UpdateUI();
                    NotifyActionChanged();
                });
            }

            UpdateUI();
            
            AddField(nameof(GameObjectSetDataField.NotFoundEvent));
            AddField(nameof(GameObjectSetDataField.Added));
            AddField(nameof(GameObjectSetDataField.Succeeded));
        }

        private void UpdateUI()
        {
            // Important when rebuilding dynamic UI
            _panel.Unbind();
            _panel.Clear();

            var def = _action?.DataDefinition;
            if (def == null)
            {
                _panel.Add(new HelpBox(
                    "Assign a DataDefinition to build schema-driven outputs.",
                    HelpBoxMessageType.Info));
                return;
            }
            
            var so = TargetProperty.serializedObject;
            so.Update();
            
            var setValueProp = TargetProperty.FindPropertyRelative(nameof(GameObjectSetDataField.SetValue));
            if (setValueProp == null)
                return;
            
            // Apply so managedReference defaults exist for drawing
            so.ApplyModifiedProperties();
            so.Update();

            // Header
            var header = new Label("Set Field Value");
            header.AddToClassList("hutong-field__header");
            _panel.Add(header);
            _panel.AddSpacer(6);
            
            var cellValue = new DataFieldValueEditor(def, setValueProp);
            _panel.Add(cellValue);
            
            so.ApplyModifiedProperties();

            Rebind(_panel);
        }
    }
}
