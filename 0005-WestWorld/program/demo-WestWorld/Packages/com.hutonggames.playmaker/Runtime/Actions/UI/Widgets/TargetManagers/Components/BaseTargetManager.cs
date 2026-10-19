using System;
using System.Collections.Generic;
using HutongGames.PlayMaker.Actions;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.UI
{
    /// <summary>
    /// Base class for all managers that spawn UI widgets for world-space targets.
    /// Examples: OffscreenIndicator, OnscreenTargetBrackets, MinimapIcons, etc.
    /// <br/>Handles:
    /// <br/>• Camera reference
    /// <br/>• Icon root for spawned UI
    /// <br/>• Prefab instantiation
    /// <br/>• TargetObject initialization
    /// <br/>• Entry lifetime (remove, auto-cleanup)
    /// <br/>• Calling abstract LayoutEntry() for derived managers
    /// </summary>
    [Icon(Strings.EditorIconsPath + "TargetIndicatorIcon.png")]
    public abstract class BaseTargetManager : MonoBehaviour
    {
        #region Public API

        [PublicAPI]
        public Camera Camera
        {
            get => _camera;
            set => _camera = value;
        }

        [PublicAPI]
        public GameObject DefaultPrefab
        {
            get => _defaultPrefab;
            set => _defaultPrefab = value;
        }
        
        #endregion
        
        // ------------------------------------
        // Serialized fields common to all managers
        // ------------------------------------

        [Tooltip("Camera used to project target positions. Defaults to Camera.main.")]
        [SerializeField]
        protected Camera _camera;

        [FormerlySerializedAs("_iconRoot")]
        [Tooltip("UI root that contains spawned widgets.")]
        [SerializeField]
        protected RectTransform _indicatorPanel;

        [Tooltip("Fallback prefab used when AddTarget does not specify a prefab.")]
        [SerializeField]
        protected GameObject _defaultPrefab;


        // ------------------------------------
        // Entry struct
        // ------------------------------------

        [Serializable]
        protected struct Entry
        {
            public Transform Target;          // world-space target
            public RectTransform Rect;        // spawned UI widget
            public TargetWidget targetWidget; // optional helper component
            public int StyleId;               // user metadata
            public bool IsActive;             // whether manager is using it
        }

        [SerializeField, HideInInspector]
        protected List<Entry> _entries = new();

        public int EntryCount => _entries.Count;
        

        // ------------------------------------
        // Public properties
        // ------------------------------------

        public Camera TargetCamera
        {
            get
            {
                if (_camera == null)
                    _camera = Camera.main;
                return _camera;
            }
        }

        public virtual RectTransform IndicatorPanel
        {
            get => _indicatorPanel;
            set => _indicatorPanel = value;
        }


        // ------------------------------------
        // Unity lifecycle
        // ------------------------------------

        protected virtual void Awake()
        {
            if (_camera == null)
                _camera = Camera.main;
        }

        protected virtual void OnEnable()
        {
            // When re-enabled, we simply resume updating in LateUpdate.
            // We don't clear or recreate entries; indicators pick up where they left off.

            // Optional: force a one-frame refresh if needed.
            // ForceLayoutAll();
        }

        protected virtual void OnDisable()
        {
            // Disabling the manager should PAUSE behavior, not destroy indicators.
            // LateUpdate will early-out when !isActiveAndEnabled, so no extra work is required here.
            //
            // If you want a specific widget (e.g., OffscreenIndicator) to hide indicators
            // while disabled, it can override OnDisable and toggle Rect.activeSelf there.
        }
        
        protected virtual void BeforeLayout(Camera cam)
        {
            // Default: do nothing.
        }
        
        protected virtual void LateUpdate()
        {
            var cam = TargetCamera;
            if (cam == null)
                return;

            if (_indicatorPanel == null)
                return;
            
            BeforeLayout(cam);
            
            for (int i = _entries.Count - 1; i >= 0; i--)
            {
                var entry = _entries[i];

                // Auto-cleanup destroyed targets or UI
                if (entry.Target == null || entry.Rect == null)
                {
                    DestroyEntry(ref entry);
                    _entries.RemoveAt(i);
                    continue;
                }

                if (!entry.IsActive)
                {
                    entry.Rect.gameObject.SetActive(false);
                    _entries[i] = entry;
                    continue;
                }

                LayoutEntry(ref entry, cam);
                _entries[i] = entry;
            }
        }
        
        private static bool _applicationIsQuitting;

        protected virtual void OnDestroy()
        {
            // Avoid doing heavy cleanup when the application is quitting,
            // since scene teardown will destroy objects anyway.
            if (_applicationIsQuitting)
                return;

            // Destroy all spawned indicator instances and clear entries.
            ClearAllTargets();
        }

        private void OnApplicationQuit()
        {
            _applicationIsQuitting = true;
        }

        // ------------------------------------
        // Add / Remove / Clear Targets
        // ------------------------------------

        /// <summary>Adds a target and instantiates a widget.</summary>
        public GameObject AddTarget(Transform target, GameObject prefabOverride = null, int styleId = 0)
        {
            if (target == null || _indicatorPanel == null)
                return null;

            // If already tracked, update instead of spawning a duplicate
            for (int i = 0; i < _entries.Count; i++)
            {
                if (_entries[i].Target == target)
                {
                    var entry = _entries[i];
                    entry.StyleId = styleId;
                    entry.IsActive = true;
                    _entries[i] = entry;
                    return entry.Rect != null ? entry.Rect.gameObject : null;
                }
            }

            var prefab = prefabOverride != null ? prefabOverride : _defaultPrefab;
            if (prefab == null)
                return null;

            var instance = Instantiate(prefab, _indicatorPanel);

            var rect = instance.transform as RectTransform;
            if (rect == null)
            {
                Debug.LogWarning($"{GetType().Name}: Indicator prefab must have a RectTransform root.", this);
                Destroy(instance);
                return null;
            }

            // Attach and initialize TargetObject (if present)
            var targetObj = instance.GetComponent<TargetWidget>();
            if (targetObj != null)
                targetObj.Initialize(this, target, styleId);

            var newEntry = new Entry
            {
                Target       = target,
                Rect         = rect,
                targetWidget = targetObj,
                StyleId      = styleId,
                IsActive     = true
            };

            _entries.Add(newEntry);
            return instance;
        }

        /// <summary>Removes a specific target.</summary>
        public void RemoveTarget(Transform target)
        {
            if (target == null) return;

            for (int i = _entries.Count - 1; i >= 0; i--)
            {
                if (_entries[i].Target == target)
                {
                    var entry = _entries[i];
                    DestroyEntry(ref entry);
                    _entries.RemoveAt(i);
                }
            }
        }

        /// <summary>Removes and destroys all indicators.</summary>
        public void ClearAllTargets()
        {
            for (int i = 0; i < _entries.Count; i++)
            {
                var entry = _entries[i];
                DestroyEntry(ref entry);
            }
            _entries.Clear();
        }


        // ------------------------------------
        // Getters
        // ------------------------------------

        public RectTransform GetIndicatorRect(Transform target)
        {
            if (target == null) return null;

            for (int i = 0; i < _entries.Count; i++)
                if (_entries[i].Target == target)
                    return _entries[i].Rect;

            return null;
        }

        public GameObject GetIndicatorGameObject(Transform target)
        {
            var rect = GetIndicatorRect(target);
            return rect ? rect.gameObject : null;
        }

        protected bool TryGetEntry(Transform target, out Entry entry)
        {
            for (int i = 0; i < _entries.Count; i++)
            {
                if (_entries[i].Target == target)
                {
                    entry = _entries[i];
                    return true;
                }
            }
            entry = default;
            return false;
        }


        // ------------------------------------
        // Abstract layout
        // ------------------------------------

        /// <summary>
        /// Derived classes implement their own projection logic here.
        /// Example: OffscreenIndicator clamps to borders, Minimap projects to local map, etc.
        /// </summary>
        protected abstract void LayoutEntry(ref Entry entry, Camera cam);


        // ------------------------------------
        // Destruction helper
        // ------------------------------------

        protected virtual void DestroyEntry(ref Entry entry)
        {
            if (entry.targetWidget != null)
                entry.targetWidget.OnRemoved();

            if (entry.Rect != null)
                Destroy(entry.Rect.gameObject);

            entry.Target       = null;
            entry.Rect         = null;
            entry.targetWidget = null;
            entry.IsActive     = false;
        }
    }
}
