using System;
using HutongGames.Editor;
using HutongGames.PlayMaker.Actions;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.Editor
{
    /// <summary>
    /// Debug FsmInfo contents
    /// </summary>
    [Serializable]
    [EditorWindowTitle(title = WindowTitle)]
    public class ObjectPoolInspector : EditorWindow
    {
        private const string WindowTitle = "Object Pools";
        
        private const string UssGuid = "6e5907d1ab064167a434f53f6aff2551";
        private const string UssClassName = "hutong-object-pool-inspector";
        private const string PoolCountUssClassName = UssClassName + "__pool-count";
        private const string EmptyHintUssClassName = UssClassName + "__empty-hint";
        
       
        /// <summary>
        /// Open an FSM Info Window.
        /// If the current Unity selection has an Fsm, its info is automatically selected.
        /// </summary>
        [MenuItem(PlayMakerMenu.ObjectPoolInspector, false, PlayMakerMenu.ObjectPoolInspectorPriority)]
        public static void Open() => GetWindow<ObjectPoolInspector>();

        private void OnEnable()
        {
            titleContent = new GUIContent(WindowTitle, Icons.PlayMakerWindowIcon);
            
            ObjectPoolManager.Changed -= UpdateUI;
            ObjectPoolManager.Changed += UpdateUI;
            SceneManager.sceneLoaded -= OnSceneLoaded;
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.activeSceneChanged -= OnActiveSceneChanged;
            SceneManager.activeSceneChanged += OnActiveSceneChanged;
        }

        private void OnDisable()
        {
            ObjectPoolManager.Changed -= UpdateUI;
            SceneManager.sceneLoaded -= OnSceneLoaded;
            SceneManager.activeSceneChanged -= OnActiveSceneChanged;
        }

        protected virtual void CreateGUI()
        {
            var root = rootVisualElement;
            root.Clear();
            root.AddToClassList(UssClassName);
            UITK.LoadStyleSheet(root, UssGuid);
            
            if (!EditorApplication.isPlaying)
            {
                AddEmptyHint();
                return;
            }
            
            var poolCount = new Label("Pools: " + ObjectPoolManager.PoolCount);
            poolCount.AddToClassList(PoolCountUssClassName);
            root.Add(poolCount);
            
            var scrollView = new ScrollView();
            root.Add(scrollView);
            
            foreach (var objectPool in ObjectPoolManager.Pools)
            {
                scrollView.Add(new ObjectPoolItem(objectPool));
            }
        }

        private void AddEmptyHint()
        {
            var hint = new Label("Object Pools are only created while the game is running.");
            hint.AddToClassList(EmptyHintUssClassName);
            rootVisualElement.Add(hint);
        }
        
        private void UpdateUI()
        {
            if (rootVisualElement == null) return;
            CreateGUI();
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            UpdateUI();
        }

        private void OnActiveSceneChanged(Scene previousScene, Scene newScene)
        {
            UpdateUI();
        }
        
    }
}
