#if ENABLE_INPUT_SYSTEM && !ENABLE_LEGACY_INPUT_MANAGER

using UnityEngine;
using UnityEngine.InputSystem;

namespace HutongGames.PlayMaker
{
    /// <summary>
    /// Global bridge that emulates Unity's OnMouseXXX callbacks using the new Input System only.
    ///
    /// It works with PlayMaker's existing proxy components:
    /// - OnMouseProxyComponent (OnMouseDown, OnMouseUp, OnMouseUpAsButton, OnMouseEnter, OnMouseExit)
    /// - OnMouseDragProxyComponent (OnMouseDrag)
    ///
    /// The goal is: PlayMaker MOUSE system events "just work" even when the
    /// Legacy Input Manager is disabled and Unity no longer calls OnMouseXXX.
    /// </summary>
    [DefaultExecutionOrder(-5000)]
    [AddComponentMenu("")]
    internal sealed class PlayMakerMouseEventBridge : MonoBehaviour
    {
#if UNITY_6000_5_OR_NEWER
        [Unity.Scripting.LifecycleManagement.NoAutoStaticsCleanup]
#endif
        private static PlayMakerMouseEventBridge _instance;

        // Hover tracking for ENTER/EXIT:
        private OnMouseProxyComponent _currentHoverProxy;
        private OnMouseProxyComponent _lastHoverProxy;

        // Click/drag tracking:
        private OnMouseProxyComponent     _mouseDownProxy;       // target for Down/Up/UpAsButton
        private OnMouseDragProxyComponent _mouseDownDragProxy;   // target for Drag
        private bool _mouseStayedOnDownProxy;                    // for UpAsButton semantics

        #region Bootstrap

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void ResetStatics()
        {
            // Called on every Play-mode start even when domain reload is disabled.
            _instance = null;
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void CreateInstance()
        {
            if (_instance != null) return;

            var go = new GameObject("PlayMaker Mouse Event Bridge");
            go.hideFlags = HideFlags.HideAndDontSave;
            DontDestroyOnLoad(go);

            _instance = go.AddComponent<PlayMakerMouseEventBridge>();
        }

        #endregion

        private void Update()
        {
            var mouse = Mouse.current;
            if (mouse == null)
                return;

            var cam = Camera.main;
            if (cam == null)
                return;

            var screenPos = mouse.position.ReadValue();
            var hitObject = RaycastForObject(cam, screenPos);

            // Update hover proxy (only for objects that actually use OnMouseXXX)
            _currentHoverProxy = hitObject != null
                ? hitObject.GetComponent<OnMouseProxyComponent>()
                : null;

            ProcessHoverEvents();
            ProcessButtonEvents(mouse, hitObject);

            _lastHoverProxy = _currentHoverProxy;
        }

        #region Hover (Enter / Exit)

        private void ProcessHoverEvents()
        {
            if (_currentHoverProxy == _lastHoverProxy)
                return;

            // EXIT old hover
            if (_lastHoverProxy != null)
            {
                _lastHoverProxy.OnMouseExit();

                // Leaving the object after pressing down means we cannot treat
                // the click as "UpAsButton" for that object anymore.
                if (_mouseDownProxy == _lastHoverProxy)
                {
                    _mouseStayedOnDownProxy = false;
                }
            }

            // ENTER new hover
            if (_currentHoverProxy != null)
            {
                _currentHoverProxy.OnMouseEnter();
            }
        }

        #endregion

        #region Button / Drag

        private void ProcessButtonEvents(Mouse mouse, GameObject hitObject)
        {
            bool pressed  = mouse.leftButton.wasPressedThisFrame;
            bool released = mouse.leftButton.wasReleasedThisFrame;
            bool held     = mouse.leftButton.isPressed;

            if (pressed)
            {
                // Target for DOWN / UP / UPASBUTTON
                _mouseDownProxy = hitObject != null
                    ? hitObject.GetComponent<OnMouseProxyComponent>()
                    : null;

                // Target for DRAG (separate proxy)
                _mouseDownDragProxy = hitObject != null
                    ? hitObject.GetComponent<OnMouseDragProxyComponent>()
                    : null;

                // For UpAsButton we track whether the pointer
                // stays on the same OnMouseProxyComponent.
                _mouseStayedOnDownProxy = (_mouseDownProxy != null &&
                                           _mouseDownProxy == _currentHoverProxy);

                // OnMouseDown
                _mouseDownProxy?.OnMouseDown();
            }

            // Drag: always sent to the object that received the Down
            if (held && _mouseDownDragProxy != null)
            {
                _mouseDownDragProxy.OnMouseDrag();
            }

            // Track if pointer leaves the down target while held:
            if (held && _mouseDownProxy != null && _currentHoverProxy != _mouseDownProxy)
            {
                _mouseStayedOnDownProxy = false;
            }

            if (released && _mouseDownProxy != null)
            {
                // Equivalent to OnMouseUp on the original Down target:
                _mouseDownProxy.OnMouseUp();

                // Equivalent to OnMouseUpAsButton:
                // mouse down and up on the same object without leaving it.
                if (_mouseStayedOnDownProxy && _currentHoverProxy == _mouseDownProxy)
                {
                    _mouseDownProxy.OnMouseUpAsButton();
                }

                _mouseDownProxy = null;
                _mouseDownDragProxy = null;
                _mouseStayedOnDownProxy = false;
            }

            // If released but _mouseDownProxy was null, we do nothing;
            // that matches the idea that events only fire on objects
            // with corresponding proxies.
        }

        #endregion

        #region Raycast

        private static GameObject RaycastForObject(Camera cam, Vector2 screenPos)
        {
            var ray = cam.ScreenPointToRay(screenPos);

            // 3D hit
            if (Physics.Raycast(ray, out var hit3D))
            {
                return hit3D.collider != null ? hit3D.collider.gameObject : null;
            }

            // 2D hit
            var hit2D = Physics2D.GetRayIntersection(ray);
            if (hit2D.collider != null)
            {
                return hit2D.collider.gameObject;
            }

            return null;
        }

        #endregion
    }
}

#endif
