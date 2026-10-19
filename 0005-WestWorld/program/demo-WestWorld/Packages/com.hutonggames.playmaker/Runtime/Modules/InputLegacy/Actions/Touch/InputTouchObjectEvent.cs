using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.Touch)]
    [ActionDescription("Sends events when touches interact with a target GameObject's collider.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Input-touches.html")]
    [MovedFrom(true, null, null, "TouchObjectEvent")]
    public sealed class InputTouchObjectEvent : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
        public override UpdateMode RequiredUpdateModes => UpdateMode.EveryFrame;

        [RequiredField]
        [OwnerDefaultValue]
        [Tooltip("The Game Object to detect touches on.")]
        [SerializeField]
        private GameObjectVar _gameObject;

        [RequiredField]
        [Tooltip("How far from the camera is the Game Object pickable.")]
        [SerializeField, DefaultValue(100f)]
        private FloatVar _pickDistance;

        [Tooltip("The Camera to use for raycasting.")]
        [SerializeField, DefaultValue("~MainCamera")]
        private CameraVar _camera;

        [OptionalField]
        [Tooltip("Only detect touches that match this fingerID, or set to None.")]
        [SerializeField]
        private IntegerVar _fingerId;

        [ActionHeader("Events")]

        [Tooltip("Event to send on touch began.")]
        [SerializeField, OptionalField]
        private EventRef _touchBegan;

        [Tooltip("Event to send on touch moved.")]
        [SerializeField, OptionalField]
        private EventRef _touchMoved;

        [Tooltip("Event to send on stationary touch.")]
        [SerializeField, OptionalField]
        private EventRef _touchStationary;

        [Tooltip("Event to send on touch ended.")]
        [SerializeField, OptionalField]
        private EventRef _touchEnded;

        [Tooltip("Event to send on touch cancel.")]
        [SerializeField, OptionalField]
        private EventRef _touchCanceled;

        [ActionHeader("Outputs")]

        [OptionalField]
        [Tooltip("Store the fingerId of the touch.")]
        [SerializeField, WriteOnly]
        private IntegerRef _storeFingerId;

        [OptionalField]
        [Tooltip("Store the world position where the object was touched.")]
        [SerializeField, WriteOnly]
        private Vector3Ref _storeHitPoint;

        [OptionalField]
        [Tooltip("Store the surface normal vector where the object was touched.")]
        [SerializeField, WriteOnly]
        private Vector3Ref _storeHitNormal;

        [OptionalField]
        [Tooltip("Store the full raycast hit information.")]
        [SerializeField, WriteOnly]
        private RaycastHitRef _storeRaycastHit;

        public override bool CanExecute() => CheckParameters(_gameObject, _pickDistance);

        public override void Execute()
        {
            var target = _gameObject.Value;
            if (target == null)
                return;

            var cam = _camera.Value != null ? _camera.Value : Camera.main;
            if (cam == null)
                return;

            var targetTransform = target.transform;
            var touches = Input.touches;

            for (int i = 0; i < touches.Length; i++)
            {
                var touch = touches[i];

                if (_fingerId.IsAssigned && touch.fingerId != _fingerId.Value)
                    continue;

                var ray = cam.ScreenPointToRay(touch.position);
                if (!Physics.Raycast(ray, out var hitInfo, _pickDistance.Value))
                    continue;

                var hitTransform = hitInfo.transform;
                if (hitTransform == null)
                    continue;

                if (hitTransform != targetTransform && !hitTransform.IsChildOf(targetTransform))
                    continue;

                if (_storeFingerId.IsAssigned)
                    _storeFingerId.Value = touch.fingerId;

                if (_storeHitPoint.IsAssigned)
                    _storeHitPoint.Value = hitInfo.point;

                if (_storeHitNormal.IsAssigned)
                    _storeHitNormal.Value = hitInfo.normal;

                if (_storeRaycastHit.IsAssigned)
                    _storeRaycastHit.Value = hitInfo;

                SendPhaseEvent(touch.phase);
            }
        }

        private void SendPhaseEvent(TouchPhase phase)
        {
            switch (phase)
            {
                case TouchPhase.Began:
                    SendEvent(_touchBegan);
                    break;
                case TouchPhase.Moved:
                    SendEvent(_touchMoved);
                    break;
                case TouchPhase.Stationary:
                    SendEvent(_touchStationary);
                    break;
                case TouchPhase.Ended:
                    SendEvent(_touchEnded);
                    break;
                case TouchPhase.Canceled:
                    SendEvent(_touchCanceled);
                    break;
            }
        }

        public override string GetSummary() =>
            "Touch object {_gameObject} dist {_pickDistance}" +
            (_fingerId.IsAssigned ? " finger {_fingerId}" : string.Empty) +
            (_touchBegan.IsSet ? " Began {_touchBegan}" : string.Empty) +
            (_touchMoved.IsSet ? " Moved {_touchMoved}" : string.Empty) +
            (_touchStationary.IsSet ? " Stationary {_touchStationary}" : string.Empty) +
            (_touchEnded.IsSet ? " Ended {_touchEnded}" : string.Empty) +
            (_touchCanceled.IsSet ? " Canceled {_touchCanceled}" : string.Empty);
    }
}
