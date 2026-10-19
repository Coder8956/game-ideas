using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HutongGames.PlayMaker.Actions.SceneManagement
{
    [Serializable]
    [ActionCategory(Category.SceneManager)]
    [ActionDescription(
        "Preloads a Scene asynchronously by its index in Build Settings without activating it. " +
        "Sets a Ready flag when preloading is complete, then waits for an Activate flag to activate the Scene.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.LoadSceneAsync.html")]
    public sealed class SceneManagerPreloadSceneByIndex : BaseAction
    {
        public override UpdateMode RequiredUpdateModes => UpdateMode.EveryFrame;
        public override bool CanFinish => true;

        [Tooltip("Index of the Scene in the Build Settings to preload.")]
        [SerializeField]
        private IntegerVar _sceneBuildIndex;

        [Tooltip("Various parameters used to load the Scene.")]
        [SerializeField, NoFoldout]
        private LoadSceneParameters _parameters;

        [Tooltip("Store the current loading/activation progress (0-1). " +
                 "During preloading this typically goes up to 0.9.")]
        [SerializeField, WriteOnly]
        private FloatRef _storeProgress;

        [Header("Ready / Activate Flags")]

        [Tooltip("Set to true when this Scene has finished preloading (ready to activate).")]
        [SerializeField, WriteOnly]
        private BoolRef _readyFlag;

        [Tooltip("When this flag is set to true (by other actions), the preloaded Scene will be activated.")]
        [SerializeField]
        private BoolRef _activateFlag;

        [Header("Events")]

        [Tooltip("Event to send when the Scene has finished preloading (ReadyFlag set to true).")]
        [SerializeField]
        private EventRef _readyEvent;

        [Tooltip("Event to send when the Scene has fully activated.")]
        [SerializeField]
        private EventRef _activatedEvent;

        private System.Collections.IEnumerator _routine;
        private AsyncOperation _asyncOperation;
        private bool _wasStoppedEarly;

        public override bool CanExecute() => CheckParameters(_sceneBuildIndex);

        public override void OnStart()
        {
            _wasStoppedEarly = false;

            // Reset ready flag on start so it's only true when we're actually ready.
            if (_readyFlag.IsAssigned)
            {
                _readyFlag.Value = false;
            }

            if (OwnerFsmComponent != null)
            {
                _routine = PreloadAndActivateRoutine();
                OwnerFsmComponent.StartCoroutine(_routine);
            }
            else
            {
                Debug.LogError("SceneManagerPreloadAndActivateByIndex: OwnerFsmComponent is null!");
                Finish();
            }
        }

        public override void OnStop()
        {
            if (_routine != null && OwnerFsmComponent != null)
            {
                OwnerFsmComponent.StopCoroutine(_routine);
                _routine = null;
            }

            _wasStoppedEarly = true;

            // NOTE: We intentionally DO NOT change allowSceneActivation here.
            // If the state is exited early, the Scene stays in whatever state it was in.
            // If you prefer a fail-safe, you could set allowSceneActivation = true here.
        }

        private System.Collections.IEnumerator PreloadAndActivateRoutine()
        {
            _asyncOperation = SceneManager.LoadSceneAsync(_sceneBuildIndex.Value, _parameters);
            if (_asyncOperation == null)
            {
                Debug.LogError($"SceneManagerPreloadAndActivateByIndex: Failed to start async load for index {_sceneBuildIndex.Value}.");
                Finish();
                yield break;
            }

            // PRELOAD PHASE
            _asyncOperation.allowSceneActivation = false;

            while (_asyncOperation.progress < 0.9f)
            {
                if (_storeProgress.IsAssigned)
                {
                    _storeProgress.Value = _asyncOperation.progress;
                }

                if (_wasStoppedEarly)
                {
                    Finish();
                    yield break;
                }

                yield return null;
            }

            // One last progress update at "ready"
            if (_storeProgress.IsAssigned)
            {
                _storeProgress.Value = _asyncOperation.progress;
            }

            if (_readyFlag.IsAssigned)
            {
                _readyFlag.Value = true;
            }

            if (!_wasStoppedEarly && _readyEvent.IsSet)
            {
                SendEvent(_readyEvent);
            }

            // ACTIVATION WAIT PHASE
            // Wait until ActivateFlag is set true (by other actions / states).
            while (!_activateFlag.Value)
            {
                if (_wasStoppedEarly)
                {
                    Finish();
                    yield break;
                }

                yield return null;
            }

            // ACTIVATE PHASE
            _asyncOperation.allowSceneActivation = true;

            // Optional: wait until the Scene has fully activated
            while (!_asyncOperation.isDone)
            {
                if (_storeProgress.IsAssigned)
                {
                    _storeProgress.Value = _asyncOperation.progress;
                }

                if (_wasStoppedEarly)
                {
                    Finish();
                    yield break;
                }

                yield return null;
            }

            if (_storeProgress.IsAssigned)
            {
                _storeProgress.Value = _asyncOperation.progress;
            }

            if (!_wasStoppedEarly && _activatedEvent.IsSet)
            {
                SendEvent(_activatedEvent);
            }

            Finish();
        }

        public override string GetSummary() =>
            "Preload scene {_sceneBuildIndex} and wait for {_activateFlag}";
    }
}
