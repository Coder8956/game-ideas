using HutongGames.PlayMaker.UI;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.UI
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.DataTableWidget)]
    [ActionDescription("Send Event when a DataTableWidget row action occurs (Select/Delete/Move/Drag/Custom).")]
    public sealed class DataTableWidgetOnRowAction : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.OnEventUpdate;
        
        [Tooltip("The DataTableWidget to listen to.")]
        [SerializeField]
        private DataTableWidgetVar _widget;
        
        [Tooltip("Which row action should trigger the event.")]
        [SerializeField]
        private DataUICommand _action;

        [Tooltip("The Event to send when the row action occurs.")]
        [SerializeField, OptionalField]
        private EventRef _sendEvent;

        [ActionHeader("Outputs")]

        [OptionalField]
        [Tooltip("Row Key associated with the action (may be empty if unused).")]
        [SerializeField]
        [WriteOnly]
        private StringRef _rowKey;

        [OptionalField]
        [Tooltip("Index of the row in the DataTable at the moment the action fired.")]
        [SerializeField]
        [WriteOnly]
        private IntegerRef _tableIndex;
        
        [OptionalField, HideIf(nameof(HideCustomArgs))]
        [Tooltip("Optional int argument (mainly used by Custom actions).")]
        [SerializeField]
        [WriteOnly]
        private IntegerRef _integerArg;

        [OptionalField, HideIf(nameof(HideCustomArgs))]
        [Tooltip("Optional string argument (mainly used by Custom actions).")]
        [SerializeField]
        [WriteOnly]
        private StringRef _stringArg;

        private bool HideCustomArgs => _action != DataUICommand.Custom;
        
        private DataTableWidget _subscribed;

        public override bool CanExecute() => CheckParameters(_widget);

        public override void OnStart()
        {
            var w = _widget.Value;
            if (w == null) return;

            if (ReferenceEquals(_subscribed, w))
                return;

            Unsubscribe();

            _subscribed = w;
            _subscribed.RowAction += OnRowAction;
        }

        public override void OnStop()
        {
            Unsubscribe();
        }

        private void Unsubscribe()
        {
            if (_subscribed != null)
                _subscribed.RowAction -= OnRowAction;

            _subscribed = null;
        }

        private void OnRowAction(DataUIActionRequest request)
        {
            if (request.Command != _action)
                return;

            _rowKey.Value = request.ItemKey;
            _tableIndex.Value = request.SourceIndex;
            _integerArg.Value = request.IntArg;
            _stringArg.Value = request.StringArg;

            QueueEvent(_sendEvent);
        }

        public override string GetSummary()
            => "On {_widget} {_action} {_sendEvent} {_rowKey:output} {_tableIndex:output}";
    }
}
