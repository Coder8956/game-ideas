
using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    public abstract class BaseCheckIsGroundedAction : BaseTrueFalseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
        
        [DisplayOrder(100)]
        [Tooltip("The amount of time in seconds that the player can still jump after starting to fall. " +
                 "\n\nFor example, when running to the edge of a platform and jumping. " +
                 "This tweak makes jumping a little more forgiving.")]
        [SerializeField, DefaultValue(0.2f)]
        protected FloatVar _coyoteTime;

        [OptionalField]
        [DisplayOrder(1003)]
        [Tooltip("Store the Rigidbody2D of the ground we are on, or null.")]
        [SerializeField, WriteOnly]
        protected Rigidbody2DRef _storeRigidbody2D;
        
        private float _coyoteTimer;
        
        protected bool IsCoyoteTime() => _coyoteTimer > 0;

        protected void UpdateCoyoteTime(bool isGrounded)
        {
            if (isGrounded)
            {
                _coyoteTimer = _coyoteTime.Value;
            }
            else
            {
                _coyoteTimer -= Time.deltaTime;
            }
        }
        
        protected string CoyoteTimeSummary() => _coyoteTime.Value > 0 ? " Coyote Time: {_coyoteTime}" : string.Empty;
        
        public override string GetSummary() => base.GetSummary() 
                                               + CoyoteTimeSummary() 
                                               + (_storeRigidbody2D.IsAssigned ? " -> {_storeRigidbody2D}" : string.Empty);
    }
}