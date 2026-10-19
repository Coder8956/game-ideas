using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HutongGames.PlayMaker.Actions.SceneManagement
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.SceneManager)]
    [ActionDescription("Loads the Scene asynchronously by its name.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.LoadSceneAsync.html")]
    public sealed class SceneManagerLoadSceneAsyncByName : BaseAction
    {
        public override UpdateMode RequiredUpdateModes => UpdateMode.EveryFrame;
        public override bool CanFinish => true;

        [Tooltip("Name or path of the Scene to load.")]
        [SerializeField]
        private StringVar _sceneName;

        [Tooltip("Various parameters used to load the Scene.")]
        [SerializeField, NoFoldout]
        private LoadSceneParameters _parameters;

        [Tooltip("Store the current loading progress (0-1).")]
        [SerializeField, WriteOnly]
        private FloatRef _storeProgress;
        
        [Tooltip("Event to send when the Scene is loaded.")]
        [SerializeField]
        private EventRef _finishedEvent;
        
        private System.Collections.IEnumerator _loadRoutine;
        private AsyncOperation _asyncOperation;
        private bool _wasStoppedEarly;
        
        public override bool CanExecute() => CheckParameters(_sceneName);

        public override void OnStart()
        {
            _wasStoppedEarly = false;
            if (OwnerFsmComponent != null)
            {
                _loadRoutine = LoadSceneRoutine();
                OwnerFsmComponent.StartCoroutine(_loadRoutine);
            }
            else
            {
                Debug.LogError("SceneManagerLoadSceneAsyncByIndex: OwnerComponent is null!");
            }
        }


        public override void OnStop()
        {
            if (_loadRoutine != null && OwnerFsmComponent != null)
            {
                OwnerFsmComponent.StopCoroutine(_loadRoutine);
                _loadRoutine = null;
            }
        
            _wasStoppedEarly = true;
        }

        private System.Collections.IEnumerator LoadSceneRoutine()
        {
            _asyncOperation = SceneManager.LoadSceneAsync(_sceneName.Value, _parameters);
            if (_asyncOperation == null) yield break;

            while (!_asyncOperation.isDone)
            {
                if (_storeProgress.IsAssigned)
                {
                    _storeProgress.Value = _asyncOperation.progress;
                }
                yield return null;
            }

            if (!_wasStoppedEarly && _finishedEvent.IsSet)
            {
                SendEvent(_finishedEvent);
            }
        
            Finish();
        }


		public override string GetSummary() => "Load scene {_sceneName} async";
    }
}
