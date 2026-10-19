using HutongGames.Editor;
using HutongGames.PlayMaker.Actions;
using JetBrains.Annotations;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.Editor
{
    [UsedImplicitly]
    [CustomActionEditor(typeof(GameObjectGetDataField))]
    public sealed class GameObjectGetDataFieldEditor : CustomActionEditor
    {
        private VisualElement _panel;
        private GameObjectGetDataField _action;

        public override void BuildGUI()
        {
            //BuildDefaultGUI();
            AddField(nameof(GameObjectGetDataField.GameObject));
            AddField(nameof(GameObjectGetDataField.DataDefinition));
            AddField(nameof(GameObjectGetDataField.StoreDefaultsIfMissing));
            
            _action = (GameObjectGetDataField)Target;

            _panel = new VisualElement();
            Add(_panel);

            // Rebuild on DataDefinition changes.
            var defProp = TargetProperty.FindPropertyRelative(nameof(GameObjectGetDataField.DataDefinition));
            if (defProp != null)
            {
                Root.TrackPropertyValue(defProp, _ =>
                {
                    UpdateUI();
                    NotifyActionChanged();
                });
            }

            UpdateUI();
            
            AddField(nameof(GameObjectGetDataField.NotFoundEvent));
            AddField(nameof(GameObjectGetDataField.UsedDefaults));
            AddField(nameof(GameObjectGetDataField.Succeeded));
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
            
            var getValueProp = TargetProperty.FindPropertyRelative(nameof(GameObjectGetDataField.GetValue));
            if (getValueProp == null)
                return;
            
            // Apply so managedReference defaults exist for drawing
            so.ApplyModifiedProperties();
            so.Update();

            // Header
            var header = new Label("Store Field Value");
            header.AddToClassList("hutong-field__header");
            _panel.Add(header);
            _panel.AddSpacer(6);
            
            var cellValue = new DataFieldStoreEditor(_action.Fsm, def, getValueProp);
            _panel.Add(cellValue);
            
            so.ApplyModifiedProperties();

            Rebind(_panel);
        }
    }
}
