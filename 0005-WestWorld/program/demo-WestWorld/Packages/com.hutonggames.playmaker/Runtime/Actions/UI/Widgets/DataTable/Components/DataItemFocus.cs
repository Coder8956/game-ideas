using HutongGames.PlayMaker.Actions;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker.UI
{
    [AddComponentMenu("PlayMaker/Widgets/Data Item Focus")]
    [Icon(Strings.EditorIconsPath + "DataRowSelectionIcon.png")]
    [HelpURL("https://hutonggames.com/playmaker/docs/guides/ui-widgets/data/data-item-selection/")]
    public sealed class DataItemFocus : MonoBehaviour, ISelectHandler, IDeselectHandler
    {
        private static readonly int FocusedParamId = Animator.StringToHash("Focused");

        [SerializeField, Tooltip("Object that represents the focus highlight. " +
                                 "NOTE: Make sure it is not a raycast target, otherwise it will block input to other controls.")]
        private GameObject _target;

        [SerializeField, Tooltip("Optional Animator that controls focus transitions using bool 'Focused'.")]
        private Animator _animator;
        
        private Transform _focusScopeRoot;

        private bool _isFocused;
        private bool _initialized;

        private void Reset()
        {
            _target = gameObject;
            _animator = GetComponent<Animator>();
        }

        private void Awake()
        {
            ResolveFocusScopeRoot();
            InitializeUnfocused();
        }

        private void OnEnable()
        {
            ResolveFocusScopeRoot();

            if (!_initialized)
                InitializeUnfocused();

            SyncFocused(_isFocused);
        }

        private void LateUpdate()
        {
            SyncFocused(IsEventSystemFocusInsideRow());
        }

        public void OnSelect(BaseEventData eventData)
        {
            SetFocused(true);
        }

        public void OnDeselect(BaseEventData eventData)
        {
            SetFocused(false);
        }

        private void InitializeUnfocused()
        {
            _initialized = true;
            _isFocused = false;
            SyncFocused(false);
        }

        private void SetFocused(bool focused)
        {
            if (_isFocused == focused)
                return;

            _isFocused = focused;
            ApplyState(_isFocused, immediate: false);
        }

        private void SyncFocused(bool focused)
        {
            _isFocused = focused;
            ApplyState(_isFocused, immediate: true);
        }

        private void ApplyState(bool focused, bool immediate)
        {
            if (_target == null)
                return;

            if (_animator != null)
            {
                if (!_target.activeSelf)
                    _target.SetActive(true);

                _animator.SetBool(FocusedParamId, focused);
                if (immediate)
                    _animator.Update(0f);
                return;
            }

            _target.SetActive(focused);
        }

        private bool IsEventSystemFocusInsideRow()
        {
            var eventSystem = EventSystem.current;
            if (eventSystem == null)
                return false;

            var selected = eventSystem.currentSelectedGameObject;
            if (selected == null)
                return false;

            var selectedTransform = selected.transform;
            if (selectedTransform == null)
                return false;

            var scope = _focusScopeRoot != null ? _focusScopeRoot : transform;
            return selectedTransform == scope || selectedTransform.IsChildOf(scope);
        }

        private void ResolveFocusScopeRoot()
        {
            if (_focusScopeRoot != null)
                return;

            var ctx = GetComponentInParent<IDataItemContext>();
            if (ctx?.ItemGameObject != null)
            {
                _focusScopeRoot = ctx.ItemGameObject.transform;
                return;
            }

            _focusScopeRoot = transform;
        }
    }
}
