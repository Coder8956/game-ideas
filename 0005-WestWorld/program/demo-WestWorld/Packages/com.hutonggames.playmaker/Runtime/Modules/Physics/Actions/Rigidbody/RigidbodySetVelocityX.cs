
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Rigidbody)]
    [ConvertibleGroup("RigidbodySetVelocity")]
    [ActionDescription("Set the velocity vector of the rigidbody on the X axis in either world or local space.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-linearVelocity.html")]
    public sealed class RigidbodySetVelocityX : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.FixedUpdate | UpdateMode.EveryFrame;

        [Tooltip("The Rigidbody")]
        [SerializeField]
        private RigidbodyVar _rigidbody;
        
        [Tooltip("Set Rigidbody Velocity in X")]
        [SerializeField]
        private FloatVar _setVelocityX;

        [Tooltip("Select if the velocity is in world or local space")]
        [SerializeField, DefaultValue(Space.World)]
        private SpaceVar _space;
        
        public override bool CanExecute() => CheckParameters(_rigidbody, _setVelocityX);

        public override void Execute()
        {
#if UNITY_6000_0_OR_NEWER
            var velocity = _rigidbody.Value.linearVelocity;
            if (_space.Value == Space.World)
            {
                velocity.x = _setVelocityX.Value;
            }
            else
            {
                // Convert world velocity to local space
                velocity = _rigidbody.Value.transform.InverseTransformDirection(velocity);
                velocity.x = _setVelocityX.Value;
                // Convert back to world space
                velocity = _rigidbody.Value.transform.TransformDirection(velocity);
            }
            _rigidbody.Value.linearVelocity = velocity;
#else
            var velocity = _rigidbody.Value.velocity;
            if (_space.Value == Space.World)
            {
                velocity.x = _setVelocityX.Value;
            }
            else
            {
                // Convert world velocity to local space
                velocity = _rigidbody.Value.transform.InverseTransformDirection(velocity);
                velocity.x = _setVelocityX.Value;
                // Convert back to world space
                velocity = _rigidbody.Value.transform.TransformDirection(velocity);
            }
            _rigidbody.Value.velocity = velocity;
#endif
        }
        
        public override string GetSummary() => "Set {_rigidbody} X velocity to {_setVelocityX}" +
                                             (_space.IsNotDefault(Space.World) ? " (local)" : string.Empty);
    }
}
