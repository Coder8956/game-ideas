using HutongGames.PlayMaker.FSM;
using JetBrains.Annotations;
using UnityEngine;
using Coroutine = UnityEngine.Coroutine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Sequence)]
    [ActionDescription("Wait for another FSM to finish running. " +
                       "Finished means the target FSM reached an end state. " +
                       "If the target FSM is disabled or otherwise stopped before that, this action keeps waiting unless it times out.")]
    public class WaitForFsmFinished : BaseWaitAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.OnEventUpdate | UpdateMode.Blocking;
        public override UpdateMode RequiredUpdateModes => DefaultUpdateMode;

        [Tooltip("The FSM Component to wait for.")]
        [SerializeField]
        private BaseFsmComponentVar _fsmComponent;

        [Tooltip("Optional timeout in seconds. Set to -1 to wait indefinitely.")]
        [SerializeField, DefaultValue(-1f)]
        private FloatVar _timeout;

        [ActionHeader("Output")]
        [WriteOnly, OptionalField]
        [Tooltip("True if the target FSM finished normally.")]
        [SerializeField]
        private BoolRef _storeFinished;

        [WriteOnly, OptionalField]
        [Tooltip("True if this action stopped waiting because the timeout elapsed.")]
        [SerializeField]
        private BoolRef _storeTimedOut;

        private FsmNode _currentFsmNode;
        private Coroutine _timeoutRoutine;

        public override bool CanExecute() => CheckParameters(_fsmComponent, _timeout);

        public override void OnStart()
        {
            SetOutputs(false, false);
            AddCallback();

            if (_fsmComponent.IsVariable)
            {
                _fsmComponent.Variable.ValueChanged += UpdateFsm;
            }

            if (_timeout.Value >= 0)
            {
                _timeoutRoutine = StartCoroutine(TimeoutCoroutine());
            }

            if (HasTargetFinished())
            {
                CompleteFromTarget();
            }
        }

        public override void OnStop()
        {
            if (_timeoutRoutine != null)
            {
                StopCoroutine(_timeoutRoutine);
                _timeoutRoutine = null;
            }

            RemoveCallback();

            if (_fsmComponent.IsVariable)
            {
                _fsmComponent.Variable.ValueChanged -= UpdateFsm;
            }
        }

        private void UpdateFsm()
        {
            AddCallback();

            if (HasTargetFinished())
            {
                CompleteFromTarget();
            }
        }

        public override void Execute() {}

        private bool HasTargetFinished() =>
            _currentFsmNode is { Active: false, HasFinished: true };

        private void CompleteFromTarget()
        {
            if (!HasTargetFinished()) return;

            RemoveCallback();
            _timeoutRoutine = null;
            SetOutputs(true, false);
            Progress = 1f;
            Finish();
        }

        private System.Collections.IEnumerator TimeoutCoroutine()
        {
            if (_timeout.Value > 0)
            {
                yield return new UnityEngine.WaitForSeconds(_timeout.Value);
            }
            else
            {
                yield return null;
            }

            if (!Active || HasTargetFinished()) yield break;

            RemoveCallback();
            _timeoutRoutine = null;
            SetOutputs(false, true);
            Finish();
        }

        private void AddCallback()
        {
            RemoveCallback();

            var value = _fsmComponent.Value;
            _currentFsmNode = value ? value.Fsm : null;
            if (_currentFsmNode == null) return;
            _currentFsmNode.Exited += CompleteFromTarget;
        }

        private void RemoveCallback()
        {
            if (_currentFsmNode == null) return;
            _currentFsmNode.Exited -= CompleteFromTarget;
            _currentFsmNode = null;
        }

        private void SetOutputs(bool finished, bool timedOut)
        {
            if (_storeFinished.IsAssigned) _storeFinished.Value = finished;
            if (_storeTimedOut.IsAssigned) _storeTimedOut.Value = timedOut;
        }

        public override string GetSummary() =>
            "Wait for {_fsmComponent} to finish" +
            (_timeout.Value >= 0 || _timeout.IsVariable ? " Timeout {_timeout:seconds}" : "");
    }
}
