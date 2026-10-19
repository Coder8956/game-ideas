using System;
using System.Collections;
using System.Collections.Generic;
using HutongGames.PlayMaker.Actions;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.UI
{
    [AddComponentMenu("PlayMaker/Widgets/Animated List")]
    [Icon(Strings.EditorIconsPath + "AnimatedListIcon.png")]
    [HelpURL("https://hutonggames.com/playmaker/docs/guides/ui-widgets/animated-list/")]
    public class AnimatedList : MonoBehaviour
    {
        public event Action<GameObject> FinishedInsert;
        
        public enum ItemSizeMode
        {
            PreferredSize,
            LayoutElement,
            Fixed
        }

        [Serializable]
        public struct ItemAnimationSettings
        {
            [Tooltip("Animation timing settings.")]
            public AnimationSettings Timing;

            [Tooltip("Fade item visuals while animating.")]
            public bool Fade;

            public static ItemAnimationSettings Default => new()
            {
                Timing = AnimationSettings.Default,
                Fade = true
            };
        }

        [Header("References")]
        [SerializeField]
        [Tooltip("Parent that holds list item hosts (should have a VerticalLayoutGroup or HorizontalLayoutGroup).")]
        private RectTransform _content;

        [SerializeField]
        [Tooltip("Item prefab to instantiate as content under a host.")]
        private GameObject _itemPrefab;

        [SerializeField]
        [Tooltip("Host prefab (must have AnimatedListItemHost). If null, a default host GameObject is created.")]
        private AnimatedListItemHost _hostPrefab;

        [Header("Item Size")]
        [SerializeField]
        [Tooltip(
            "How the item size is determined along the list axis (height for vertical lists, width for horizontal lists):\n\n" +
            "• <b>Preferred Size</b> – Uses the size calculated from the item's content (text, images, layout groups).\n\n" +
            "• <b>Layout Element</b> – Uses the size explicitly set on the item's LayoutElement component.\n\n" +
            "• <b>Fixed</b> – Uses a constant size for all items."
        )]
        private ItemSizeMode _itemSizeMode = ItemSizeMode.LayoutElement;

        [SerializeField]
        [Tooltip("Used when ItemSizeMode is Fixed or if size cannot be measured.")]
        private float _fixedItemSize = 60f;

        [SerializeField]
        [Tooltip("If true, the spawned item root RectTransform is set to stretch-fill inside the host.")]
        private bool _stretchItemToFillHost = true;

        [Header("Animation")]
        [SerializeField]
        [Tooltip("Default animation used when inserting items.")]
        private ItemAnimationSettings _defaultInsertAnimation = ItemAnimationSettings.Default;

        [SerializeField]
        [Tooltip("Default animation used when removing items. Also used to close the gap when an item destroys itself (self-delete).")]
        private ItemAnimationSettings _defaultRemoveAnimation = ItemAnimationSettings.Default;

        [Header("Lifetime")]
        [SerializeField]
        [Tooltip("If true, RemoveItem destroys the host GameObject. If false, it deactivates it.")]
        private bool _destroyOnRemove = true;
        
        [SerializeField]
        [Tooltip("Maximum number of items to keep (0 = unlimited). Oldest items are removed first.")]
        private int _maxCount;

        [SerializeField]
        [Tooltip("Maximum age in seconds before an item is removed (<= 0 = disabled). Uses unscaled time.")]
        private float _maxAge;

        private readonly List<AnimatedListItemHost> _hosts = new(128);
        private readonly Dictionary<GameObject, Coroutine> _running = new(256);

        public RectTransform Content => _content;
        public GameObject ItemPrefab => _itemPrefab;

        public ItemAnimationSettings DefaultInsertAnimation
        {
            get => _defaultInsertAnimation.Timing.Duration <= 0f ? ItemAnimationSettings.Default : _defaultInsertAnimation;
            set => _defaultInsertAnimation = value;
        }

        public ItemAnimationSettings DefaultRemoveAnimation
        {
            get => _defaultRemoveAnimation.Timing.Duration <= 0f ? ItemAnimationSettings.Default : _defaultRemoveAnimation;
            set => _defaultRemoveAnimation = value;
        }

        public IReadOnlyList<AnimatedListItemHost> Hosts => _hosts;

        private void Awake()
        {
            if (_defaultInsertAnimation.Timing.Duration <= 0f)
            {
                _defaultInsertAnimation = ItemAnimationSettings.Default;
            }

            if (_defaultRemoveAnimation.Timing.Duration <= 0f)
            {
                _defaultRemoveAnimation = ItemAnimationSettings.Default;
            }

            RebuildHostCache();
        }
        
        private float _nextAgeSweepTime;
        
        private void Update()
        {
            if (_maxAge <= 0f) return;

            var now = Time.unscaledTime;
            if (now < _nextAgeSweepTime) return;

            _nextAgeSweepTime = now + 0.25f;

            while (_hosts.Count > 0)
            {
                var host = _hosts[0];
                if (host == null)
                {
                    _hosts.RemoveAt(0);
                    continue;
                }

                var age = now - host.CreatedUnscaledTime;
                if (age < _maxAge) break;

                RemoveItemAt(0);
            }
        }

        private void OnDisable()
        {
            foreach (var kvp in _running)
            {
                if (kvp.Value != null)
                {
                    StopCoroutine(kvp.Value);
                }
            }

            _running.Clear();
        }

        public void RebuildHostCache()
        {
            _hosts.Clear();

            if (_content == null)
            {
                return;
            }

            for (var i = 0; i < _content.childCount; i++)
            {
                var host = _content.GetChild(i).GetComponent<AnimatedListItemHost>();
                if (host != null)
                {
                    if (host.CreatedUnscaledTime <= 0f)
                    {
                        host.MarkCreatedNow();
                    }
                    
                    _hosts.Add(host);

                    // Ensure existing hosts follow the current self-delete gap close timing.
                    ApplyHostDefaults(host);
                }
            }
        }

        // -------------------------
        // Public API: Insert
        // -------------------------

        public GameObject AddItem(GameObject prefabOverride, ItemAnimationSettings anim)
        {
            return InsertItem(_hosts.Count, prefabOverride, anim);
        }

        public GameObject InsertItem(int index, GameObject prefabOverride, ItemAnimationSettings anim)
        {
            if (_content == null)
            {
                Debug.LogWarning($"{nameof(AnimatedList)}: Content is not assigned.", this);
                return null;
            }

            var prefab = prefabOverride != null ? prefabOverride : _itemPrefab;
            if (prefab == null)
            {
                Debug.LogWarning($"{nameof(AnimatedList)}: Item prefab is not assigned.", this);
                return null;
            }

            var clampedIndex = Mathf.Clamp(index, 0, _hosts.Count);

            var host = CreateHost();
            var hostRt = (RectTransform)host.transform;
            hostRt.SetParent(_content, false);
            hostRt.SetSiblingIndex(ResolveSiblingIndexForHostIndex(clampedIndex));

            // Apply defaults that affect behavior even when content self-deletes later.
            ApplyHostDefaults(host);

            var itemGo = Instantiate(prefab);
            var itemRt = itemGo.transform as RectTransform;
            if (itemRt == null)
            {
                itemRt = itemGo.AddComponent<RectTransform>();
            }

            host.Attach(itemRt, _stretchItemToFillHost);
            host.PrepareHidden();

            _hosts.Insert(clampedIndex, host);
            EnforceMaxCount();

            TrackRoutine(host.gameObject, InsertSequence(host, itemRt, itemGo, anim));

            return itemGo;
        }
        
        public GameObject AddExistingItem(GameObject itemInstance, ItemAnimationSettings anim)
        {
            return InsertExistingItem(_hosts.Count, itemInstance, anim);
        }

        public GameObject InsertExistingItem(int index, GameObject itemInstance, ItemAnimationSettings anim)
        {
            if (_content == null)
            {
                Debug.LogWarning($"{nameof(AnimatedList)}: Content is not assigned.", this);
                return null;
            }

            if (itemInstance == null)
            {
                Debug.LogWarning($"{nameof(AnimatedList)}: Item instance is null.", this);
                return null;
            }

            var itemRt = itemInstance.transform as RectTransform;
            if (itemRt == null)
            {
                Debug.LogWarning($"{nameof(AnimatedList)}: Item instance must have a RectTransform.", this);
                return null;
            }

            var clampedIndex = Mathf.Clamp(index, 0, _hosts.Count);

            var host = CreateHost();
            var hostRt = (RectTransform)host.transform;
            hostRt.SetParent(_content, false);
            hostRt.SetSiblingIndex(ResolveSiblingIndexForHostIndex(clampedIndex));

            ApplyHostDefaults(host);

            // IMPORTANT: ensure the instance is active so layout can measure correctly.
            // (If you want to support inactive instances, you can temporarily activate for 1 frame.)
            itemInstance.SetActive(true);

            host.Attach(itemRt, _stretchItemToFillHost);
            host.PrepareHidden();

            _hosts.Insert(clampedIndex, host);

            TrackRoutine(host.gameObject, InsertSequence(host, itemRt, itemInstance, anim));

            return itemInstance;
        }
        
        private void EnforceMaxCount()
        {
            if (_maxCount <= 0) return;

            while (_hosts.Count > _maxCount)
            {
                // Oldest-first => index 0
                RemoveItemAt(0); // uses your default remove animation
            }
        }

        private IEnumerator InsertSequence(AnimatedListItemHost host, RectTransform itemRt, GameObject itemGo, ItemAnimationSettings anim)
        {
            // Wait 1 frame so any internal layout/text can settle before measuring.
            yield return null;

            if (host == null || itemRt == null || itemGo == null)
            {
                yield break;
            }

            var size = ResolveItemSize(itemRt);
            host.SetExpandedSize(size);

            host.Fade = anim.Fade;
            host.AnimateIn(anim.Timing);

            yield return WaitFor(anim.Timing);

            if (itemGo != null)
            {
                FinishedInsert?.Invoke(itemGo);
            }
        }

        // -------------------------
        // Public API: Remove
        // -------------------------

        public bool RemoveItem(GameObject item)
        {
            if (item == null) return false;
            
            var index = _hosts.FindIndex(host => host != null && host.Content != null && host.Content.gameObject == item);
            if (index < 0) return false;
            
            RemoveItemAt(index);
            return true;
        }
        
        
        public bool RemoveItem(GameObject item, ItemAnimationSettings anim)
        {
            if (item == null) return false;
            
            var index = _hosts.FindIndex(host => host != null && host.Content != null && host.Content.gameObject == item);
            if (index < 0) return false;
            
            RemoveItemAt(index, anim);
            return true;
        }
        
        public void RemoveItemAt(int index)
        {
            RemoveItemAt(index, DefaultRemoveAnimation);
        }

        public void RemoveItemAt(int index, ItemAnimationSettings anim)
        {
            if (index < 0 || index >= _hosts.Count)
            {
                return;
            }

            var host = _hosts[index];
            _hosts.RemoveAt(index);

            if (host == null)
            {
                return;
            }

            TrackRoutine(host.gameObject, RemoveSequence(host, anim));
        }

        private IEnumerator RemoveSequence(AnimatedListItemHost host, ItemAnimationSettings anim)
        {
            if (host == null)
            {
                yield break;
            }

            var item = host.Content != null ? host.Content.gameObject : null;

            host.Fade = anim.Fade;
            host.AnimateOutAndDestroy(anim.Timing);

            yield return WaitFor(anim.Timing);

            if (!_destroyOnRemove)
            {
                if (item != null)
                {
                    item.SetActive(false);
                }
            }
        }

        // -------------------------
        // Size policy
        // -------------------------

        private float ResolveItemSize(RectTransform itemRt)
        {
            if (itemRt == null)
            {
                return Mathf.Max(1f, _fixedItemSize);
            }

            var horizontal = _content != null && _content.GetComponent<HorizontalLayoutGroup>() != null;

            switch (_itemSizeMode)
            {
                case ItemSizeMode.Fixed:
                    return Mathf.Max(1f, _fixedItemSize);

                case ItemSizeMode.LayoutElement:
                {
                    var le = itemRt.GetComponent<LayoutElement>();
                    if (le != null)
                    {
                        var v = horizontal ? le.preferredWidth : le.preferredHeight;
                        if (!(v > 0f))
                        {
                            v = horizontal ? le.minWidth : le.minHeight;
                        }

                        if (v > 0f)
                        {
                            return v;
                        }
                    }

                    return Mathf.Max(1f, _fixedItemSize);
                }

                default: // PreferredSize
                {
                    LayoutRebuilder.ForceRebuildLayoutImmediate(itemRt);

                    var v = horizontal ? LayoutUtility.GetPreferredWidth(itemRt) : LayoutUtility.GetPreferredHeight(itemRt);
                    if (v > 0f && !float.IsNaN(v) && !float.IsInfinity(v))
                    {
                        return v;
                    }

                    v = horizontal ? itemRt.rect.width : itemRt.rect.height;
                    if (v > 0f)
                    {
                        return v;
                    }

                    return Mathf.Max(1f, _fixedItemSize);
                }
            }
        }

        // -------------------------
        // Helpers
        // -------------------------

        private void ApplyHostDefaults(AnimatedListItemHost host)
        {
            if (host == null)
            {
                return;
            }

            // Key: make self-delete gap close timing match the list's remove default.
            // (So if content destroys itself, host collapses using the same timing as RemoveItemAt)
            host.MissingContentAnimation = DefaultRemoveAnimation.Timing;
            host.Destroyed -= OnHostDestroyed;
            host.Destroyed += OnHostDestroyed;
        }

        private AnimatedListItemHost CreateHost()
        {
            AnimatedListItemHost host;

            if (_hostPrefab != null)
            {
                host = Instantiate(_hostPrefab);
            }
            else
            {
                var go = new GameObject("AnimatedListItemHost", typeof(RectTransform), typeof(LayoutElement), typeof(AnimatedListItemHost));
                go.hideFlags = HideFlags.DontSave;
                host = go.GetComponent<AnimatedListItemHost>();
            }

            host.MarkCreatedNow();
            ApplyHostDefaults(host);
            return host;
        }

        private int ResolveSiblingIndexForHostIndex(int hostIndex)
        {
            if (_content == null)
            {
                return 0;
            }

            if (hostIndex >= _hosts.Count)
            {
                return _content.childCount;
            }

            var nextHost = _hosts[hostIndex];
            if (nextHost == null)
            {
                return _content.childCount;
            }

            return nextHost.transform.GetSiblingIndex();
        }

        private IEnumerator WaitFor(AnimationSettings timing)
        {
            var seconds = timing.Duration;
            if (seconds <= 0f)
            {
                yield break;
            }

            var t = 0f;
            while (t < seconds)
            {
                t += timing.UseUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime;
                yield return null;
            }
        }

        private void TrackRoutine(GameObject go, IEnumerator sequence)
        {
            if (go == null || sequence == null)
            {
                return;
            }

            if (_running.TryGetValue(go, out var existing) && existing != null)
            {
                StopCoroutine(existing);
            }

            _running[go] = StartCoroutine(RunTracked(go, sequence));
        }

        private IEnumerator RunTracked(GameObject go, IEnumerator sequence)
        {
            yield return sequence;

            if (go != null)
            {
                _running.Remove(go);
            }
        }

        private void OnHostDestroyed(AnimatedListItemHost host)
        {
            if (host == null)
            {
                return;
            }

            host.Destroyed -= OnHostDestroyed;
            _hosts.Remove(host);

            var go = host.gameObject;
            if (go == null)
            {
                return;
            }

            if (_running.TryGetValue(go, out var routine) && routine != null)
            {
                StopCoroutine(routine);
            }

            _running.Remove(go);
        }
    }
}
