using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Resources)]
    [ActionDescription("Unloads assets that are no longer used and releases memory. Sends an event when finished.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Resources.UnloadUnusedAssets.html")]
    public sealed class ResourcesUnloadUnusedAssets : BaseAction
    {
        public override bool CanFinish => true;
        
        [Tooltip("Event sent when the unload operation has finished.")]
        [SerializeField]
        private EventRef _finishedEvent;

        [Tooltip("Store the progress (0..1).")]
        [SerializeField, WriteOnly, OptionalField]
        private FloatRef _progress;

        [Tooltip("True when the operation is done.")]
        [SerializeField, WriteOnly, OptionalField]
        private BoolRef _isDone;

        private AsyncOperation _op;
        private bool _started;
        private bool _sent;

        public override void Execute()
        {
            // If we've already sent the finished event, do nothing on subsequent ticks.
            if (_sent)
                return;

            // First tick: kick off the async op.
            if (!_started)
            {
                _started = true;
                _op = Resources.UnloadUnusedAssets();

                // Unity can (rarely) return null; treat as immediately done.
                if (_op == null)
                {
                    SetDoneOutputs();
                    SendFinished();
                    return;
                }
            }

            Progress = _op.progress;
            
            // Subsequent ticks: update outputs and check completion.
            if (_progress.IsAssigned)
                _progress.Value = _op.progress;

            if (_isDone.IsAssigned)
                _isDone.Value = _op.isDone;

            if (_op.isDone)
            {
                SetDoneOutputs();
                SendFinished();
                Finish();
            }
        }

        public override void Reset()
        {
            _op = null;
            _started = false;
            _sent = false;
        }

        private void SetDoneOutputs()
        {
            if (_progress.IsAssigned)
                _progress.Value = 1f;

            if (_isDone.IsAssigned)
                _isDone.Value = true;
        }

        private void SendFinished()
        {
            _sent = true;

            if (_finishedEvent != null)
                SendEvent(_finishedEvent);
        }

        public override string GetSummary() =>
            _finishedEvent != null
                ? $"Unload unused assets (send {_finishedEvent.Name})"
                : "Unload unused assets";
    }
}
