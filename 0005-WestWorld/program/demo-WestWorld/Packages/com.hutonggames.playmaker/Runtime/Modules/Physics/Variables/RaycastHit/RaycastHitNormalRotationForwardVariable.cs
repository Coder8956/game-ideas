using System;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(RaycastHitVariable), typeof(Quaternion), "normalRotationForward", false)]
    public class RaycastHitNormalRotationForwardVariable : BaseVariableProperty<RaycastHit, Quaternion>
    {
        public override string PropertyName => "normalRotationForward";
        
#if UNITY_EDITOR
        public override string Description => "A rotation that can be used to align an instantiated object to the surface that was hit. " +
                                              "The object's forward (+Z) axis will point out of the surface.";
#endif

        public override Quaternion Value
        {
            get => Quaternion.LookRotation((Target as RaycastHitVariable)?.Value.normal ?? Vector3.forward);
            set { }
        }
    }
}