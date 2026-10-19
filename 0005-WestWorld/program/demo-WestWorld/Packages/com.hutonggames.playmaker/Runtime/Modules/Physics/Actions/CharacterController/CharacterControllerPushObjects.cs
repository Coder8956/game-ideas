using System;
using JetBrains.Annotations;
using UnityEngine;

/*
 * Scenarios:
 *
 * Push objects in hit normal direction
 * Push objects in move direction
 * Push object at fixed speed
 * Add force to push object
 * Get speed from object? Multiple actions?
 * Get force form object? Multiple actions?
 *
 * 
 */


namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.CharacterController)]
    [ActionDescription("Allows a CharacterController to push RigidBody objects with a given force.")]
    public sealed class CharacterControllerPushObjects : BaseAction
    {
        public override UpdateMode AllowedUpdateModes => UpdateMode.OnEventUpdate;

        [Tooltip("The CharacterController to move.")]
        [SerializeField, OwnerDefaultValue]
        private CharacterControllerVar _characterController;

        [Tooltip("The push speed to apply to objects." + Strings.PerSecondNote)] 
        [SerializeField, DefaultValue(1f)]
        private FloatVar _pushForce;

        [Tooltip("The GameObject that was pushed.")]
        [SerializeField, WriteOnly, OptionalField]
        private GameObjectRef _pushedObject;
        
        [NonSerialized] private OnControllerColliderHitEvent _event;

        public override void OnStart()
        {
            if (_characterController.HasValue())
            {
                _event ??= new OnControllerColliderHitEvent();
                _event.RegisterCallback(_characterController.Value, OwnerComponent);
            }
        }

        public override void OnStop()
        {
            _event?.UnregisterCallback(OwnerComponent);
        }

        public override bool CanExecute() => CheckParameters(_characterController, _pushForce);

        public override bool OnEvent(BaseEvent baseEvent)
        {
            if (baseEvent is not OnControllerColliderHitEvent hitEvent)
                return false;

            var hit = hitEvent.ControllerColliderHit;
            var body = hit.collider.attachedRigidbody;
            if (body == null || body.isKinematic)
                return true;
            
            var pushDirection = -hit.normal;
            pushDirection.y = 0;
            var pushForce = pushDirection.normalized * _pushForce.Value;
            body.AddForceAtPosition(pushForce, hit.point, ForceMode.Impulse);

            if (_pushedObject.IsAssigned)
            {
                _pushedObject.Value = body.gameObject;
            }
            
            return true;
        }

        public override string GetSummary() => "Push objects with {_characterController} at {_pushForce}";
    }
}
