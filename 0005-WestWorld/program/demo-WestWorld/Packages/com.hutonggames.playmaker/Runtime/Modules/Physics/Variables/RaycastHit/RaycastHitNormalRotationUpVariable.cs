using System;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(RaycastHitVariable), typeof(Quaternion), "normalRotationUp", false)]
    public class RaycastHitNormalRotationUpVariable : BaseVariableProperty<RaycastHit, Quaternion>
    {
        public override string PropertyName => "normalRotationUp";
        
#if UNITY_EDITOR
        public override string Description => "A rotation that can be used to align an instantiated object to the surface that was hit. " +
                                              "The object's up (+Y) axis will point out of the surface.";
#endif

        public override Quaternion Value
        {
            get => Quaternion.FromToRotation(Vector3.up, (Target as RaycastHitVariable)?.Value.normal ?? Vector3.up);
            set { }
        }
    }
}