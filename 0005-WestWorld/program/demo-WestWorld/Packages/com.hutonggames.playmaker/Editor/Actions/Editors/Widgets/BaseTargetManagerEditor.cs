using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.UI.Editor
{
    /// <summary>
    /// Base editor for all TargetManager-derived widgets.
    /// Handles common fields (Camera, IndicatorPanel, DefaultPrefab)
    /// and the runtime debug target list.
    /// </summary>
    public abstract class BaseTargetManagerEditor<T> : UnityEditor.Editor
        where T : BaseTargetManager
    {
        // Common BaseTargetManager fields
        // ReSharper disable InconsistentNaming
        protected SerializedProperty _cameraProp;
        protected SerializedProperty _indicatorPanelProp;
        protected SerializedProperty _defaultPrefabProp;
        // ReSharper restore InconsistentNaming

        // Debug UI
        private Box _debugBox;
        private ListView _debugList;
        private Label _debugHeader;
        private readonly List<DebugEntry> _debugEntries = new();

        // Reflection into BaseTargetManager._entries + Entry struct
        private FieldInfo _entriesField;
        private FieldInfo _entryTarget;
        private FieldInfo _entryRect;
        private FieldInfo _entryStyleId;
        private FieldInfo _entryIsActive;

        protected virtual void OnEnable()
        {
            _cameraProp         = serializedObject.FindProperty("_camera");
            _indicatorPanelProp = serializedObject.FindProperty("_indicatorPanel");
            _defaultPrefabProp  = serializedObject.FindProperty("_defaultPrefab");

            CacheReflection();
            EditorApplication.update += UpdateDebugList;
        }

        protected virtual void OnDisable()
        {
            EditorApplication.update -= UpdateDebugList;
        }

        public override VisualElement CreateInspectorGUI()
        {
            serializedObject.Update();

            var root = new VisualElement
            {
                style =
                {
                    paddingTop    = 4,
                    paddingBottom = 4
                }
            };

            // Let subclasses build their main UI
            BuildInspectorGUI(root);

            // Add shared debug UI
            CreateDebugUI(root);

            root.Bind(serializedObject);
            UpdateDebugHeader();

            return root;
        }

        /// <summary>
        /// Subclasses implement this to build their main inspector layout
        /// using _cameraProp, _indicatorPanelProp, _defaultPrefabProp,
        /// and their own SerializedProperties.
        /// </summary>
        protected abstract void BuildInspectorGUI(VisualElement root);

        /// <summary>
        /// Override to customize the debug header text.
        /// </summary>
        protected virtual string DebugHeaderText => "Targets appear in Play Mode.";

        // --- Debug UI creation ---

        private void CreateDebugUI(VisualElement root)
        {
            _debugBox = new Box
            {
                style =
                {
                    marginTop    = 8,
                    paddingLeft  = 4,
                    paddingRight = 4,
                    paddingTop   = 4,
                    paddingBottom= 4
                }
            };

            _debugHeader = new Label(DebugHeaderText)
            {
                style =
                {
                    unityFontStyleAndWeight = FontStyle.Bold,
                    marginBottom            = 4
                }
            };
            _debugBox.Add(_debugHeader);

            _debugList = new ListView
            {
                itemsSource           = _debugEntries,
                selectionType         = SelectionType.None,
                virtualizationMethod  = CollectionVirtualizationMethod.FixedHeight,
                style =
                {
                    maxHeight = 160,
                    marginTop = 2
                }
            };

            _debugList.makeItem = MakeDebugItem;
            _debugList.bindItem = BindDebugItem;

            _debugBox.Add(_debugList);
            root.Add(_debugBox);
        }

        private VisualElement MakeDebugItem()
        {
            var row = new VisualElement
            {
                style =
                {
                    flexDirection = FlexDirection.Row,
                    alignItems    = Align.Center
                }
            };

            var targetField = new ObjectField
            {
                name       = "TargetField",
                objectType = typeof(Transform),
                style =
                {
                    flexGrow   = 1,
                    marginRight= 24
                }
            };
            targetField.SetEnabled(false);

            var infoLabel = new Label { name = "InfoLabel" };

            row.Add(targetField);
            row.Add(infoLabel);
            return row;
        }

        private void BindDebugItem(VisualElement element, int index)
        {
            if (index < 0 || index >= _debugEntries.Count)
                return;

            var entry      = _debugEntries[index];
            var targetField= element.Q<ObjectField>("TargetField");
            var infoLabel  = element.Q<Label>("InfoLabel");

            if (targetField != null)
                targetField.value = entry.Target;

            if (infoLabel != null)
            {
                var uiName    = Name(entry.Rect);
                var activeStr = entry.IsActive ? "Active" : "Inactive";
                infoLabel.text = $"UI={uiName}, Style={entry.StyleId}, {activeStr}";
            }
        }

        // --- Debug data / reflection ---

        private struct DebugEntry
        {
            public Transform     Target;
            public RectTransform Rect;
            public int           StyleId;
            public bool          IsActive;
        }

        private void CacheReflection()
        {
            // _entries is defined in BaseTargetManager
            var baseType = typeof(BaseTargetManager);

            _entriesField = baseType.GetField("_entries",
                BindingFlags.Instance | BindingFlags.NonPublic);
            if (_entriesField == null)
                return;

            var entryListType = _entriesField.FieldType;
            var genericArgs   = entryListType.IsGenericType
                ? entryListType.GetGenericArguments()
                : null;

            if (genericArgs == null || genericArgs.Length != 1)
                return;

            var entryType = genericArgs[0];

            _entryTarget   = entryType.GetField("Target",   BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            _entryRect     = entryType.GetField("Rect",     BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            _entryStyleId  = entryType.GetField("StyleId",  BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            _entryIsActive = entryType.GetField("IsActive", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        }

        private void UpdateDebugList()
        {
            if (_debugList == null)
                return;

            if (!Application.isPlaying)
            {
                _debugEntries.Clear();
                _debugList.RefreshItems();
                UpdateDebugHeader();
                return;
            }

            var manager = target as T;
            if (manager == null || _entriesField == null)
            {
                _debugEntries.Clear();
                _debugList.RefreshItems();
                UpdateDebugHeader();
                return;
            }

            var listObj = _entriesField.GetValue(manager) as IList;
            _debugEntries.Clear();

            if (listObj != null)
            {
                for (int i = 0; i < listObj.Count; i++)
                {
                    var entryObj = listObj[i];
                    if (entryObj == null) continue;

                    _debugEntries.Add(new DebugEntry
                    {
                        Target   = (Transform)     _entryTarget  .GetValue(entryObj),
                        Rect     = (RectTransform) _entryRect    .GetValue(entryObj),
                        StyleId  = (int)           _entryStyleId .GetValue(entryObj),
                        IsActive = (bool)          _entryIsActive.GetValue(entryObj),
                    });
                }
            }

            _debugList.RefreshItems();
            UpdateDebugHeader();
        }

        private void UpdateDebugHeader()
        {
            if (_debugHeader == null) return;

            _debugHeader.text = !Application.isPlaying
                ? DebugHeaderText
                : $"{DebugHeaderText} ({_debugEntries.Count})";
        }

        protected static Label Header(string text) =>
            new Label(text)
            {
                style =
                {
                    unityFontStyleAndWeight = FontStyle.Bold,
                    marginLeft = 3,
                    marginBottom = 2,
                    marginTop    = 6
                }
            };

        private static string Name(Object o) => o != null ? o.name : "<null>";
    }
}
