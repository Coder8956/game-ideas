using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    public abstract class BaseCharacterControllerCheckIsGroundedAction : BaseTrueFalseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

        public override void OnStart()
        {
            ResetCoyoteTime();
        }

        [DisplayOrder(100)]
        [Tooltip("The amount of time in seconds that the controller can still count as grounded after leaving the ground.")]
        [SerializeField, DefaultValue(0.1f)]
        protected FloatVar _coyoteTime;

        [OptionalField]
        [DisplayOrder(1003)]
        [Tooltip("Store the Rigidbody of the ground we are on, or null.")]
        [SerializeField, WriteOnly]
        protected RigidbodyRef _storeRigidbody;

        [OptionalField]
        [DisplayOrder(1004)]
        [Tooltip("Store the hit info from the ground probe.")]
        [SerializeField, WriteOnly]
        protected RaycastHitRef _storeHitInfo;

        private float _coyoteTimer;
        private float CoyoteTimeValue => _coyoteTime?.Value ?? 0f;

        protected bool IsCoyoteTime() => _coyoteTimer > 0f;

        protected void ResetCoyoteTime()
        {
            _coyoteTimer = 0f;
        }

        protected void UpdateCoyoteTime(bool isGrounded)
        {
            if (isGrounded)
            {
                _coyoteTimer = CoyoteTimeValue;
            }
            else
            {
                _coyoteTimer -= Time.deltaTime;
            }
        }

        protected string CoyoteTimeSummary() => CoyoteTimeValue > 0f ? " Coyote Time: {_coyoteTime}" : string.Empty;

        public override string GetSummary() => base.GetSummary()
                                                   + CoyoteTimeSummary()
                                                   + (_storeRigidbody != null && _storeRigidbody.IsAssigned ? " -> {_storeRigidbody}" : string.Empty)
                                                   + (_storeHitInfo != null && _storeHitInfo.IsAssigned ? " {_storeHitInfo:output}" : string.Empty);
    }
}
