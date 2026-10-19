using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Mouse)]
    [ActionDescription("Sends Events based on mouse interactions with a Game Object: " +
                       "MouseOver, MouseDown, MouseUp, MouseOff. " +
                       "<br/>Use Ray Distance to set how close the camera must be to pick the object." +
                       "<br/>Can be used with 3d and 2d colliders. " +
                        Strings.SupportsBothInputSystems)]
    public sealed class InputMousePickEvent : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
        
        [OwnerDefaultValue]
        [Tooltip("The Game Object to detect mouse interactions with.")]
        [SerializeField]
        private GameObjectVar _gameObject;
        
        [Tooltip("The Camera to use for raycasting.")]
        [SerializeField, DefaultValue("~MainCamera")]
        private CameraVar _camera;
        
        [Tooltip("Length of the ray to cast from the camera.")]
        [SerializeField, DefaultValue(100f)]
        private FloatVar _rayDistance;

        [Tooltip("Layer Mask to use for raycasting.")]
        [SerializeField, DefaultValue("Physics.DefaultRaycastLayers")]
        private LayerMaskVar _layerMask;
        
        [Tooltip("Event to send when the mouse is over the GameObject.")]
        [SerializeField, OptionalField] 
        private EventRef _mouseEnter;

        [Tooltip("Event to send when the mouse is pressed while over the GameObject.")]
        [SerializeField, OptionalField] 
        private EventRef _mouseDown;

        [Tooltip("Event to send when the mouse is released while over the GameObject.")]
        [SerializeField, OptionalField] 
        private EventRef _mouseUp;
		
        [Tooltip("Event to send when the mouse moves off the GameObject.")]
        [SerializeField, OptionalField] 
        private EventRef _mouseExit;

        [ActionHeader("Outputs")]

        [OptionalField]
        [Tooltip("Store the full raycast hit information when a 3D collider is picked.")]
        [SerializeField, WriteOnly]
        private RaycastHitRef _storeHitInfo;

        [OptionalField]
        [Tooltip("Store the world position where the object was picked.")]
        [SerializeField, WriteOnly]
        private Vector3Ref _storeHitPosition;
        
        public override bool CanExecute() => CheckParameters(_camera, _gameObject);

        private bool _isOver;
        
        public override void Execute()
        {
            var go = _gameObject.Value;
            if (go == null)
            {
                ClearOutputs();
                return;
            }

            var cam = _camera.Value != null ? _camera.Value : Camera.main;
            if (cam == null)
            {
                ClearOutputs();
                return;
            }

            var mousePos = InputShim.GetMousePosition();
            var downThisFrame = InputShim.GetMouseButtonDown(0);
            var upThisFrame = InputShim.GetMouseButtonUp(0);

            var ray = cam.ScreenPointToRay(mousePos);

            bool isOverNow = false;
            bool hasHitInfo = false;
            RaycastHit hitInfo = default;
            Vector3 hitPosition = default;

            // --- 3D pick ---
            if (Physics.Raycast(
                    ray,
                    out var hit3D,
                    _rayDistance.Value,
                    _layerMask.Value))
            {
                var t = hit3D.transform;
                if (t != null)
                {
                    isOverNow =
                        t.gameObject == go ||
                        t.IsChildOf(go.transform);

                    if (isOverNow)
                    {
                        hasHitInfo = true;
                        hitInfo = hit3D;
                        hitPosition = hit3D.point;
                    }
                }
            }
            else
            {
                // --- 2D pick (fallback) ---
                var hit2D = Physics2D.GetRayIntersection(
                    ray,
                    _rayDistance.Value,
                    _layerMask.Value);

                if (hit2D.collider != null)
                {
                    var t = hit2D.transform;
                    if (t != null)
                    {
                        isOverNow =
                            t.gameObject == go ||
                            t.IsChildOf(go.transform);

                        if (isOverNow)
                            hitPosition = hit2D.point;
                    }
                }
            }

            // --- events ---
            if (isOverNow)
            {
                if (_storeHitPosition.IsAssigned)
                    _storeHitPosition.Value = hitPosition;

                if (_storeHitInfo.IsAssigned)
                    _storeHitInfo.Value = hasHitInfo ? hitInfo : default;

                if (!_isOver)
                {
                    _isOver = true;
                    SendEvent(_mouseEnter);
                }

                if (downThisFrame)
                    SendEvent(_mouseDown);

                if (upThisFrame)
                    SendEvent(_mouseUp);
            }
            else if (_isOver)
            {
                ClearOutputs();
                _isOver = false;
                SendEvent(_mouseExit);
            }
            else
            {
                ClearOutputs();
            }
        }

        private void ClearOutputs()
        {
            if (_storeHitPosition.IsAssigned)
                _storeHitPosition.Value = default;

            if (_storeHitInfo.IsAssigned)
                _storeHitInfo.Value = default;
        }

        public override string GetSummary() =>
            "Mouse pick {_gameObject} ({_rayDistance})" +
            (_mouseEnter.IsSet ? " Enter {_mouseEnter}" : "") +
            (_mouseDown.IsSet ? " Down {_mouseDown}" : "") +
            (_mouseUp.IsSet ? " Up {_mouseUp}" : "") +
            (_mouseExit.IsSet ? " Exit {_mouseExit}" : "") +
            " {_storeHitInfo:output} {_storeHitPosition:output}";

    }
}
