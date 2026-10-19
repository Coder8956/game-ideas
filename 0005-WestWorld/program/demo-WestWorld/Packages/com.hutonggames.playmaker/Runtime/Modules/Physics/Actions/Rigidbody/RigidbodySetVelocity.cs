using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Rigidbody)]
    [ConvertibleGroup("RigidbodySetVelocity")]
    [ActionDescription("Set the velocity vector of the rigidbody in either world or local space. It represents the rate of change of Rigidbody position.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-linearVelocity.html")]
    public sealed class RigidbodySetVelocity : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.FixedUpdate | UpdateMode.EveryFrame;
        
        [Tooltip("The Rigidbody")]
        [SerializeField]
        private RigidbodyVar _rigidbody;
        
        [Tooltip("Set Rigidbody Velocity")]
        [SerializeField]
        private Vector3Var _setVelocity;

        [Tooltip("Select if the velocity is in world or local space")]
        [SerializeField, DefaultValue(Space.World)]
        private SpaceVar _space;
        
        public override bool CanExecute()
        {
            return CheckParameters(_rigidbody, _setVelocity);
        }
        
        public override void Execute()
        {
#if UNITY_6000_0_OR_NEWER
            var velocity = _setVelocity.Value;
            if (_space.Value == Space.Self)
            {
                velocity = _rigidbody.Value.transform.TransformDirection(velocity);
            }
            _rigidbody.Value.linearVelocity = velocity;
#else
            var velocity = _setVelocity.Value;
            if (_space.Value == Space.Self)
            {
                velocity = _rigidbody.Value.transform.TransformDirection(velocity);
            }
            _rigidbody.Value.velocity = velocity;
#endif
        }
        
        public override string GetSummary() => "Set {_rigidbody} velocity to {_setVelocity}" +
                                               (_space.IsNotDefault(Space.World) ? " (local)" : string.Empty);
    }
}
