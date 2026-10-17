using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UMiniFramework.Runtime
{
    /// <summary>
    /// 通用弹窗面板，支持三种状态：
    /// 1. TwoButton  — 标题 + 内容 + 左右两个按钮
    /// 2. OneButton  — 标题 + 内容 + 单个按钮
    /// 3. CountDown — 标题 + 内容 + 倒计时关闭 / 不可关闭
    /// </summary>
    [UMUIPanelCfg("UI/UMUICommonPopups")]
    public class UMUICommonPopups : UMUIPanelBase
    {
        private enum UMPopupState
        {
            /// <summary>
            /// 双按钮弹窗
            /// </summary>
            TwoButton,

            /// <summary>
            /// 单按钮弹窗
            /// </summary>
            OneButton,

            /// <summary>
            /// 倒计时弹窗
            /// </summary>
            CountDown
        }

        [SerializeField] private TMP_Text m_txtTitle;
        [SerializeField] private TMP_Text m_txtContent;

        [SerializeField] private GameObject m_twoButtonGroup;
        [SerializeField] private Button m_btnLeft;
        [SerializeField] private TMP_Text m_txtLeft;
        [SerializeField] private Button m_btnRight;
        [SerializeField] private TMP_Text m_txtRight;

        [SerializeField] private GameObject m_oneButtonGroup;
        [SerializeField] private Button m_btnOne;
        [SerializeField] private TMP_Text m_txtOne;

        [SerializeField] private GameObject m_countDownGroup;
        [SerializeField] private Button m_btnCountDown;
        [SerializeField] private TMP_Text m_txtCountDown;

        private UMPopupState m_state;
        private string m_title;
        private string m_content;

        private string m_leftBtnText;
        private string m_rightBtnText;
        private Action m_onLeftClick;
        private Action m_onRightClick;

        private string m_oneBtnText;
        private Action m_onOneClick;

        private int m_countDown;
        private Action m_onCountDownEnd;
        private string m_countDownFormat = "关闭({0}s)";

        private Coroutine m_countDownRoutine;

        // ── 对外 API ──────────────────────────────────────────

        /// <summary>
        /// 状态一：双按钮弹窗
        /// </summary>
        public void ShowTwoButton(string title, string content,
            string leftBtnText, Action onLeftClick,
            string rightBtnText, Action onRightClick, int layer = 0)
        {
            m_state = UMPopupState.TwoButton;
            m_title = title;
            m_content = content;
            m_leftBtnText = leftBtnText;
            m_rightBtnText = rightBtnText;
            m_onLeftClick = onLeftClick;
            m_onRightClick = onRightClick;

            Open(layer);
        }

        /// <summary>
        /// 状态二：单按钮弹窗
        /// </summary>
        public void ShowOneButton(string title, string content,
            string btnText, Action onClick, int layer = 0)
        {
            m_state = UMPopupState.OneButton;
            m_title = title;
            m_content = content;
            m_oneBtnText = btnText;
            m_onOneClick = onClick;

            Open(layer);
        }

        /// <summary>
        /// 状态三：倒计时弹窗
        /// countDown = 0  → 不可关闭
        /// countDown > 0 → 倒计时结束自动关闭
        /// </summary>
        public void ShowCountDown(
            string title,
            string content,
            int countDown = 0,
            Action onCountDownEnd = null,
            string countDownFormat = "关闭({0}s)", int layer = 0)
        {
            m_state = UMPopupState.CountDown;
            m_title = title;
            m_content = content;
            m_countDown = countDown;
            m_onCountDownEnd = onCountDownEnd;
            m_countDownFormat = string.IsNullOrEmpty(countDownFormat) ? "关闭({0}s)" : countDownFormat;

            Open(layer);
        }

        // ── 生命周期 ──────────────────────────────────────────

        protected override void OnInitialize()
        {
            m_btnLeft.onClick.AddListener(OnLeftButtonClick);
            m_btnRight.onClick.AddListener(OnRightButtonClick);
            m_btnOne.onClick.AddListener(OnOneButtonClick);
            m_btnCountDown.onClick.AddListener(OnCountDownButtonClick);
        }

        public override void Open(int layer = 0)
        {
            StopCountDown();

            if (m_txtTitle != null)
                m_txtTitle.text = m_title;

            if (m_txtContent != null)
                m_txtContent.text = m_content;

            switch (m_state)
            {
                case UMPopupState.TwoButton:
                    SetGroupActive(true, false, false);
                    if (m_txtLeft != null)
                        m_txtLeft.text = m_leftBtnText;
                    if (m_txtRight != null)
                        m_txtRight.text = m_rightBtnText;
                    base.Open(layer);
                    break;

                case UMPopupState.OneButton:
                    SetGroupActive(false, true, false);
                    if (m_txtOne != null)
                        m_txtOne.text = m_oneBtnText;
                    base.Open(layer);
                    break;

                case UMPopupState.CountDown:
                    SetGroupActive(false, false, true);
                    base.Open(layer);
                    StartCountDown();
                    break;
            }

            UpdateContentText();
        }

        public override void Close()
        {
            StopCountDown();
            ClearCallbacks();
            base.Close();
        }

        public override void Release()
        {
            m_btnLeft.onClick.RemoveAllListeners();
            m_btnRight.onClick.RemoveAllListeners();
            m_btnOne.onClick.RemoveAllListeners();
            m_btnCountDown.onClick.RemoveAllListeners();
            base.Release();
        }

        // ── 按钮回调 ──────────────────────────────────────────

        private void OnLeftButtonClick()
        {
            m_onLeftClick?.Invoke();
            Close();
        }

        private void OnRightButtonClick()
        {
            m_onRightClick?.Invoke();
            Close();
        }

        private void OnOneButtonClick()
        {
            m_onOneClick?.Invoke();
            Close();
        }

        private void OnCountDownButtonClick()
        {
            if (m_countDown <= 0)
                return;

            m_onCountDownEnd?.Invoke();
            Close();
        }

        // ── 倒计时 ───────────────────────────────────────────

        private void StartCountDown()
        {
            if (m_countDown <= 0)
            {
                // 不可关闭模式
                if (m_btnCountDown != null)
                    m_btnCountDown.gameObject.SetActive(false);
                return;
            }

            if (m_btnCountDown != null)
                m_btnCountDown.gameObject.SetActive(true);

            m_countDownRoutine = StartCoroutine(CountDownRoutine());
        }

        private IEnumerator CountDownRoutine()
        {
            int remaining = m_countDown;

            while (remaining > 0)
            {
                if (m_txtCountDown != null)
                    m_txtCountDown.text = string.Format(m_countDownFormat, remaining);

                yield return new WaitForSeconds(1f);
                remaining--;
            }

            m_onCountDownEnd?.Invoke();
            Close();
        }

        private void StopCountDown()
        {
            if (m_countDownRoutine != null)
            {
                StopCoroutine(m_countDownRoutine);
                m_countDownRoutine = null;
            }
        }

        // ── 辅助 ─────────────────────────────────────────────

        private void UpdateContentText()
        {
            if (m_txtContent == null) return;

            m_txtContent.ForceMeshUpdate();
            m_txtContent.alignment = m_txtContent.textInfo.lineCount <= 1
                ? TextAlignmentOptions.Center
                : TextAlignmentOptions.Left;
        }

        private void SetGroupActive(bool two, bool one, bool countDown)
        {
            if (m_twoButtonGroup != null)
                m_twoButtonGroup.SetActive(two);
            if (m_oneButtonGroup != null)
                m_oneButtonGroup.SetActive(one);
            if (m_countDownGroup != null)
                m_countDownGroup.SetActive(countDown);
        }

        private void ClearCallbacks()
        {
            m_onLeftClick = null;
            m_onRightClick = null;
            m_onOneClick = null;
            m_onCountDownEnd = null;
        }
    }
}