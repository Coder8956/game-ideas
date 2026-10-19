using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker.UI
{
    [AddComponentMenu("PlayMaker/Widgets/Data Item Selection")]
    [Icon(Strings.EditorIconsPath + "DataRowSelectionIcon.png")]
    [HelpURL("https://hutonggames.com/playmaker/docs/guides/ui-widgets/data/data-item-selection/")]
    public sealed class DataItemSelection : MonoBehaviour, IDataItemSelectionVisual
    {
        private static readonly int SelectedParamId = Animator.StringToHash("Selected");

        [SerializeField, Tooltip("Object that represents the selection highlight. " +
                                 "NOTE: Make sure it is not a raycast target, otherwise it will block input to other controls.")]
        private GameObject _target;

        [SerializeField, Tooltip("Optional Animator that controls selection transitions using bool 'Selected'.")]
        private Animator _animator;

        private bool _isSelected;
        private bool _initialized;

        private void Reset()
        {
            _target = gameObject;
            _animator = GetComponent<Animator>();
        }

        private void Awake()
        {
            InitializeDeselected();
        }

        private void OnEnable()
        {
            // Safety for edge cases where pooled objects get re-enabled before the widget syncs.
            // Widget will immediately SyncSelected(...) after binding anyway.
            if (!_initialized)
                InitializeDeselected();
        }

        private void InitializeDeselected()
        {
            _initialized = true;
            SyncSelected(false);
        }

        // User-driven change (may animate)
        public void SetSelected(bool selected)
        {
            if (_isSelected == selected)
                return;

            _isSelected = selected;

            if (_target == null)
                return;

            if (_animator != null)
            {
                if (!_target.activeSelf)
                    _target.SetActive(true);

                _animator.SetBool(SelectedParamId, selected);
                return;
            }

            _target.SetActive(selected);
        }

        // State sync (no visible transition; safe for rebuild/pooling)
        public void SyncSelected(bool selected)
        {
            _isSelected = selected;

            if (_target == null)
                return;

            if (_animator != null)
            {
                if (!_target.activeSelf)
                    _target.SetActive(true);

                _animator.SetBool(SelectedParamId, selected);

                // Snap animator to the correct state immediately (no transition playback).
                _animator.Update(0f);
                return;
            }

            _target.SetActive(selected);
        }
    }
}
