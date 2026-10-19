using System;
using HutongGames.PlayMaker.Actions;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.UI
{
    /// <summary>
    /// Simple paging UI controller. Delegates paging behavior to an <see cref="IDataPagingTarget"/>.
    /// </summary>
    [AddComponentMenu("PlayMaker/Widgets/Data Paging")]
    [Icon(Strings.EditorIconsPath + "DataTableWidgetIcon.png")]
    [HelpURL("https://hutonggames.com/playmaker/docs/guides/ui-widgets/data/data-paging/")]
    public sealed class DataPaging : MonoBehaviour
    {
        [SerializeField, Tooltip("Component that implements IDataPagingTarget (e.g. DataTableWidget).")]
        private MonoBehaviour _target;

        [SerializeField, Tooltip("Rows/items per page.")]
        private int _pageSize = 20;

        [SerializeField, OptionalField, Tooltip("Prev page button.")]
        private Button _prev;

        [SerializeField, OptionalField, Tooltip("Next page button.")]
        private Button _next;

        public enum TextComponentKind { TmpText, UguiText }

        [SerializeField, Tooltip("Select which text component type is used for Page Text.")]
        private TextComponentKind _pageTextKind = TextComponentKind.TmpText;

        [SerializeField, OptionalField, Tooltip("Optional TextMeshPro text used to display page info.")]
        private TMPro.TMP_Text _tmpText;

        [SerializeField, OptionalField, Tooltip("Optional legacy uGUI Text used to display page info.")]
        private Text _uguiText;

        [SerializeField, Tooltip("Format string. Uses: {0}=current page (1-based), {1}=total pages.")]
        private string _format = "Page {0}/{1}";

        [SerializeField, Tooltip("Disable Prev/Next buttons when you are at the first/last page.")]
        private bool _disableButtonsAtEnds = true;

        [SerializeField, Tooltip("Reset scroll position when changing pages.")]
        private bool _resetScrollOnPageChange = true;

        private IDataPagingTarget Target => _target as IDataPagingTarget;

        public int PageSize
        {
            get => _pageSize;
            set
            {
                _pageSize = Mathf.Max(1, value);
                RefreshUI();
            }
        }
        
        private void AutoFindTarget()
        {
            // If user already assigned a valid target, respect it.
            if (_target != null && _target is IDataPagingTarget)
                return;

            // Look for compatible components on the same GameObject.
            var candidates = GetComponents<MonoBehaviour>();

            IDataPagingTarget found = null;

            for (int i = 0; i < candidates.Length; i++)
            {
                if (candidates[i] is IDataPagingTarget pagingTarget)
                {
                    found = pagingTarget;
                    break;
                }
            }

            if (found == null)
                return;

            _target = found as MonoBehaviour;
        }

        private void Reset() => AutoFindTarget();

#if UNITY_EDITOR
        private void OnValidate() => AutoFindTarget();
#endif
        
        private void OnEnable()
        {
            if (_prev != null) _prev.onClick.AddListener(OnPrev);
            if (_next != null) _next.onClick.AddListener(OnNext);
            RefreshUI();
        }

        private void OnDisable()
        {
            if (_prev != null) _prev.onClick.RemoveListener(OnPrev);
            if (_next != null) _next.onClick.RemoveListener(OnNext);
        }
        
        private void Awake()
        {
            if (_target == null)
            {
                Debug.LogWarning(
                    $"{nameof(DataPaging)} on '{name}' has no IDataPagingTarget.",
                    this);
            }
        }

        /// <summary>
        /// Call this after external changes (e.g., table row count changed) if you want the UI to update immediately.
        /// </summary>
        public void RefreshUI()
        {
            var t = Target;
            if (t == null)
            {
                SetText(string.Empty);
                if (_disableButtonsAtEnds)
                {
                    if (_prev != null) _prev.interactable = false;
                    if (_next != null) _next.interactable = false;
                }
                return;
            }

            t.GetPageInfo(_pageSize, out int pageIndex, out int totalPages);

            if (!string.IsNullOrEmpty(_format))
                SetText(string.Format(_format, pageIndex + 1, totalPages));
            else
                SetText($"{pageIndex + 1}/{totalPages}");

            if (_disableButtonsAtEnds)
            {
                if (_prev != null) _prev.interactable = pageIndex > 0;
                if (_next != null) _next.interactable = pageIndex < totalPages - 1;
            }
        }

        private void OnPrev()
        {
            var t = Target;
            if (t == null) return;

            t.GetPageInfo(_pageSize, out int pageIndex, out _);
            t.SetPage(Mathf.Max(0, pageIndex - 1), rebuild: true, resetScroll: _resetScrollOnPageChange);
            RefreshUI();
        }

        private void OnNext()
        {
            var t = Target;
            if (t == null) return;

            t.GetPageInfo(_pageSize, out int pageIndex, out int totalPages);
            t.SetPage(Mathf.Min(totalPages - 1, pageIndex + 1), rebuild: true, resetScroll: _resetScrollOnPageChange);
            RefreshUI();
        }

        private void SetText(string text)
        {
            switch (_pageTextKind)
            {
                case TextComponentKind.TmpText:
                    if (_tmpText != null) _tmpText.text = text;
                    break;

                case TextComponentKind.UguiText:
                    if (_uguiText != null) _uguiText.text = text;
                    break;
            }
        }
        
        public void PreviousPage(bool rebuild = true, bool resetScroll = true)
        {
            var t = Target;
            if (t == null) return;

            t.GetPageInfo(_pageSize, out int pageIndex, out _);
            t.SetPage(Mathf.Max(0, pageIndex - 1), rebuild, resetScroll);
            RefreshUI();
        }

        public void NextPage(bool rebuild = true, bool resetScroll = true)
        {
            var t = Target;
            if (t == null) return;

            t.GetPageInfo(_pageSize, out int pageIndex, out int totalPages);
            t.SetPage(Mathf.Min(totalPages - 1, pageIndex + 1), rebuild, resetScroll);
            RefreshUI();
        }

        public void SetPage(int pageIndex, bool rebuild = true, bool resetScroll = true)
        {
            var t = Target;
            if (t == null) return;

            t.SetPage(pageIndex, rebuild, resetScroll);
            RefreshUI();
        }
        
        public bool TryGetPageInfo(out int pageIndex, out int totalPages, out int totalItems)
        {
            pageIndex = 0;
            totalPages = 1;
            totalItems = 0;

            var t = Target;
            if (t == null)
                return false;

            totalItems = t.TotalItemCount;
            t.GetPageInfo(_pageSize, out pageIndex, out totalPages);
            return true;
        }


    }
}
