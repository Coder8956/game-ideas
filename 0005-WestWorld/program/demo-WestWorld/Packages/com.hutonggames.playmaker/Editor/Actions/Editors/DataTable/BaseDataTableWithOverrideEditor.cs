using HutongGames.PlayMaker.Actions;
using HutongGames.Extensions;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.Editor
{
    public abstract class BaseDataTableWithOverrideEditor<TAction> : CustomActionEditor
        where TAction : class, IDataTableAction
    {
        protected TAction Action { get; private set; }

        protected VisualElement ContentRoot { get; private set; }

        private VisualElement _definitionFieldElement;
        private DataDefinitionWatcher _definitionWatcher;
        private bool _rebuildScheduled;

        /// <summary>
        /// Add fields that should appear before schema-driven UI
        /// (e.g. Key/Index selectors, filters that affect what ContentRoot shows).
        /// </summary>
        protected virtual void BuildBeforeContentGUI() { }

        /// <summary>
        /// Add fields that should appear after schema-driven UI
        /// (e.g. outputs, advanced options, secondary settings).
        /// </summary>
        protected virtual void BuildAfterContentGUI() { }

        /// <summary>Build schema-driven UI with the resolved edit-time DataDefinition.</summary>
        protected abstract void BuildTableUI(DataDefinition definition);

        public override void BuildGUI()
        {
            Action = Target as TAction;
            if (Action == null)
            {
                BuildDefaultGUI();
                return;
            }

            // Header fields (consistent for all DataTable actions)
            AddField(nameof(IDataTableAction.DataTable));
            
            // Keep the override field in the right place, but we’ll hide/show it automatically.
            _definitionFieldElement = TargetProperty.FindPropertyRelative(nameof(IDataTableAction.DataDefinition)) != null
                ? AddField(nameof(IDataTableAction.DataDefinition))
                : null;

            // Slot: before
            BuildBeforeContentGUI();

            // Schema-driven content
            ContentRoot = new VisualElement();
            Add(ContentRoot);

            // Slot: after
            BuildAfterContentGUI();

            _definitionWatcher = new DataDefinitionWatcher(
                Root,
                getDefinition: ResolveEditTimeDataDefinition,
                onChanged: Rebuild);

            // Rebuild when header fields change
            TrackTableProperties();

            var defProp = TargetProperty.FindPropertyRelative(nameof(IDataTableAction.DataDefinition));
            if (defProp != null)
            {
                Root.TrackPropertyValue(defProp, _ =>
                {
                    ScheduleRebuild();
                    NotifyActionChanged();
                });
            }

            _definitionWatcher.Subscribe();
            Rebuild();
        }

        private void TrackTableProperties()
        {
            var tableProp = TargetProperty.FindPropertyRelative(nameof(IDataTableAction.DataTable));
            if (tableProp == null)
                return;

            TrackAndRebuild(tableProp);

            // DataTableSource is a compound property, so watch its children too.
            TrackAndRebuild(tableProp.FindPropertyRelative(nameof(DataTableSource.Source)));
            TrackAndRebuild(tableProp.FindPropertyRelative(nameof(DataTableSource.TableAsset)));
            TrackAndRebuild(tableProp.FindPropertyRelative(nameof(DataTableSource.TableComponent)));
            TrackAndRebuild(tableProp.FindPropertyRelative(nameof(DataTableSource.Table)));
        }

        private void TrackAndRebuild(SerializedProperty property)
        {
            if (property == null)
                return;

            var trackedProperty = property.Copy();
            Root.TrackPropertyValue(trackedProperty, _ =>
            {
                ScheduleRebuild();
                NotifyActionChanged();
            });
        }

        private void ScheduleRebuild()
        {
            if (_rebuildScheduled)
                return;

            _rebuildScheduled = true;
            Root.schedule.Execute(() =>
            {
                _rebuildScheduled = false;
                _definitionWatcher.Subscribe();
                Rebuild();
            });
        }

        /// <summary>
        /// Allow derived editors to refresh schema UI when row selectors change (Key/Index/etc).
        /// </summary>
        protected void RequestRebuild() => Rebuild();

        private void Rebuild()
        {
            ContentRoot.Clear();

            if (Action == null)
                return;

            var showOverride = Action.DataTable.GetEditTimeDataDefinition() == null;

            if (_definitionFieldElement != null)
            {
                if (showOverride) _definitionFieldElement.Show();
                else _definitionFieldElement.Hide();
            }

            var def = Action.DataTable.GetEditTimeDataDefinition();
            if (def == null && showOverride)
                def = Action.DataDefinition;

            if (showOverride && def == null)
            {
                ContentRoot.Add(new HelpBox(
                    "Table definition is unavailable at edit time. Assign a Data Definition to edit the action.",
                    HelpBoxMessageType.Info));
                return;
            }

            if (def == null)
                return;

            BuildTableUI(def);
            
            Rebind(ContentRoot);
        }

        private DataDefinition ResolveEditTimeDataDefinition()
        {
            if (Action == null)
                return null;

            var showOverride = Action.DataTable.GetEditTimeDataDefinition() == null;
            var def = Action.DataTable.GetEditTimeDataDefinition();
            if (def == null && showOverride)
                def = Action.DataDefinition;
            return def;
        }
    }
}
