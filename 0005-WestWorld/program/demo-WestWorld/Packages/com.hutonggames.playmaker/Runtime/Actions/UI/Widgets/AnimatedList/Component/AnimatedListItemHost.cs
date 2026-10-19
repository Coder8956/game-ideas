using System.Collections;
using HutongGames.PlayMaker.Actions;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.UI
{
    /// <summary>
    /// Wrapper used by AnimatedListWidget.
    /// Owns the LayoutElement that animates space in a LayoutGroup.
    /// Optionally fades the entire host (CanvasGroup on the host).
    /// Detects when its content is destroyed and collapses itself.
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(LayoutElement))]
    [Icon(Strings.EditorIconsPath + "AnimatedListIcon.png")]
    [HelpURL("https://hutonggames.com/playmaker/docs/guides/ui-widgets/animated-list/")]
    public sealed class AnimatedListItemHost : MonoBehaviour
    {
        public event System.Action<AnimatedListItemHost> Destroyed;

        public enum Axis
        {
            Auto,
            Vertical,
            Horizontal
        }
        
        public AnimationSettings MissingContentAnimation
        {
            get => _missingContentAnimation.Duration <= 0f ? AnimationSettings.Default : _missingContentAnimation;
            set => _missingContentAnimation = value;
        }

        public bool Fade
        {
            get => _fade;
            set
            {
                if (_fade == value)
                {
                    return;
                }

                _fade = value;

                Cache();

                // Invariant: fade off => fully visible.
                if (!_fade && _canvasGroup != null)
                {
                    _canvasGroup.alpha = 1f;
                }
            }
        }

        private RectTransform _rt;
        private LayoutElement _layoutElement;
        private CanvasGroup _canvasGroup;
        private RectMask2D _rectMask;

        [SerializeField]
        [Tooltip("Axis to animate. Auto detects from the nearest parent LayoutGroup.")]
        private Axis _axis = Axis.Auto;

        [SerializeField]
        [Tooltip("If true, locks min size to preferred size while animating.")]
        private bool _lockMinToPreferred = true;

        [SerializeField]
        [Tooltip("If true, fades the host while animating.")]
        private bool _fade = true;

        [SerializeField]
        [Tooltip("If true, adds a CanvasGroup on the host automatically.")]
        private bool _autoAddCanvasGroup = true;

        [SerializeField]
        [Tooltip("If true, adds a RectMask2D on the host so children are clipped to the animated rect.")]
        private bool _clipChildren = true;

        [SerializeField]
        [Tooltip("If true, when the hosted content is destroyed this host collapses with an animation instead of popping out.")]
        private bool _animateWhenContentMissing = true;

        [SerializeField]
        [Tooltip("Animation used when content is destroyed (self-delete). If Duration is <= 0, AnimationSettings.Default is used.")]
        private AnimationSettings _missingContentAnimation;
        
        private Axis _resolvedAxis;
        private LayoutGroup _parentLayoutGroup;
        private RectTransform _layoutRootRect;

        private RectTransform _content;
        private Coroutine _routine;

        private float _expandedSize = -1f;
        private bool _collapseQueued;

        public RectTransform Content => _content;
        public float ExpandedSize => _expandedSize;

        public float CreatedUnscaledTime { get; private set; }

        public void MarkCreatedNow()
        {
            CreatedUnscaledTime = Time.unscaledTime;
        }
        
        private void Awake()
        {
            Cache();
        }

        private void OnEnable()
        {
            Cache();
            ResolveLayoutChain();
            EnsureCanvasGroupOnHostIfNeeded();
            EnsureClipBinding();
            ForceVisibleIfNoFade();
            _collapseQueued = false;
        }

        private void OnDisable()
        {
            if (_routine != null)
            {
                StopCoroutine(_routine);
                _routine = null;
            }
        }

        private void OnDestroy()
        {
            Destroyed?.Invoke(this);
        }

        private void LateUpdate()
        {
            // If the hosted content disappears (destroyed), smoothly close the gap.
            if (_content != null) return;
            
            if (_collapseQueued) return;
            
            _collapseQueued = true;

            if (!isActiveAndEnabled || !gameObject.activeInHierarchy)
            {
                SetSizeImmediate(0f);
                Destroy(gameObject);
                return;
            }

            if (!_animateWhenContentMissing)
            {
                SetSizeImmediate(0f);
                Destroy(gameObject);
                return;
            }

            var anim = _missingContentAnimation.Duration > 0f ? _missingContentAnimation : AnimationSettings.Default;
            StartCollapseAndDestroy(anim);
        }

        /// <summary>
        /// Attach content as a direct child. Optionally stretch-fill into this host rect.
        /// </summary>
        public void Attach(RectTransform content, bool stretchFill = true)
        {
            Cache();

            _content = content;

            if (_content != null)
            {
                _content.SetParent(_rt, false);

                if (stretchFill)
                {
                    SetupChildStretchFill(_content);
                }
            }

            ResolveLayoutChain();
            EnsureCanvasGroupOnHostIfNeeded();
            EnsureClipBinding();
            ForceVisibleIfNoFade();
        }

        public void SetExpandedSize(float size)
        {
            _expandedSize = Mathf.Max(0f, size);
        }

        public void PrepareHidden()
        {
            Cache();
            ResolveLayoutChain();
            EnsureCanvasGroupOnHostIfNeeded();
            EnsureClipBinding();

            SetSizeImmediate(0f);

            if (_fade && _canvasGroup != null)
            {
                _canvasGroup.alpha = 0f;
            }
            else
            {
                ForceVisibleIfNoFade();
            }

            RebuildIfNeeded();
        }

        public void AnimateIn(AnimationSettings anim)
        {
            Cache();
            ResolveLayoutChain();
            EnsureCanvasGroupOnHostIfNeeded();
            EnsureClipBinding();

            if (_expandedSize < 0f)
            {
                _expandedSize = 0f;
            }

            float fromAlpha = _fade ? 0f : 1f;
            StartAnimation(0f, _expandedSize, fromAlpha, 1f, anim, destroyAtEnd: false);
        }

        public void AnimateOutAndDestroy(AnimationSettings anim)
        {
            Cache();
            ResolveLayoutChain();
            EnsureCanvasGroupOnHostIfNeeded();
            EnsureClipBinding();

            StartCollapseAndDestroy(anim);
        }

        private void StartCollapseAndDestroy(AnimationSettings anim)
        {
            float startSize = GetCurrentSize();
            float startAlpha = _fade && _canvasGroup != null ? _canvasGroup.alpha : 1f;
            float endAlpha = _fade ? 0f : 1f;

            StartAnimation(startSize, 0f, startAlpha, endAlpha, anim, destroyAtEnd: true);
        }

        private void StartAnimation(float fromSize, float toSize, float fromAlpha, float toAlpha, AnimationSettings anim, bool destroyAtEnd)
        {
            if (!isActiveAndEnabled || !gameObject.activeInHierarchy)
            {
                SetSizeImmediate(toSize);

                if (_fade && _canvasGroup != null)
                {
                    _canvasGroup.alpha = toAlpha;
                }
                else
                {
                    ForceVisibleIfNoFade();
                }

                if (destroyAtEnd)
                {
                    Destroy(gameObject);
                }

                return;
            }

            if (_routine != null)
            {
                StopCoroutine(_routine);
            }

            _routine = StartCoroutine(AnimateRoutine(fromSize, toSize, fromAlpha, toAlpha, anim, destroyAtEnd));
        }

        private IEnumerator AnimateRoutine(float fromSize, float toSize, float fromAlpha, float toAlpha, AnimationSettings anim, bool destroyAtEnd)
        {
            float duration = Mathf.Max(0.0001f, anim.Duration);
            var ease = anim.Ease != null ? anim.Ease : AnimationCurve.Linear(0f, 0f, 1f, 1f);

            float t = 0f;

            ApplySize(fromSize);
            ApplyAlpha(fromAlpha);
            RebuildIfNeeded();
            yield return null;

            while (t < 1f)
            {
                if (!isActiveAndEnabled || !gameObject.activeInHierarchy)
                {
                    yield break;
                }

                float dt = anim.UseUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime;
                t += dt / duration;

                float e = ease.Evaluate(Mathf.Clamp01(t));

                float size = Mathf.Lerp(fromSize, toSize, e);
                float alpha = Mathf.Lerp(fromAlpha, toAlpha, e);

                ApplySize(size);
                ApplyAlpha(alpha);
                RebuildIfNeeded();

                yield return null;
            }

            ApplySize(toSize);
            ApplyAlpha(toAlpha);
            RebuildIfNeeded();

            _routine = null;

            if (destroyAtEnd)
            {
                Destroy(gameObject);
            }
        }

        private void ApplySize(float size)
        {
            size = Mathf.Max(0f, size);

            if (_resolvedAxis == Axis.Horizontal)
            {
                _layoutElement.preferredWidth = size;
                _layoutElement.preferredHeight = -1f;

                if (_lockMinToPreferred)
                {
                    _layoutElement.minWidth = size;
                    _layoutElement.minHeight = -1f;
                }
            }
            else
            {
                _layoutElement.preferredHeight = size;
                _layoutElement.preferredWidth = -1f;

                if (_lockMinToPreferred)
                {
                    _layoutElement.minHeight = size;
                    _layoutElement.minWidth = -1f;
                }
            }

            if (_rt.parent is RectTransform parent)
            {
                LayoutRebuilder.MarkLayoutForRebuild(parent);
            }
        }

        private void ApplyAlpha(float alpha)
        {
            if (!_fade)
            {
                ForceVisibleIfNoFade();
                return;
            }

            if (_canvasGroup == null)
            {
                return;
            }

            _canvasGroup.alpha = Mathf.Clamp01(alpha);
        }

        private void ForceVisibleIfNoFade()
        {
            if (_canvasGroup == null)
            {
                return;
            }

            if (!_fade && _canvasGroup.alpha != 1f)
            {
                _canvasGroup.alpha = 1f;
            }
        }

        private void EnsureCanvasGroupOnHostIfNeeded()
        {
            if (!_autoAddCanvasGroup)
            {
                _canvasGroup = GetComponent<CanvasGroup>();
                return;
            }

            if (_canvasGroup != null)
            {
                return;
            }

            _canvasGroup = GetComponent<CanvasGroup>();
            if (_canvasGroup == null)
            {
                _canvasGroup = gameObject.AddComponent<CanvasGroup>();
            }

            if (_canvasGroup.alpha <= 0f)
            {
                _canvasGroup.alpha = 1f;
            }
        }

        private void EnsureClipBinding()
        {
            if (!_clipChildren)
            {
                if (_rectMask != null)
                {
                    _rectMask.enabled = false;
                }
                return;
            }

            if (_rectMask == null)
            {
                _rectMask = GetComponent<RectMask2D>();
                if (_rectMask == null)
                {
                    _rectMask = gameObject.AddComponent<RectMask2D>();
                }
            }

            _rectMask.enabled = true;
        }

        private void SetSizeImmediate(float size)
        {
            Cache();
            ResolveLayoutChain();
            ApplySize(size);
        }

        private float GetCurrentSize()
        {
            if (_resolvedAxis == Axis.Horizontal)
            {
                return _layoutElement.preferredWidth >= 0f ? _layoutElement.preferredWidth : _rt.rect.width;
            }

            return _layoutElement.preferredHeight >= 0f ? _layoutElement.preferredHeight : _rt.rect.height;
        }

        private void ResolveLayoutChain()
        {
            _parentLayoutGroup = GetComponentInParent<LayoutGroup>();

            if (_parentLayoutGroup != null)
            {
                _layoutRootRect = _parentLayoutGroup.transform as RectTransform;
            }
            else
            {
                _layoutRootRect = _rt.parent as RectTransform;
            }

            _resolvedAxis = ResolveAxis(_axis, _parentLayoutGroup);
            EnsureParentLayoutUsesPreferredSize(_parentLayoutGroup, _resolvedAxis);
        }

        private void RebuildIfNeeded()
        {
            if (_layoutRootRect != null)
            {
                LayoutRebuilder.ForceRebuildLayoutImmediate(_layoutRootRect);
            }
        }

        private void Cache()
        {
            if (_rt == null)
            {
                _rt = (RectTransform)transform;
            }

            if (_layoutElement == null)
            {
                _layoutElement = GetComponent<LayoutElement>();
            }

            if (_rectMask == null)
            {
                _rectMask = GetComponent<RectMask2D>();
            }
        }

        private static Axis ResolveAxis(Axis requested, LayoutGroup group)
        {
            if (requested != Axis.Auto)
            {
                return requested;
            }

            if (group is HorizontalLayoutGroup)
            {
                return Axis.Horizontal;
            }

            return Axis.Vertical;
        }

        private static void EnsureParentLayoutUsesPreferredSize(LayoutGroup group, Axis axis)
        {
            if (group is not HorizontalOrVerticalLayoutGroup hov) return;

            hov.childControlWidth = true;
            hov.childControlHeight = true;
        }

        private static void SetupChildStretchFill(RectTransform child)
        {
            child.anchorMin = Vector2.zero;
            child.anchorMax = Vector2.one;
            child.pivot = new Vector2(0.5f, 0.5f);
            child.anchoredPosition = Vector2.zero;
            child.sizeDelta = Vector2.zero;
        }
    }
}
